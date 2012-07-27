using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.Services;

namespace Orchard.Patrocinadores.Drivers
{
    public class PatrociniosDriver : ContentPartDriver<PatrociniosPart>
    {
        private IPatrocinadoresService _patrocinadoresService;

        public PatrociniosDriver(IPatrocinadoresService patrocinadoresService)
        {
            _patrocinadoresService = patrocinadoresService;
        }

        protected override DriverResult Display(PatrociniosPart part, string displayType, dynamic shapeHelper)
        {
            part.Patrocinadores = _patrocinadoresService.ListAll();

            return ContentShape("Parts_Patrocinios", () => shapeHelper.Parts_Patrocinios(Patrocinios: part.CurrentPatrocinios, Patrocinadores: _patrocinadoresService.ListAll()));
        }

        //GET
        protected override DriverResult Editor(PatrociniosPart part, dynamic shapeHelper)
        {
            if (part.Id > 0)
            {
                part.Patrocinadores = _patrocinadoresService.ListAll();

                return ContentShape("Parts_Patrocinios_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Patrocinios", Model: part, Prefix: Prefix));
            }
            else
            {
                return null;
            }
        }

        //POST
        protected override DriverResult Editor(PatrociniosPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}