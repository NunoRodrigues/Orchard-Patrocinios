using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Patrocinadores.Models
{
    public class Patrocinador
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public static List<Patrocinador> getList()
        {
            List<Patrocinador> list = new List<Patrocinador>();

            list.Add(new Patrocinador() { ID = 1, Nome = "Skol" });
            list.Add(new Patrocinador() { ID = 2, Nome = "Brahma" });
            list.Add(new Patrocinador() { ID = 3, Nome = "Antarctica" });

            return list;
        }
    }
}