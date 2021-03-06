﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Data;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.Services
{
    public interface IPatrocinioService : IDependency
    {
        IRepository<PatrocinioItemRecord> GetAll();
        List<PatrocinioItemRecord> List(int modelId);
        void Update(PatrocinioItemRecord record);
    }
}