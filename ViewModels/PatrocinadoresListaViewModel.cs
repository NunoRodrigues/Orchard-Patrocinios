using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.ViewModels
{
    public class PatrocinadoresListViewModel
    {
        public dynamic Pager { get; set; }
        public PatrocinadoresListOptions Options { get; set; }
        public List<PatrocinadorRecord> Patrocinadores { get; set; }
    }
}