using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MECANICAPP.Models
{
    public class CategoryMap
    {
        public int CategoryId { get; set; }
        public string Descripcion { get; set; }
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

        void SeleccionCategory()
        {
            
        }
        #endregion
    }
}
