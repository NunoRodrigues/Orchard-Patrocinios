using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinioWidgetTipoRecord
    {
        public virtual int Id { get; set; }
        public virtual string Tipo { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual int PosTop { get; set; }
        public virtual int PosLeft { get; set; }
        public virtual string Color { get; set; }
    }

    public class PatrocinioWidgetTipoPart : ContentPart<PatrocinioWidgetTipoRecord>
    {
        [Required]
        public int Id
        {
            get { return Record.Id; }
            set { Record.Id = value; }
        }

        [Required]
        public string Tipo
        {
            get { return Record.Tipo; }
            set { Record.Tipo = value; }
        }

        [Required]
        public int Width
        {
            get { return Record.Width; }
            set { Record.Width = value; }
        }

        [Required]
        public int Height
        {
            get { return Record.Height; }
            set { Record.Height = value; }
        }

        [Required]
        public int PosTop
        {
            get { return Record.PosTop; }
            set { Record.PosTop = value; }
        }

        [Required]
        public int PosLeft
        {
            get { return Record.PosLeft; }
            set { Record.PosLeft = value; }
        }

        [Required]
        public string Color
        {
            get { return Record.Color; }
            set { Record.Color = value; }
        }
    }
}