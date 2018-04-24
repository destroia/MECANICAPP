using GalaSoft.MvvmLight.Command;
using MECANICAPP.ViewModels.EmpresaViewModel;
using MECANICAPP.Views;
using MECANICAPP.Views.EmpresaView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MECANICAPP.ViewModels
{
	public class EscogerViewModel : ContentPage
	{
		public EscogerViewModel ()
		{

			
		}

        public ICommand EmpresasCMD
        {
            get
            {
                return new RelayCommand(Empresa);
            }

        }

        private async void Empresa()
        {
            MainViewModel.Getinstancia().EmpresaInicio = new EmpresaInicioViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new EmpresaInicioPage());


        }
    }
}