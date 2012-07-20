using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Orchard.Patrocinadores.Models
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

        public List<PatrocinioRecord> Patrocinios
        {
            get { return PatrocinioRecord.getList(1); }
        }

        public List<PatrocinioLocalizacao> Localizacoes
        {
            get { return PatrocinioLocalizacao.getList(); }
        }
    }
}