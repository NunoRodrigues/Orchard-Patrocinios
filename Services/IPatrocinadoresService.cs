using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.Patrocinadores.Models;
using Orchard.UI.Navigation;

namespace Orchard.Patrocinadores.Services
{
    public interface IPatrocinadoresService : IDependency
    {
        IRepository<PatrocinadorRecord> GetAll();
        PatrocinadorRecord GetById(int id);
        List<PatrocinadorRecord> List(PagerParameters pagerParameters, bool? status, string pesquisaLivre);
        void Update(PatrocinadorRecord record);
    }
}