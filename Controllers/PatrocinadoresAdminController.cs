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
using Orchard.Patrocinadores.Services;
using Orchard.Patrocinadores.ViewModels;

namespace Orchard.Patrocinadores.Controllers
{
    [Admin]
    //http://skywalkersoftwaredevelopment.net/blog/writing-an-orchard-webshop-module-from-scratch-part-10
    public class PatrocinadoresAdminController : Controller
    {
        private readonly IPatrocinadoresService _customerService;
        private readonly ISiteService _siteService;

        public IOrchardServices Services { get; set; }
        public ILogger Logger { get; set; }
        public Localizer T { get; set; }
        dynamic Shape { get; set; }

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

        public ActionResult Index(PagerParameters pagerParameters, PatrocinadoresListaOptions options)
        {

            // Create a basic query that selects all customer content items, joined with the UserPartRecord table
            var customerQuery = _customerService.GetPatrocinadores().List(); //.Join<UserPartRecord>()

            // If the user specified a search expression, update the query with a filter
            if (!string.IsNullOrWhiteSpace(options.TextSearch))
            {

                var expression = options.TextSearch.Trim();

                customerQuery = from patrocinador in customerQuery
                                where
                                    1==1
                                    //patrocinador.Nome.Contains(expression, StringComparison.InvariantCultureIgnoreCase) ||
                                    //patrocinador.ContactoNome.Contains(expression, StringComparison.InvariantCultureIgnoreCase) 
                                    //|| customer.As<UserPart>().Email.Contains(expression)
                                select patrocinador;
            }

            // Project the query into a list of customer shapes
            var customersProjection = from patrocinador in customerQuery
                                      select Shape.Customer
                                      (
                                        Id: patrocinador.Id,
                                        Nome: patrocinador.Nome,
                                        ContactoNome: patrocinador.ContactoNome,
                                        ContactoEmail: patrocinador.ContactoEmail,
                                        ContactoTelefone: patrocinador.ContactoTelefone
                                      );

            // The pager is used to apply paging on the query and to create a PagerShape
            var pager = new Pager(_siteService.GetSiteSettings(), pagerParameters.Page, pagerParameters.PageSize);

            // Apply paging
            var customers = customersProjection.Skip(pager.GetStartIndex()).Take(pager.PageSize);

            // Construct a Pager shape
            var pagerShape = Shape.Pager(pager).TotalItemCount(customerQuery.Count());

            // Create the viewmodel
            var model = new PatrocinadoresListaViewModel()
                {
                    Patrocinadores = customers.ToList()
                };

            return View(model);
        }
    }

    
}
