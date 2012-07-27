using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.Data.Conventions;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinioItemRecord
    {
        public virtual int Id { get; set; }

        [Required]
        public virtual int PatrociniosPartRecord_Id { get; set; }

        [Aggregate]
        public virtual PatrocinadorRecord PatrocinadorRecord { get; set; }

        [Required, Display(Name="Tipo")]
        public virtual int IdTipo { get; set; }

        [Required, Display(Name = "Data Inicio")]
        public virtual DateTime DataInicio { get; set; }

        [Required, Display(Name = "Data Fim")]
        public virtual DateTime DataFim { get; set; }

        [Required, Display(Name = "URL Imagem")]
        public virtual string URLImage { get; set; }
    }
}