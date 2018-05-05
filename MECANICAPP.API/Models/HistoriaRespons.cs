using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MECANICAPP.API.Models
{
    public class HistoriaRespons
    {
        public DateTime FechaIntervecion { get; set; }

        public double Valor { get; set; }

        public string Repuestos { get; set; }

        public string Historias { get; set; }
    }
}