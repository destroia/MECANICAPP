using GalaSoft.MvvmLight.Command;
using MECANICAPP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using MECANICAPP.Servicios;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using MECANICAPP.ViewModels.EmpresaViewModel;

namespace MECANICAPP.ViewModels
{
    public class RegisterViewModel: BaseViewModel
    {
        public RegisterViewModel()
        {
            dialogoServices =new  DialogoServices();
            this.registerNombre = "david stiven";
           

        }
        #region Servicios
        DialogoServices dialogoServices;
        #endregion
        #region atributos
        #region variables
        
        private string registerNombre;
        private string registerApellido;
        private string registerDireccion;
        private string registerEmail;
        private string registerEmpresa;
        private string registerTelefono;

        #endregion
        public string RegisterNombre
        {
            get { return registerNombre; }
            set { SetValue(ref registerNombre, value); }
        }
        public string RegisterApellido
        {
            get { return registerApellido; }
            set { SetValue(ref registerApellido, value); }
        }
        public string RegisterDireccion
        {
            get { return registerDireccion; }
            set { SetValue(ref registerDireccion, value); }
        }
        public string  RegisterTelefono
        {
            get { return registerTelefono; }
            set { SetValue(ref registerTelefono, value); }
        }
        public string RegisterEmail
        {
            get { return registerEmail; }
            set { SetValue(ref registerEmail, value); }
        }
        public string RegisterEmpresa
        {
            get { return registerEmpresa; }
            set { SetValue(ref registerEmpresa, value); }
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
                await dialogoServices.ShowMensaje("Error", "Tienes que ingresar tu nombre");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterApellido))
            {
                await dialogoServices.ShowMensaje("Error", "Tienes que ingresar tu apellido");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterDireccion))
            {
                await dialogoServices.ShowMensaje("Error", "Tienes que ingresar tu direccion");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterTelefono))
            {
                await dialogoServices.ShowMensaje("Error", "Tienes que ingresar tu telefono");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterEmail))
            {
                await dialogoServices.ShowMensaje("Error", "Tienes que ingresar tu E-mail");
                return;
            }
            if (string.IsNullOrEmpty(this.RegisterEmpresa))
            {
                await dialogoServices.ShowMensaje("Error", "Tienes que ingresar tu empresa");
                return;
            }


            MainViewModel.Getinstancia().Login = new LoginViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LoginPage1());



        }

        public static implicit operator RegisterViewModel(EmpresaInicioViewModel v)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

}
