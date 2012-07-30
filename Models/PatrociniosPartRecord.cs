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
        public PatrociniosPartRecord()
        {
            Patrocinios = new List<PatrocinioItemRecord>();
        }

        [Aggregate]
        public virtual IList<PatrocinioItemRecord> Patrocinios { get; set; }
    }

    public class PatrociniosPart : ContentPart<PatrociniosPartRecord>
    {
        private List<PatrocinadorRecord> _patrocinadores = null;
        public List<PatrocinadorRecord> Patrocinadores
        {
            get { return _patrocinadores; }
            set { _patrocinadores = value; }
        }

        public IEnumerable<PatrocinioItemRecord> CurrentPatrocinios { get { return Record.Patrocinios; } }
    }
}