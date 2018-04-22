using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MECANICAPP.Servicios
{
    class DialogoServices
    {
        public async Task ShowMensaje(string titulo,string menseje)
        {
            await Application.Current.MainPage.DisplayAlert(titulo, menseje, "Aceptar");
        }
    }
}
