using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Patrocinadores.Models
{
    public class PatrocinioAdminRecord : ContentPartRecord
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
    }

    public class PatrocinioAdminPart : ContentPart<PatrocinioAdminRecord>
    {
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
    }
}