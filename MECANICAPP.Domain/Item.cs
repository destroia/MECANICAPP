using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECANICAPP.Domain
{
    public class Item
    {
        [Key]
        public int ItemsId { get; set; }
       
        public int CategoryId { get; set; }
        
        public string Codigo { get; set;  }


        [Required]
        public string Marca { get; set; }

        [Required]
        public string Medelo { get; set; }

        public string Serial { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de compra")]
        public  DateTime anoCompra { get; set; }

        [Display(Name ="Precio de compra")]
        [DisplayFormat(DataFormatString ="{0:C2}",ApplyFormatInEditMode =false)]
        [Required]
        public decimal precio { get; set; }

        public string Ubicacion { get; set; }
        

        [Required(ErrorMessage ="Este campo de {0} es requerido")]
        [MinLength(15,ErrorMessage ="Se esperaban mas de {0} caracteres")]
        //[Index("Items_Descripcion_Index",IsUnique = true)]
        public string Descripcion { get; set; }


        public virtual Category Category { get; set; }
    }
}
