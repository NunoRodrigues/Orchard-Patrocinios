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

namespace Orchard.Patrocinadores.Controllers
{
    [Admin]
    public class PatrocinadoresAdminController : Controller, IUpdateModel
    {
        /*
        //private readonly IPatrocinadoresService _customerService;
        private readonly IContentManager _contentManager;
        private readonly ITransactionManager _transactionManager;
        

        public IOrchardServices Services { get; set; }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
        

        public PatrocinadoresAdminController(
            IOrchardServices services,
            IContentManager contentManager,
            ITransactionManager transactionManager,
            ISiteService siteService,
            IShapeFactory shapeFactory
            ) { //IPatrocinadoresService patrocinadoresService
            Services = services;
            _contentManager = contentManager;
            _transactionManager = transactionManager;
            _siteService = siteService;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
            //_customerService = patrocinadoresService;
        }
        */

        private readonly ISiteService _siteService;
        private IRepository<PatrocinadorRecord> _repository;
        private dynamic Shape { get; set; }

        public PatrocinadoresAdminController(   IRepository<PatrocinadorRecord> repository
                                                , ISiteService siteService
                                                , IShapeFactory shapeFactory)
        {
            this._repository = repository;
            this._siteService = siteService;
            this.Shape = shapeFactory;
        }

        /*
        public PatrocinadoresAdminController(
            IOrchardServices services,
            IPatrocinadoresService patrocinadoresService, 
            ISiteService siteService,
            IShapeFactory shapeFactory) {
                _customerService = patrocinadoresService;
            _siteService = siteService;
            Services = services;
            Logger = NullLogger.Instance;
            T = NullLocalizer.Instance;
            Shape = shapeFactory;
        }
        */

        
        public ActionResult List(PagerParameters pagerParameters, PatrocinadoresListOptions options)
        {
            // The pager is used to apply paging on the query and to create a PagerShape
            var pager = new Pager(_siteService.GetSiteSettings(), pagerParameters.Page, pagerParameters.PageSize);

            IQueryable<PatrocinadorRecord> records = _repository.Table;

            if (!string.IsNullOrEmpty(options.TextSearch))
            {
                records = records.Where(p => p.Nome.Contains(options.TextSearch) || p.ContactoNome.Contains(options.TextSearch) || p.ContactoTelefone.Contains(options.TextSearch) || p.ContactoEmail.Contains(options.TextSearch));
            }

            // Apply paging
            records = records.Skip(pager.GetStartIndex()).Take(pager.PageSize);

            // Construct a Pager shape
            var pagerShape = Shape.Pager(pager).TotalItemCount(records.Count());

            var model = new PatrocinadoresListViewModel()
            {
                Pager = pagerShape,
                Options = options,
                Patrocinadores = records.ToList()
            };

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = new PatrocinadoresEditViewModel()
            {
                Record = _repository.Table.FirstOrDefault(i => i.Id == id)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PagerParameters pagerParameters, FormCollection input)
        {
            var viewModel = new PatrocinadoresEditViewModel();
            UpdateModel(viewModel);

            _repository.Update(viewModel.Record);

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
