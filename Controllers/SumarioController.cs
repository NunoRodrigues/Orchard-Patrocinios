using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Orchard.ContentManagement;
using Orchard.Core.Title.Models;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.UI.Admin;
using Orchard.UI.Navigation;
using Orchard.Localization;

using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.Services;
using Orchard.Patrocinadores.ViewModels;

namespace Orchard.Patrocinadores.Controllers
{
    [Admin]
    public class SumarioController : Controller, IUpdateModel
    {
        private IPatrocinadoresService _patrocinadoresService;
        private IPatrocinioService _patrocinioService;
        private IPatrocinioWidgetTipo _tiposService;
        private dynamic Shape { get; set; }
        private IContentManager _manager;
        private IRepository<TitlePartRecord> _titlesList;

        public SumarioController(IPatrocinadoresService patrocinadoresService
                                , IPatrocinioService patrocinioService
                                , IPatrocinioWidgetTipo tiposService
                                , IShapeFactory shapeFactory
                                , IContentManager manager
                                , IRepository<TitlePartRecord> titlesList)
        {
            this._patrocinadoresService = patrocinadoresService;
            this._patrocinioService = patrocinioService;
            this._tiposService = tiposService;
            this.Shape = shapeFactory;
            this._manager = manager;
            this._titlesList = titlesList;
        }

        //
        // GET: /Sumario/
        public ActionResult Sumario(PagerParameters pagerParameters)
        {
            var model = new SumarioViewModel();

            DateTime now = DateTime.Now.Date;
            List<PatrocinioItemRecord> records = _patrocinioService.GetAll().Table.ToList();

            model.Sair = new Dictionary<FracaoTemporal, List<SumarioViewModelItem>>();
            addItem(model.Sair, FracaoTemporal.SemanaActual, records.Where(x => x.DataInicio <= now && x.DataFim >= now && x.DataFim.WeekNumber() - now.WeekNumber() >= 0 && x.DataFim.WeekNumber() - now.WeekNumber() < 1).ToList());
            addItem(model.Sair, FracaoTemporal.ProximaSemana, records.Where(x => x.DataInicio <= now && x.DataFim >= now && x.DataFim.WeekNumber() - now.WeekNumber() >= 1 && x.DataFim.WeekNumber() - now.WeekNumber() < 2).ToList());
            addItem(model.Sair, FracaoTemporal.Semanas2, records.Where(x => x.DataInicio <= now && x.DataFim >= now && x.DataFim.WeekNumber() - now.WeekNumber() >= 2 && x.DataFim.WeekNumber() - now.WeekNumber() < 3).ToList());
            addItem(model.Sair, FracaoTemporal.Semanas4, records.Where(x => x.DataInicio <= now && x.DataFim >= now && x.DataFim.WeekNumber() - now.WeekNumber() >= 3 && x.DataFim.WeekNumber() - now.WeekNumber() < 4).ToList());

            model.Entrar = new Dictionary<FracaoTemporal, List<SumarioViewModelItem>>();
            addItem(model.Entrar, FracaoTemporal.SemanaActual, records.Where(x => x.DataInicio.Year == now.Year && x.DataInicio.WeekNumber() - now.WeekNumber() >= 0 && x.DataInicio.WeekNumber() - now.WeekNumber() < 1).ToList());
            addItem(model.Entrar, FracaoTemporal.ProximaSemana, records.Where(x => x.DataInicio.Year == now.Year && x.DataInicio.WeekNumber() - now.WeekNumber() >= 1 && x.DataInicio.WeekNumber() - now.WeekNumber() < 2).ToList());
            addItem(model.Entrar, FracaoTemporal.Semanas2, records.Where(x => x.DataInicio.Year == now.Year && x.DataInicio.WeekNumber() - now.WeekNumber() >= 2 && x.DataInicio.WeekNumber() - now.WeekNumber() < 3).ToList());
            addItem(model.Entrar, FracaoTemporal.Semanas4, records.Where(x => x.DataInicio.Year == now.Year && x.DataInicio.WeekNumber() - now.WeekNumber() >= 3 && x.DataInicio.WeekNumber() - now.WeekNumber() < 4).ToList());
 
            return View(model);
        }

        private void addItem(Dictionary<FracaoTemporal, List<SumarioViewModelItem>> dic, FracaoTemporal key, List<PatrocinioItemRecord> items)
        {
            List<SumarioViewModelItem> list = new List<SumarioViewModelItem>();
            foreach (PatrocinioItemRecord item in items)
            {
                list.Add(new SumarioViewModelItem()
                {
                    Patrocinio = item,
                    Title = _titlesList.Table.First(x => x.Id == item.PatrociniosPartRecord_Id),
                    Tipo = _tiposService.GetById(item.PatrocinioWidgetTipoRecord_Id),
                    Patrocinador = item.PatrocinadorRecord
                });
            }
            dic.Add(key, list);
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
