﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Patrocinadores.Models;

namespace Patrocinadores.Handlers
{
    public class PatrocinioAdminHandler : ContentHandler
    {
        public PatrocinioAdminHandler(IRepository<PatrocinioAdminRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }

        protected override void BuildDisplayShape(BuildDisplayContext context)
        {
            base.BuildDisplayShape(context);
        }
    }
}