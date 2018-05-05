using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MECANICAPP.API.Models
{
    public class CategoryRespons
    {
        public int CategoryId { get; set; }

        
        public string Descripcion { get; set; }

        public virtual List<ItemRespons> Items { get; set; }
    }
}