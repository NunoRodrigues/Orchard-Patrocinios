using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.DisplayManagement;
using Orchard.Patrocinadores.Models;
using Orchard.Settings;
using Orchard.UI.Navigation;

namespace Orchard.Patrocinadores.Services
{
    public class PatrocinadoresService : IPatrocinadoresService
    {
        private IRepository<PatrocinadorRecord> _repository;
        private ISiteService _siteService;
        private dynamic _shapeFactory;

        public PatrocinadoresService(   IRepository<PatrocinadorRecord> repository
                                        , ISiteService siteService
                                        , IShapeFactory shapeFactory)
        {
            _repository = repository;
            _siteService = siteService;
            _shapeFactory = shapeFactory;
        }

        public List<PatrocinadorRecord> ListAll()
        {
            return _repository.Table.ToList();
        }

        public List<PatrocinadorRecord> List(PagerParameters pagerParameters, bool? status, string pesquisaLivre)
        {
            // The pager is used to apply paging on the query and to create a PagerShape
            var pager = new Pager(_siteService.GetSiteSettings(), pagerParameters.Page, pagerParameters.PageSize);

            IQueryable<PatrocinadorRecord> records = _repository.Table;

            if (!string.IsNullOrEmpty(pesquisaLivre))
            {
                records = records.Where(p => p.Nome.Contains(pesquisaLivre) || p.ContactoNome.Contains(pesquisaLivre) || p.ContactoTelefone.Contains(pesquisaLivre) || p.ContactoEmail.Contains(pesquisaLivre));
            }

            // Apply paging
            records = records.Skip(pager.GetStartIndex()).Take(pager.PageSize);

            // Construct a Pager shape
            var pagerShape = _shapeFactory.Pager(pager).TotalItemCount(records.Count());

            return records.ToList();
        }

        public PatrocinadorRecord GetById(int id)
        {
            return _repository.Table.FirstOrDefault(i => i.Id == id);
        }

        public void Update(PatrocinadorRecord record)
        {
            _repository.Update(record);
        }
    }
}