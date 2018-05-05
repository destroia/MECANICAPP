using System;
using System.Collections.Generic;
using System.Text;

namespace MECANICAPP.Models
{
    class ItemMap
    {
        public int ItemsId { get; set; }
        public string Codigo { get; set; }
        public string Marca { get; set; }
        public string Medelo { get; set; }
        public string Serial { get; set; }
        public DateTime anoCompra { get; set; }
        public double precio { get; set; }
        public string Ubicacion { get; set; }
        public string Descripcion { get; set; }
        public List<HistoriaMap> Historias { get; set; }
    }
}
