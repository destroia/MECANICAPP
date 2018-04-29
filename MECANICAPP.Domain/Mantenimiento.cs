using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECANICAPP.Domain
{
    public class Mantenimiento
    {
        public string codigo { get; set; }

        [Display(Name ="Fecha de ultimo reporte")]
        public DateTime FechaReporte { get; set; }

        [Key]
        public string ResgistroMantenimiento { get; set; }


        public virtual Category Category { get; set; }


    }
}
