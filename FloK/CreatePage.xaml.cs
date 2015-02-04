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
using System.Text;
using System.Text.RegularExpressions;
using System.Security.Cryptography;

namespace FloK
{
    public partial class CreatePage : PhoneApplicationPage
    {
        public ServiceReference1.Service1Client flok_ws;

        public CreatePage()
        {
            InitializeComponent();
            flok_ws = new ServiceReference1.Service1Client();
        }

        // when the user clicks on the check button
        private void btn_check_login_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.tb_creation_login.Text))
            {
                flok_ws.isLoginInDBAsync(this.tb_creation_login.Text);
                flok_ws.isLoginInDBCompleted += flock_ws_isUserLoginCheck;  
            }
        }

        /// <summary>
        /// When the user clicks on the "create" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tb_creation_login.Text) && !String.IsNullOrEmpty(this.tb_creation_email.Text) && !String.IsNullOrEmpty(this.tb_pw_create_1.Password) && !String.IsNullOrEmpty(this.tb_pw_create_2.Password))
            {
                if (this.tb_pw_create_1.Password.Length >= 5 && this.tb_pw_create_2.Password.Length >= 5)
                {
                    // ici on a toutes les infos renseignés (pas d'appels aux web service avant d'avoir tester les mots de passe)
                    // on check si les mots de passe correspondent
                    if (this.tb_pw_create_1.Password == this.tb_pw_create_2.Password)
                    {
                        //si le mail à un format ok
                        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                        Match match = regex.Match(this.tb_pw_create_1.Password);
                        if (match.Success)
                        {
                            flok_ws.isLoginInDBAsync(this.tb_creation_login.Text);
                            flok_ws.isLoginInDBCompleted += flok_ws_isUserLogin;
                        }
                        else
                        {
                            this.tb_create_error.Text = "The mail format is wrong, please change it";
                            this.tb_creation_email.Text = "";
                        }
                    }
                    else
                    {
                        // si non, on envoi un message d'erreur qui dit mots de passe non correspondant, on laisse alors le login et le mail prérempli
                        this.tb_create_error.Text = "The passwords don't match, please try again";
                        this.tb_pw_create_1.Password = "";
                        this.tb_pw_create_2.Password = "";
                    }
                }
                else
                {
                    this.tb_create_error.Text = "The passwords are not long enough, try again";
                    this.tb_pw_create_1.Password = "";
                    this.tb_pw_create_2.Password = "";
                }
            }
            else
            {
                // message erreur veuillez renseigner tous les champs svp, laisser prérempli ce qui a été mis
                this.tb_create_error.Text = "Please fill all the required boxes";
            }
        }

        private void tb_creation_login_Tap(object sender, GestureEventArgs e)
        {
            this.tb_create_error.Text = "";
            this.img_check.Visibility = Visibility.Collapsed;
        }

        private void tb_creation_email_Tap(object sender, GestureEventArgs e)
        {
            this.tb_create_error.Text = "";
        }

        private void tb_pw_create_1_Tap(object sender, GestureEventArgs e)
        {
            this.tb_create_error.Text = "";
        }

        private void tb_pw_create_2_Tap(object sender, GestureEventArgs e)
        {
            this.tb_create_error.Text = "";
        }

        #region AsyncFunctions

        void flok_ws_isUserLogin(object sender, ServiceReference1.isLoginInDBCompletedEventArgs e)
        {
            // s'il est déjà en bdd
            if (e.Result)
            {
                this.img_check.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/FloK;component/error.png");
                this.img_check.Visibility = Visibility.Visible;

                //afficher message d'erreur et ne laisser que le mail prérempli dedans
                this.tb_create_error.Text = "Please enter another login and check for it's availability";
                this.tb_creation_login.Text = "";
                this.tb_pw_create_1.Password = "";
                this.tb_pw_create_2.Password = "";
            }
            else
            {
                // send the informations
                flok_ws.CreateUserAsync(this.tb_creation_login.Text,this.tb_creation_email.Text,this.tb_pw_create_1.Password);
                flok_ws.CreateUserCompleted += flok_ws_isUserCreated;  
                //if creation ok, redirect to login page and pre-enter the login with the new one
            }
        }


        void flock_ws_isUserLoginCheck(object sender, ServiceReference1.isLoginInDBCompletedEventArgs e)
        {
            if (e.Result)
            {
                this.img_check.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/FloK;component/error.png");
                this.tb_create_error.Text = "The login you choose already exists, please try again";
            }
            else
            {
                this.img_check.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/FloK;component/ok.png");
                this.tb_create_error.Text = "";
            }
            this.img_check.Visibility = Visibility.Visible;
        }


        void flok_ws_isUserCreated(object sender, ServiceReference1.CreateUserCompletedEventArgs e)
        {
            if (e.Result)
            {
                //on redirige vers la page d'accueil
                try
                {
                    NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                this.img_check.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("/FloK;component/error.png");
                this.tb_create_error.Text = "An error occured during the registration, please try again";
                this.img_check.Visibility = Visibility.Visible;
            }
        }

        #endregion

    }
}