using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.Core.Navigation;
using Orchard.Localization;
using Orchard.UI.Navigation;

namespace Orchard.Patrocinadores
{
    public class AdminMenu : INavigationProvider
    {
        public Localizer T { get; set; }

        public string MenuName { get { return "admin"; } }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder

                // Image set
                .AddImageSet("patrocinadores")

                // "Webshop"
                .Add(item => item

                    .Caption(T("Patrocínios"))
                    .Position("1")
                    .LinkToFirstChild(true)

                    // "Customers"
                    .Add(subItem => subItem
                        .Caption(T("Sumário"))
                        .Position("1.1")
                        .Action("Sumario", "PatrocinadoresAdmin", new { area = "Patrocinadores" })
                    )

                    // "Orders"
                    .Add(subItem => subItem
                        .Caption(T("Patrocinadores"))
                        .Position("1.2")
                        .Action("Index", "PatrocinadoresAdmin", new { area = "Patrocinadores" })
                    )
                );
        }
    }
}