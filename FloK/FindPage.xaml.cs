using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Device.Location;
using Microsoft.Phone.Controls.Maps;
using FloK.ServiceReference2;
using System.Collections.ObjectModel;



namespace FloK
{
    public partial class FindPage : PhoneApplicationPage
    {
        private GeoCoordinateWatcher geoWatcher = null;
        private ServiceReference2.GeocodeServiceClient geoService = null;

        public FindPage()
        {
            InitializeComponent();

            geoService = new ServiceReference2.GeocodeServiceClient("BasicHttpBinding_IGeocodeService");

            this.map_find.ZoomBarVisibility = System.Windows.Visibility.Visible;

            geoWatcher = new GeoCoordinateWatcher();
            geoWatcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);

            // on met un écouteur sur le gps du téléphone
            geoWatcher.PositionChanged += new EventHandler<GeoPositionChangedEventArgs<GeoCoordinate>>(geoWatcher_PositionChanged);
            geoWatcher.Start();

            // l'écouteur qui va permettre de lancer le centrage de la map sur une adresse entrée
            // avec le geoCodeAsync
            geoService.GeocodeCompleted += (s, e) =>
                {
                    var geoResult = (from r in e.Result.Results
                                     orderby (int)r.Confidence ascending
                                     select r).FirstOrDefault();
                    if (geoResult != null)
                    {
                        map_find.Center = new GeoCoordinate(geoResult.Locations[0].Latitude, geoResult.Locations[0].Longitude);
                        map_find.ZoomLevel = 8;
                    }
                    else
                    {
                        // afficher un message d'erreur et réessayer centrage sur le gps du mobile
                    }
                };

        }

        // lorsque la position change (ou simplement si on veut la position actuelle)
        void geoWatcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            //GeoCoordinate currentLocation = e.Position.Location;
            //double currentAltitude = e.Position.Location.Altitude;
            double currentLongitude = e.Position.Location.Longitude;
            double currentLatitude = e.Position.Location.Latitude;

            //on centre la map sur la position du téléphone            
            map_find.Center = new GeoCoordinate(currentLatitude, currentLongitude);
            map_find.ZoomLevel = 10;

            // la stocker et l'envoyer en base
            string location = currentLatitude.ToString().Replace(',', '.') + "," + currentLongitude.ToString().Replace(',', '.');
        }

        //lorsque l'utilisateur click sur le textChange
        private void tb_find_stations_Tap(object sender, GestureEventArgs e)
        {
            this.tb_find_stations.Text = "";
        }

        //Lorsque l'on clic sur le ok et que l'utilisateur à effectivement entré une location
        private void btn_find_ok_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_find_stations.Text))
            {
                if (tb_find_stations.Text != "Find Stations next to...")
                {
                    GeocodeAddress(tb_find_stations.Text);
                }
                else
                {
                   //
                }
            }
            else
            {
                tb_find_stations.Text = "Find Stations next to...";
            }

        }

        // launch the geolocalisation from an address
        private void GeocodeAddress(string location)
        {
            ServiceReference2.GeocodeRequest geoRequest = new ServiceReference2.GeocodeRequest();
            // Only accept results with high confidence.
            geoRequest.Options = new GeocodeOptions()
            {
                Filters = new ObservableCollection<FilterBase>
                        {
                            new ConfidenceFilter()
                            {
                                MinimumConfidence = Confidence.High
                            }
                        }
            };

            //l'identification permettant de faire l'appel
            geoRequest.Credentials = new Credentials()
            {
                ApplicationId = "AjWdQ1rhT-6mavceCEuBI7ctxHS978f3oOHMG19m-BxuIXTo6Cv0HHPYv7SC1zJd"
            };

            // puis on met l'adresse ici dans la requete
            geoRequest.Query = location;
            geoService.GeocodeAsync(geoRequest);
        }

    }
}