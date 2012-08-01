using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Data;
using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.Services;

namespace Orchard.Patrocinadores.Drivers
{
    public class PatrocinioWidgetDriver : ContentPartDriver<PatrocinioWidgetPart>
    {
        public IOrchardServices Services { get; set; }
        private IPatrocinioWidgetTipo _tiposSrv;
        private IPatrocinioService _itemsSrv;
        private IPartWatcher _partsWatcher;

        public PatrocinioWidgetDriver(IOrchardServices services, IPatrocinioWidgetTipo tipos, IPatrocinioService itemsSrv, IPartWatcher xpto)
        {
            Services = services;
            _tiposSrv = tipos;
            _partsWatcher = xpto;
            _itemsSrv = itemsSrv;
        }

        protected override DriverResult Display(PatrocinioWidgetPart part, string displayType, dynamic shapeHelper)
        {
            DateTime date = DateTime.Now;
            IContent page = _partsWatcher.CurrentPage();
            IEnumerable<PatrocinioItemRecord> bannerList = _itemsSrv.List(page.Id).Where(x => x.PatrocinioWidgetTipoRecord_Id == part.PatrocinioWidgetTipoRecord_Id && x.DataInicio <= date && x.DataFim >= date);

            if (bannerList != null && bannerList.Count() > 0)
            {
                PatrocinioItemRecord banner = bannerList.First();

                return ContentShape("Parts_PatrocinioWidget", () => shapeHelper.Parts_PatrocinioWidget(Width: part.Width, Height: part.Height, ImageURL: banner.URLImage, ExternalLink: banner.ExternalLink));
            }
            else
            {
                return null;
            }
        }

        //GET
        protected override DriverResult Editor(PatrocinioWidgetPart part, dynamic shapeHelper)
        {
            part.WidgetTipoRecord = _tiposSrv.GetAll().Table.ToList();

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