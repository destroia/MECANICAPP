using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using MECANICAPP.Models;
using System.Linq;

namespace MECANICAPP.ViewModels.EmpresaViewModel
{
    public class ItemsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<ItemMap> itemMaps;
        ObservableCollection<ItemMap> _itemMaps;

       

        public ObservableCollection<ItemMap> ItemMaps
        {
            get
            {
                return _itemMaps;
            }
            set
            {
                if (_itemMaps != value)
                {
                    _itemMaps = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(ItemMaps)));
                }
            }
        }


        public ItemsViewModel(List<ItemMap> itemMaps) 
        {
            this.itemMaps = itemMaps;
            ItemMaps = new ObservableCollection<ItemMap>(itemMaps.OrderBy(p => p.Codigo));
            
        }

       








        #region Constrectores



        #endregion


    }
}
