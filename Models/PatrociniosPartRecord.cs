using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Patrocinadores.Models
{
    public class PatrociniosPartRecord : ContentPartRecord {
        public PatrociniosPartRecord()
        {
            Patrocinios = new List<PatrocinioItemRecord>();
        }

        [Aggregate]
        public virtual IList<PatrocinioItemRecord> Patrocinios { get; set; }
    }
}