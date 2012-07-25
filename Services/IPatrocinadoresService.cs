using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Patrocinadores.Models;
using Orchard.UI.Navigation;

namespace Orchard.Patrocinadores.Services
{
    public interface IPatrocinadoresService : IDependency
    {
        List<PatrocinadorRecord> ListAll();
        List<PatrocinadorRecord> List(PagerParameters pagerParameters, bool? status, string pesquisaLivre);
        PatrocinadorRecord GetById(int id);
        void Update(PatrocinadorRecord record);
    }
}