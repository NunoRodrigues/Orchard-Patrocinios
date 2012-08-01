using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Services
{
    public interface IPatrocinioWidgetTipo : IDependency
    {
        IRepository<PatrocinioWidgetTipoRecord> GetAll();
        PatrocinioWidgetTipoRecord GetById(int id);
    }
}