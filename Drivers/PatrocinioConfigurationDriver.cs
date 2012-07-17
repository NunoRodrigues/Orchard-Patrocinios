using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

using Patrocinadores.Models;

namespace Patrocinadores.Drivers
{
    public class PatrocinioConfigurationDriver : ContentPartDriver<PatrocinioConfigurationPart>
    {
        protected override DriverResult Display(PatrocinioConfigurationPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PatrocinioConfiguration", () => shapeHelper.Parts_PatrocinioConfiguration(IDTipo: part.IDTipo, IDPatrocinador: part.IDPatrocinador, URLImage: part.URLImage));
        }

        //GET
        protected override DriverResult Editor(PatrocinioConfigurationPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PatrocinioConfiguration_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/PatrocinioConfiguration", Model: part, Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(PatrocinioConfigurationPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}