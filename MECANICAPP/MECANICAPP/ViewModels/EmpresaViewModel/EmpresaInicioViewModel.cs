using System;
using MECANICAPP.Models;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace MECANICAPP.ViewModels.EmpresaViewModel
{
     public class EmpresaInicioViewModel
    {
        public ObservableCollection<CategoryMap> CategoryMaps
        {
            get;
            set;
        }
        public EmpresaInicioViewModel()
        {
            LoadingEmpresaInicioViewModel();
        }

            
        void  LoadingEmpresaInicioViewModel()
        {

        }

    }
}
