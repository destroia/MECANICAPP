using System;
using System.Collections.Generic;
using System.Text;
using MECANICAPP.ViewModels.EmpresaViewModel;
using MECANICAPP.ViewModels.MecanicoViewModel;

namespace MECANICAPP.ViewModels
{
    
    public class MainViewModel
    {
        #region ViewModel
        public LoginViewModel Login
        {
            get;
            set;
        }
        #endregion
        public EscogerViewModel Escoger
        {
            get;
            set;
        }
        public RegisterViewModel Register
        {
            get;
            set;
        }
        public EmpresaInicioViewModel EmpresaInicio
        {
            get;
            set;
        }
        public MecanicoInicioViewModel MecanicoInicio
        {
            get;
            set;
        }


        #region contructor
        public MainViewModel()
        {
            instacia = this;
            this.Login = new LoginViewModel();
        }
        
        #endregion
        #region singleton
        private static MainViewModel instacia;
        public static MainViewModel Getinstancia()
        {
            if(instacia ==null)
            {
                return new MainViewModel();
            }
            return instacia;
        }
        #endregion
    }

 
}
