using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Orchard.Patrocinadores.ViewModels
{
    public class PatrocinadoresListOptions
    {
        public string TextSearch { get; set; }
        public PatrocinadoresStatus Status { get; set; }
    }

    public enum PatrocinadoresStatus {
        Todos,
        ComAnunciosActivos,
        SemAnunciosActivos
    }
}