using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MECANICAPP.API.Models
{
    public class ItemRespons
    {
        public int ItemsId { get; set; }
       
        public string Codigo { get; set; }

        public string Marca { get; set; }

      
        public string Medelo { get; set; }

        public string Serial { get; set; }

      
        public DateTime anoCompra { get; set; }

        
        public double precio { get; set; }

        public string Ubicacion { get; set; }


       
        //[Index("Items_Descripcion_Index",IsUnique = true)]
        public string Descripcion { get; set; }

       
        

        public virtual ICollection<HistoriaRespons> Historias { get; set; }
    }
}