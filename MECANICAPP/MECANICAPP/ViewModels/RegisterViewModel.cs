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
    public class RegisterViewModel: BaseViewModel
    {
        public RegisterViewModel()
        {
            this.registerNombre = "david stiven";
        }
        #region atributos
        #region variables
        private string registerNombre;
        #endregion
        public string RegisterNombre
        {
            get { return registerNombre; }
            set { SetValue(ref registerNombre, value); }
        }
        public string RegisterApellido
        {
            get;
        }
        public string RegisterDireccion
        {
            get;
        }
        public int RegisterTelefono
        {
            get;
        }
        public string RegisterEmail
        {
            get;
        }
        public string RegisterEmpresa
        {
            get;
        }

        #endregion
        #region comandos
        public ICommand RegisterCMD
        {
            get
            {
                return new RelayCommand(Registro);
            }
        }
        private async void Registro()
        {
            if (string.IsNullOrEmpty(this.RegisterNombre))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu nombre", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterApellido))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu apellido", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterDireccion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu apellido", "Aceptar");
                return;
            }
            if (this.RegisterTelefono == 0)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu telefono", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterEmail))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu E-mail", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterEmpresa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Tienes que ingresar tu empresa", "Aceptar");
                return;
            }


            MainViewModel.Getinstancia().Login = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage1());



        }
        #endregion
    }

}
