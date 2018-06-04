using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using MECANICAPP.Views.EmpresaView;
using MECANICAPP.ViewModels.EmpresaViewModel;
using MECANICAPP.ViewModels;
using MECANICAPP.Models;

namespace MECANICAPP.Models
{
    public class CategoryMap
    {
        public int CategoryId { get; set; }
        public string Descripcion { get; set; }
        public List<ItemMap> ItemMaps { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
        #region Comandos
        public ICommand SeleccionCategoryCommand {
            get
            {
                return new RelayCommand(SeleccionCategory);
            }
            
        }

        async void SeleccionCategory()
        {
           

            await Application.Current.MainPage.Navigation.PushAsync(new ItemsPage());
            var mainViewModel = MainViewModel.Getinstancia();
            mainViewModel.ItemsyMaps = new ItemsViewModel(ItemMaps);

        }
        #endregion
    }
}
