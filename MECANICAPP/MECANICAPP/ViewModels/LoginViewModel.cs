using GalaSoft.MvvmLight.Command;
using MECANICAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace MECANICAPP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {


        public LoginViewModel()
        {
            this.IsEnabled = true;
            this.IsRunning = false;
            this.IsRemeber = true;
            this.Email = "david";
            this.password = "1234";

        }

        #region Atributos
        private string email;
        private string password;
        private bool isRunning;
        private bool isRemeber;
        // private bool isEnabled;
        #endregion

        #region propiedades


        public bool IsEnabled
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue(ref isRunning, value); }

        }
        public bool IsRemeber {
            get;


            set;

        }

        #endregion
        #region comandos
        public ICommand LoginCMD
        {
            get
            {
                return new RelayCommand(Login);
            }
        }



        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu E-mail", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu contraseña", "Aceptar");
                return;
            }
            if (this.Email != "david" && this.Password != "1234")
            {
                this.Password = string.Empty;

            }
            MainViewModel.Getinstancia().Escoger = new EscogerViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EscogerPage());
            // return;
        }

        public ICommand RegistarCMD
        {
            get
           {
                return new RelayCommand(Register);
            }

        }

        private async void Register()
        {
            
            MainViewModel.Getinstancia().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage1());

            
           
        }
        #endregion
    }
}
