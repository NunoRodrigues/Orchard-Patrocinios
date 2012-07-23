using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Handlers
{
    public class PatrocinioWidgetHandler : ContentHandler
    {
        public PatrocinioWidgetHandler(IRepository<PatrocinioWidgetRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }

        protected override void BuildDisplayShape(BuildDisplayContext context)
        {
            base.BuildDisplayShape(context);
        }
    }
}