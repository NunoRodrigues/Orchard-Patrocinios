using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.UI.Resources;

namespace Orchard.Patrocinadores
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            
            //Styles
            manifest.DefineStyle("Patrocionadores_Calendar").SetUrl("fullcalendar.css");
            manifest.DefineStyle("Patrocionadores_CalendarPrint").SetUrl("fullcalendar.print.css").SetDependencies("Patrocionadores_Calendar");
            manifest.DefineStyle("Patrocionadores_LocationWidget").SetUrl("location.css");
            
            //Scripts
            manifest.DefineScript("Patrocionadores_Calendar").SetUrl("fullcalendar.min.js").SetDependencies("jQuery", "jQueryUI_Core", "jQueryUI_Widget", "jQueryUI_Dialog");
            manifest.DefineScript("Patrocionadores_Location").SetUrl("location.js").SetDependencies("Patrocionadores_Calendar");
        }
    }
}