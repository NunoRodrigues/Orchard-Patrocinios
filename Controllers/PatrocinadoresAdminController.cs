using System;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;

using Orchard;
using Orchard.ContentManagement;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Settings;
using Orchard.UI.Admin;
using Orchard.UI.Navigation;
using Orchard.Data;
using Orchard.ContentManagement.Records;
using Orchard.Core.Title.Models;

using Orchard.Patrocinadores.Services;
using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.ViewModels;
using Orchard.Patrocinadores.Handlers;

namespace Orchard.Patrocinadores.Controllers
{
    [Admin]
    public class PatrocinadoresAdminController : Controller, IUpdateModel
    {
        private IPatrocinadoresService _patrocinadoresService;
        private IPatrocinioService _patrocinioService;
        private dynamic Shape { get; set; }
        private IContentManager _manager;
        private IRepository<TitlePartRecord> _titlesList;

        public PatrocinadoresAdminController(   IPatrocinadoresService patrocinadoresService
                                                , IPatrocinioService patrocinioService
                                                , IShapeFactory shapeFactory
                                                , IContentManager manager
                                                , IRepository<TitlePartRecord> titlesList)
        {
            this._patrocinadoresService = patrocinadoresService;
            this._patrocinioService = patrocinioService;
            this.Shape = shapeFactory;
            this._manager = manager;
            this._titlesList = titlesList;
        }
        
        public ActionResult List(PagerParameters pagerParameters, PatrocinadoresListOptions options)
        {
            List<PatrocinadorRecord> records = _patrocinadoresService.List(pagerParameters, null, options.TextSearch);

            var model = new PatrocinadoresListViewModel()
            {
                Options = options,
                Patrocinadores = records
            };

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            PatrocinadorRecord val = _patrocinadoresService.GetById(id);

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

            _patrocinadoresService.Update(viewModel.Record);

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
