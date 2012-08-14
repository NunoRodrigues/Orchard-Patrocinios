using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.ViewModels
{
    public class PatrociniosAdminEditViewModel
    {
        public List<PatrocinioWidgetTipoRecord> Tipos { get; set; }
        public List<PatrocinadorRecord> Patrocinadores { get; set; }
        public PatrociniosPart Part { get; set; }
    }
}