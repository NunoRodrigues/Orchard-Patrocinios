using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Orchard.Patrocinadores.Models
{
    public class PatrocinioWidgetRecord : ContentPartRecord
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual int PatrocinioWidgetTipoRecord_Id { get; set; }
    }

    public class PatrocinioWidgetPart : ContentPart<PatrocinioWidgetRecord>
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

        public int PatrocinioWidgetTipoRecord_Id
        {
            get { return Record.PatrocinioWidgetTipoRecord_Id; }
            set { Record.PatrocinioWidgetTipoRecord_Id = value; }
        }

        private List<PatrocinioWidgetTipoRecord> _WidgetTipoRecord = null;
        public List<PatrocinioWidgetTipoRecord> WidgetTipoRecord
        {
            get { return _WidgetTipoRecord; }
            set { _WidgetTipoRecord = value; }
        }
    }
}