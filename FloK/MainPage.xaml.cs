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

namespace FloK
{
    public partial class MainPage : PhoneApplicationPage
    {

        public ServiceReference1.Service1Client flok_ws;

        // Constructeur

        #region Constructor

        public MainPage()
        {
            InitializeComponent();
            flok_ws = new ServiceReference1.Service1Client();
        }

        #endregion

        #region Events

        /// <summary>
        /// Fired when the user clicks on the 'Go' button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tb_login.Text) && !string.IsNullOrEmpty(this.tb_pwd.Text))
            {

                // on va checker s'il existe dans la base, si oui; on le change d'écran (vers menu principale)
                flok_ws.isUserInDBAsync(this.tb_login.Text, this.tb_pwd.Text);
                flok_ws.isUserInDBCompleted += flok_ws_userOk;                
            }
            else if (!string.IsNullOrEmpty(this.tb_login.Text))
            {
                this.tb_error.Text = "Please enter a password";
            }
            else if (!string.IsNullOrEmpty(this.tb_pwd.Text))
            {
                this.tb_error.Text = "Please enter a login";
            }
            // on ne fait rien car pas de données entrées
            else { }
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_login_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.tb_error.Text = string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_pwd_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.tb_error.Text = string.Empty;
        }

        #endregion

        #region AsyncResults

        void flok_ws_userOk(object sender, ServiceReference1.isUserInDBCompletedEventArgs e)
        {
            try
            {
                //bool isError = bool.Parse(e.Result.ToString());
                if (e.Result)
                {
                    NavigationService.Navigate(new Uri("/MenuPage.xaml", UriKind.Relative));
                }
                else
                {
                    //afficher erreur de login ou "creer un identifiant ?"
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion


    }
}