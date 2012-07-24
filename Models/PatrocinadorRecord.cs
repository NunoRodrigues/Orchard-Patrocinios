using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinadorRecord
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string ContactoNome { get; set; }
        public virtual string ContactoTelefone { get; set; }
        public virtual string ContactoEmail { get; set; }
        public virtual string Observacoes { get; set; }
    }

    
}