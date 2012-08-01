using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Services
{
    public class PatrocinioWidgetTipoService : IPatrocinioWidgetTipo
    {
        private IRepository<PatrocinioWidgetTipoRecord> _repository;

        public PatrocinioWidgetTipoService(IRepository<PatrocinioWidgetTipoRecord> repository)
        {
            _repository = repository;
        }

        public IRepository<PatrocinioWidgetTipoRecord> GetAll()
        {
            return _repository;
        }

        public PatrocinioWidgetTipoRecord GetById(int id)
        {
            return _repository.Table.FirstOrDefault(x => x.Id == id);
        }
    }
}