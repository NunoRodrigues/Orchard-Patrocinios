using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

using Patrocinadores.Models;

namespace Patrocinadores.Drivers
{
    public class PatrocinioAdminDriver : ContentPartDriver<PatrocinioAdminPart>
    {
        protected override DriverResult Display(PatrocinioAdminPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_PatrocinioAdmin", () => shapeHelper.Parts_PatrocinioAdmin(Width: part.Width, Height: part.Height));
        }

        //GET
        protected override DriverResult Editor(PatrocinioAdminPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_PatrocinioAdmin_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/PatrocinioAdmin", Model: part, Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(PatrocinioAdminPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}