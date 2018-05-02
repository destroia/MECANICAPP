using System;
using System.Collections.Generic;
using System.Text;

namespace MECANICAPP.Models
{
    public class Rosponse
    {
        public bool  IsSuccess { get; set; }
        public string Message { get; set; }
        public object Result { get; set; }
    }
    
}
