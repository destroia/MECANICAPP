using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MECANICAPP.Domain
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

         [Required(ErrorMessage ="Este campo {0} es requerido")]      
         [MaxLength(15,ErrorMessage ="Este campo {0} requiere minimo {1} caracteres")]
         [Index("Category_Descripcion_Index",IsUnique =true)]
        public string Descripcion { get; set; }


        public virtual ICollection<Item> Items { get; set; }
    }
}
