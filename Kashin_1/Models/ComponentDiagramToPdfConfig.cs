using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Models
{
    public class ComponentDiagramToPdfConfig : ComponentDocumentConfig
    {
        public string ChartTitle
        {
            get;
            set;
        }

        public Location LegendLocation
        {
            get;
            set;
        }

        public Dictionary<string, List<(string Name, double Value)>> Data
        {
            get;
            set;
        }
    }
}
