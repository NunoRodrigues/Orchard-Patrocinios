using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinioRecord
    {
        public int IDZona { get; set; }
        public int IDPagina { get; set; }
        public int IDPatrocinador { get; set; }
        public string URLImage { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    } 
}