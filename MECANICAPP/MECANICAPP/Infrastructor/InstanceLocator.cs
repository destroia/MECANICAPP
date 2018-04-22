using System;
using System.Collections.Generic;
using System.Text;

namespace MECANICAPP.Infrastructor
{
    using ViewModels;
    
    class InstanceLocator
    {
        #region propiedades
    public MainViewModel Main
        {

            get;
            set;
        }
        #endregion

        #region constuctor
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
