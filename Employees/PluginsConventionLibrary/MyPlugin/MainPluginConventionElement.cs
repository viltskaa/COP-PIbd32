using PluginsConventionLibrary.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsConventionLibrary.MyPlugin
{
    public class MainPluginConventionElement : PluginsConventionElement
    {
        public string Name { get; set; }

        public string Autobiography { get; set; }

        public string Post { get; set; }

        public DateTime? Upgrade { get; set; }
    }
}
