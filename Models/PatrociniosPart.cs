using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;

namespace Orchard.Patrocinadores.Models
{
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