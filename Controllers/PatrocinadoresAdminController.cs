using System;
using System.Linq;
using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Settings;
using Orchard.UI.Admin;
using Orchard.UI.Navigation;
using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.ViewModels;
using Orchard.Data;
using Orchard.Patrocinadores.Handlers;
using System.Collections.Generic;
using Orchard.Patrocinadores.Services;

namespace Orchard.Patrocinadores.Controllers
{
    [Admin]
    public class PatrocinadoresAdminController : Controller, IUpdateModel
    {
        private IPatrocinadoresService _dataService;
        private readonly ISiteService _siteService;
        private dynamic Shape { get; set; }
        //private readonly IContentManager _contentManager;
        //private readonly ITransactionManager _transactionManager;

        //public IOrchardServices Services { get; set; }
        //public ILogger Logger { get; set; }
        //public Localizer T { get; set; }

        public PatrocinadoresAdminController(   IPatrocinadoresService patrocinadoresService
                                                , ISiteService siteService
                                                , IShapeFactory shapeFactory)
        {
            this._dataService = patrocinadoresService;
            this._siteService = siteService;
            this.Shape = shapeFactory;
        }
        
        public ActionResult List(PagerParameters pagerParameters, PatrocinadoresListOptions options)
        {
            List<PatrocinadorRecord> records = _dataService.List(pagerParameters, null, options.TextSearch);

            var model = new PatrocinadoresListViewModel()
            {
                Options = options,
                Patrocinadores = records
            };

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            PatrocinadorRecord val = _dataService.GetById(id);

            var model = new PatrocinadoresEditViewModel()
            {
                Record = val
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PagerParameters pagerParameters, FormCollection input)
        {
            var viewModel = new PatrocinadoresEditViewModel();
            UpdateModel(viewModel);

            _dataService.Update(viewModel.Record);

            return RedirectToAction("List");
        }

        public ActionResult Create()
        {
            PatrocinadoresEditViewModel model = new PatrocinadoresEditViewModel()
            {
                Record = new PatrocinadorRecord()
            };

            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Create(PagerParameters pagerParameters, FormCollection input)
        {
            return Edit(pagerParameters, input);
        }

        public JsonResult GetResults()
        {
            var json = DateTime.Now.ToString();
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        bool IUpdateModel.TryUpdateModel<TModel>(TModel model, string prefix, string[] includeProperties, string[] excludeProperties)
        {
            return TryUpdateModel(model, prefix, includeProperties, excludeProperties);
        }

        void IUpdateModel.AddModelError(string key, LocalizedString errorMessage)
        {
            ModelState.AddModelError(key, errorMessage.ToString());
        }
    }

    
}
