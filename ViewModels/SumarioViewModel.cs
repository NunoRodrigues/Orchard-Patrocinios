using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Core.Title.Models;
using Orchard.Patrocinadores.Models;

namespace Orchard.Patrocinadores.ViewModels
{
    public class SumarioViewModel
    {
        #region Incompletos (Não tem patrocinio)

        public Dictionary<FracaoTemporal, List<SumarioViewModelItem>> Incompletos { get; set; }
        
        #endregion

        #region A Sair (publicidade)

        public Dictionary<FracaoTemporal, List<SumarioViewModelItem>> Sair { get; set; }

        #endregion

        #region A Entrar (publicidade)

        public Dictionary<FracaoTemporal, List<SumarioViewModelItem>> Entrar { get; set; }

        #endregion
    }

    public enum FracaoTemporal {
        SemanaActual,
        ProximaSemana,
        Semanas2,
        Semanas4,
    }

    public class SumarioViewModelItem
    {
        public TitlePartRecord Title { get; set; }
        public PatrocinioItemRecord Patrocinio { get; set; }
        public PatrocinioWidgetTipoRecord Tipo { get; set; }
        public PatrocinadorRecord Patrocinador { get; set; }

        public bool Urgent { get; set; }
    }
}