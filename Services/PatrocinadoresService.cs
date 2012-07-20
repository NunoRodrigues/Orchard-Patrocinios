using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JetBrains.Annotations;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Logging;
using Orchard.Services;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Services
{
    [UsedImplicitly]
    public class PatrocinadoresService : IPatrocinadoresService
    {
        private readonly IClock _clock;
        private readonly IOrchardServices _orchardServices;

        public PatrocinadoresService(IClock clock,
                              IOrchardServices orchardServices) {
            _clock = clock;
            _orchardServices = orchardServices;
            Logger = NullLogger.Instance;
        }

        public ILogger Logger { get; set; }

        public IContentQuery<PatrocinadorPart> GetPatrocinadores()
        {
            return _orchardServices.ContentManager.Query<PatrocinadorPart, PatrocinadorRecord>();
        }
    }
}