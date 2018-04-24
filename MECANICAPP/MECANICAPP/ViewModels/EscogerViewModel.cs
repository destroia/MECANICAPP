using GalaSoft.MvvmLight.Command;
using MECANICAPP.ViewModels.EmpresaViewModel;
using MECANICAPP.ViewModels.MecanicoViewModel;
using MECANICAPP.Views;
using MECANICAPP.Views.EmpresaView;
using MECANICAPP.Views.MecanicoView;
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
        public ICommand MaquinaCMD
        {
            get
            {
                return new RelayCommand(Maquina);
            }
        }
        private async void Maquina()
        {
            MainViewModel.Getinstancia().MecanicoInicio = new MecanicoInicioViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MecanicoInicioPage());

        }
    }
}