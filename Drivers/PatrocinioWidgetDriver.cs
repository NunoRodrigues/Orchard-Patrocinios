using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Data;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Drivers
{
    public class PatrocinioWidgetDriver : ContentPartDriver<PatrocinioWidgetPart>
    {
        private IRepository<PatrocinioWidgetTipoRecord> _tipos;

        public PatrocinioWidgetDriver(IRepository<PatrocinioWidgetTipoRecord> tipos)
        {
            _tipos = tipos;
        }

        protected override DriverResult Display(PatrocinioWidgetPart part, string displayType, dynamic shapeHelper)
        {
            part.WidgetTipoRecord = _tipos.Table.ToList();
            
            return ContentShape("Parts_PatrocinioWidget", () => shapeHelper.Parts_PatrocinioWidget(Width: part.Width, Height: part.Height));
        }

        //GET
        protected override DriverResult Editor(PatrocinioWidgetPart part, dynamic shapeHelper)
        {
            part.WidgetTipoRecord = _tipos.Table.ToList();

            return ContentShape("Parts_PatrocinioWidget_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/PatrocinioWidget", Model: part, Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(PatrocinioWidgetPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}