using GalaSoft.MvvmLight.Command;
using MECANICAPP.Servicios;
using MECANICAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using MECANICAPP.ViewModels;
using MECANICAPP.Models;

namespace MECANICAPP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {


        public LoginViewModel()
        {
            dialogoSerices = new DialogoServices();
            apiServicio = new ApiServicio();
            this.IsEnabled = true;
            this.IsRunning = false;
            this.IsRemeber = true;
            this.Email = "da@gmail.com";
            this.password = "123456";

        }

        #region Servicios
        DialogoServices dialogoSerices;
        ApiServicio apiServicio;
        #endregion
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
                await dialogoSerices.ShowMensaje("Error", "Tienes que ingresar tu E-mail");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await dialogoSerices.ShowMensaje("Error", "Tienes que ingresar tu contraseña");
                return;
            }
            IsRunning = true;
            IsEnabled = false;
            var connection = await apiServicio.CheckConnection();
            if (!connection.IsSuccess)
            {
                IsEnabled = true;
                IsEnabled = false;
                await dialogoSerices.ShowMensaje("Error", connection.Message);
                return;
            }

            var Responce = await apiServicio.GetToken("http://mecanicappapi.azurewebsites.net", Email, Password);
            if (Responce == null || string.IsNullOrEmpty(Responce.Access_token))
            {
                IsEnabled = true;
                IsRunning = false;
                await dialogoSerices.ShowMensaje("Error", Responce.ErrorDescription);
                return;
            }
            var mainViewModel = MainViewModel.Getinstancia();
            mainViewModel.Token = Responce;

           // await dialogoSerices.ShowMensaje("taran", "Bienvenido");
             MainViewModel.Getinstancia().Escoger = new EscogerViewModel();
           
            await Application.Current.MainPage.Navigation.PushAsync(new EscogerPage());
             return;
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
