using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Patrocinadores.Models
{
    public class PatrocinioConfigurationRecord : ContentPartRecord {
        public virtual int IDTipo { get; set; }
        public virtual int IDPatrocinador { get; set; }
        public virtual string URLImage { get; set; }
    }

    /// <summary>
    /// TODO:

    /// </summary>
    public class PatrocinioConfigurationPart : ContentPart<PatrocinioConfigurationRecord>
    {
        [Required]
        public int IDTipo
        {
            get { return Record.IDTipo; }
            set { Record.IDTipo = value; }
        }

        [Required]
        public int IDPatrocinador
        {
            get { return Record.IDPatrocinador; }
            set { Record.IDPatrocinador = value; }
        }

        [Required]
        public string URLImage
        {
            get { return Record.URLImage; }
            set { Record.URLImage = value; }
        }

        public List<Patrocinador> Patrocinadores
        {
            get { return Patrocinador.getList(); }
        }

        public List<PatrocinioLocalizacao> Localizacao
        {
            get { return PatrocinioLocalizacao.getList(); }
        }
    }

    public class Patrocinio
    {
        public int IDZona { get; set; }
        public int IDPagina { get; set; }
        public int IDPatrocinador { get; set; }
        public string URLImage { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }   
}