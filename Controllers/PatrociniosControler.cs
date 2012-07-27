using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orchard.ContentManagement;
using Orchard.Localization;
using Orchard.Patrocinadores.Models;
using Orchard.Patrocinadores.Services;
using Orchard.UI.Admin;
using Orchard.UI.Notify;

namespace Orchard.Patrocinadores.Controllers
{
    [Admin]
    /// TODO: Passar as chamadas JSON para POST
    public class PatrociniosControler : Controller, IUpdateModel
    {
        private readonly INotifier _notifier;

        private IPatrocinioService _service;
        private IPatrocinadoresService _srvPatrocinadores;

        public PatrociniosControler(    INotifier notifier,
                                        IPatrocinioService service,
                                        IPatrocinadoresService srvPatrocinadores)
        {

            _notifier = notifier;

            _service = service;
            _srvPatrocinadores = srvPatrocinadores;

            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public JsonResult List(int modelId)
        {
            return Json(_service.List(modelId));
        }

        [HttpPost]
        public JsonResult Save(PatrocinioItemRecord data, int patrocinadorID)
        {
            // Part - Validação
            if (!(data.PatrociniosPartRecord_Id > 0))
            {
                _notifier.Error(T("Patrocinios não foram gravados. (Part não pode estar vazio)"));
                return Json(false, JsonRequestBehavior.AllowGet);
            }


            // Patrocinador
            data.PatrocinadorRecord = _srvPatrocinadores.GetById(patrocinadorID);

            // Patrocinador - Validação
            if (data.PatrocinadorRecord == null)
            {
                //_notifier.Error(T("Patrocinios não foram gravados. (Patrocinador não pode estar vazio)"));
                //return Json(false, JsonRequestBehavior.AllowGet);
            }


            // Gravar
            _service.Update(data);

            return Json(true, JsonRequestBehavior.AllowGet);
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