using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinadorRecord : ContentPartRecord
    {
        public virtual int Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual string ContactoNome { get; set; }
        public virtual string ContactoTelefone { get; set; }
        public virtual string ContactoEmail { get; set; }
        public virtual string Observacoes { get; set; }
    }

    public class PatrocinadorPart : ContentPart<PatrocinadorRecord>
    {
        [Required]
        public int Id
        {
            get { return Record.Id; }
            set { Record.Id = value; }
        }

        [Required]
        public string Nome
        {
            get { return Record.Nome; }
            set { Record.Nome = value; }
        }

        [Required]
        public string ContactoNome
        {
            get { return Record.ContactoNome; }
            set { Record.ContactoNome = value; }
        }

        [Required]
        public string ContactoTelefone
        {
            get { return Record.ContactoTelefone; }
            set { Record.ContactoTelefone = value; }
        }

        [Required]
        public string ContactoEmail
        {
            get { return Record.ContactoEmail; }
            set { Record.ContactoEmail = value; }
        }

        [Required]
        public string Observacoes
        {
            get { return Record.Observacoes; }
            set { Record.Observacoes = value; }
        }
    }
}