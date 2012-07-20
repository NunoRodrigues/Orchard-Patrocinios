using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Services
{
    public interface IPatrocinadoresService : IDependency
    {
        IContentQuery<PatrocinadorPart> GetPatrocinadores();
    }
}