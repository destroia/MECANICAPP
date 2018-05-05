using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECANICAPP.Domain
{
    public class Historia
    {
        [Display(Name ="codigo")]
        public int ItemsId { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Fecha de intervencion")]
        public DateTime FechaIntervecion { get; set; }


        [Display(Name ="Valor de la intervencion")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required]
        public double Valor { get; set; }


        [Display(Name = "Repuetos requeridos")]
        public string Repuestos { get; set; }

        [Key]
        [Display(Name = "Descripcion de la reparacion")]
        public string Historias { get; set; }
        

        [JsonIgnore]
        public virtual Item  Item { get; set; }
    }
}
