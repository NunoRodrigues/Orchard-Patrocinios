using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using Orchard.Data.Conventions;

namespace Orchard.Patrocinadores.Models
{
    public class PatrociniosPartRecord : ContentPartRecord {

        [Aggregate]
        public virtual IList<PatrocinioItemRecord> Patrocinios { get; set; }
    }

    public class PatrociniosPart : ContentPart<PatrociniosPartRecord>
    {
        public IEnumerable<PatrocinioItemRecord> CurrentPatrocinios { get { return Record.Patrocinios; } }
    }
}