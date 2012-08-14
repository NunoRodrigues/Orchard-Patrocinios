using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.Services;
using Orchard.Patrocinadores.ViewModels;

namespace Orchard.Patrocinadores.Drivers
{
    public class PatrociniosDriver : ContentPartDriver<PatrociniosPart>
    {
        private IPatrocinadoresService _patrocinadoresService;
        private IPatrocinioWidgetTipo _tiposService;

        public PatrociniosDriver(IPatrocinadoresService patrocinadoresService, IPatrocinioWidgetTipo tiposService)
        {
            _patrocinadoresService = patrocinadoresService;
            _tiposService = tiposService;
        }

        protected override DriverResult Display(PatrociniosPart part, string displayType, dynamic shapeHelper)
        {
            if (displayType != "Detail")
            {
                
                Dictionary<PatrocinioWidgetTipoRecord, PatrocinioItemRecord> items = new Dictionary<PatrocinioWidgetTipoRecord, PatrocinioItemRecord>();
                DateTime now = DateTime.Now.Date;

                foreach (PatrocinioWidgetTipoRecord item in _tiposService.GetAll().Table)
                {
                    items.Add(item, part.CurrentPatrocinios.FirstOrDefault(x => x.PatrocinioWidgetTipoRecord_Id == item.Id && x.DataInicio <= now && x.DataFim >= now));
                }

                return ContentShape("Parts_Patrocinios", () => shapeHelper.Parts_Patrocinios(Items: items));
            }

            return null;
        }

        //GET
        protected override DriverResult Editor(PatrociniosPart part, dynamic shapeHelper)
        {
            if (part.Id > 0)
            {
                PatrociniosAdminEditViewModel viewModel = new PatrociniosAdminEditViewModel()
                {
                    Tipos = _tiposService.GetAll().Table.ToList(),
                    Patrocinadores = _patrocinadoresService.GetAll().Table.ToList(),
                    Part = part
                };

                return ContentShape("Parts_Patrocinios_Edit", () => shapeHelper.EditorTemplate(TemplateName: "Parts/Patrocinios", Model: viewModel, Prefix: Prefix));
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