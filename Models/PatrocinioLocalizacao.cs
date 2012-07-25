using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinioLocalizacao
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        /*
        public static List<PatrocinioLocalizacao> getList()
        {
            List<PatrocinioLocalizacao> _localizacao = new List<PatrocinioLocalizacao>();

            _localizacao.Add(new PatrocinioLocalizacao() { ID = 1, Nome = "Header" });
            _localizacao.Add(new PatrocinioLocalizacao() { ID = 2, Nome = "Content - Top" });
            _localizacao.Add(new PatrocinioLocalizacao() { ID = 3, Nome = "Content - Right" });
            _localizacao.Add(new PatrocinioLocalizacao() { ID = 4, Nome = "Content - Bottom" });
            _localizacao.Add(new PatrocinioLocalizacao() { ID = 5, Nome = "Content - Left" });
            _localizacao.Add(new PatrocinioLocalizacao() { ID = 6, Nome = "Footer" });

            return _localizacao;
        }
        */
    }
}