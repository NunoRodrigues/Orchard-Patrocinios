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

        public static List<PatrocinioRecord> getList(int idZona)
        {
            List<PatrocinioRecord> list = new List<PatrocinioRecord>();

            list.Add(new PatrocinioRecord() { IDZona = idZona, IDPatrocinador = 1, DataInicio = DateTime.Now.AddDays(-7), DataFim = DateTime.Now.AddDays(7) });

            return list;
        }
    } 
}