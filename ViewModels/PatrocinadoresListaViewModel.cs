using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.ViewModels
{
    public class PatrocinadoresListaViewModel
    {
        public IList<dynamic> Patrocinadores { get; set; }
    }
}