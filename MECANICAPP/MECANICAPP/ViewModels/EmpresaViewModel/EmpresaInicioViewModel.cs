using System;
using MECANICAPP.Models;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using MECANICAPP.Servicios;
using System.ComponentModel;
using System.Linq;

namespace MECANICAPP.ViewModels.EmpresaViewModel
{
     public class EmpresaInicioViewModel : BaseViewModel// INotifyPropertyChanged
    {
        #region Servicios
        ApiServicio apiServicio;
        DialogoServices dialogoServices;
        #endregion
       
        #region Eventos
        //public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Atributos
        ObservableCollection<CategoryMap> _categoryMap;
        #endregion
        public ObservableCollection<CategoryMap> CategoryMaps
        {
            get { return _categoryMap; }
            set { SetValue(ref _categoryMap, value); }
            /* get { return _categoryMap; }
             set
             {
                 if (_categoryMap != value)
                 {
                     _categoryMap = value;
                     PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CategoryMap)));
                 }
             }*/
        }
        public EmpresaInicioViewModel()
        {
            dialogoServices = new DialogoServices();
            apiServicio = new ApiServicio();
            LoadingEmpresaInicioViewModel();
            
        }

            
        async void  LoadingEmpresaInicioViewModel()
        {
            var connection = await apiServicio.CheckConnection();
            if(!connection.IsSuccess)
            {
                await dialogoServices.ShowMensaje("Error", connection.Message);
                return;
            }
            var mainViewModel = MainViewModel.Getinstancia();
            var Responce = await apiServicio.GetList<CategoryMap>("http://mecanicappapi.azurewebsites.net","/api","/Categories",
                mainViewModel.Token.Token_type,mainViewModel.Token.Access_token);
            if(!Responce.IsSuccess)
            {
                await dialogoServices.ShowMensaje("Error", connection.Message);
                return;
            }
            var categories = (List<CategoryMap>)Responce.Result;
            CategoryMaps = new ObservableCollection<CategoryMap>(categories.OrderBy(c => c.Descripcion));
        }

    }
}
