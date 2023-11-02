using PluginsConventionLibrary.Plugins;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition;

namespace Bazunov_application
{
    public class PluginsManager
    {
        [ImportMany(typeof(IPluginsConvention))]
        IEnumerable<IPluginsConvention> Plugins { get; set; }

        public readonly Dictionary<string, IPluginsConvention> plugins_dictionary = new();

        public PluginsManager()
        {
            AggregateCatalog catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory));
            catalog.Catalogs.Add(new DirectoryCatalog(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins")));

            //Контейнер композиции
            CompositionContainer container = new CompositionContainer(catalog);
            try
            {
                container.ComposeParts(this);
            }
            catch (CompositionException compositionException)
            {
                MessageBox.Show(compositionException.ToString());
            }
            if (Plugins.Any())
            {
                Plugins
                    .ToList()
                    .ForEach(p =>
                    {
                        if (!plugins_dictionary.Keys.Contains(p.PluginName))
                            plugins_dictionary.Add(p.PluginName, p);
                    });
            }
        }
    }
}
