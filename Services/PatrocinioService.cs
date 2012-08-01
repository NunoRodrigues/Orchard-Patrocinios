using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Services
{
    public class PatrocinioService : IPatrocinioService
    {
        private IRepository<PatrocinioItemRecord> _repository;

        public PatrocinioService(IRepository<PatrocinioItemRecord> repository)
        {
            _repository = repository;
        }

        public IRepository<PatrocinioItemRecord> GetAll()
        {
            return _repository;
        }

        public List<Models.PatrocinioItemRecord> List(int modelId)
        {
            return _repository.Table.Where(x => x.PatrociniosPartRecord_Id == modelId).ToList();
        }

        public void Update(Models.PatrocinioItemRecord record)
        {
            _repository.Update(record);
        }
    }
}