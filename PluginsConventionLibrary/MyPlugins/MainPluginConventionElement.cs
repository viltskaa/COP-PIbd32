using PluginsConventionLibrary.Plugins;

namespace PluginsConventionLibrary.MyPlugins;

public class MainPluginConventionElement: PluginsConventionElement
{
    public string Fio { get; set; } = string.Empty;
    public int Experience { get; set; }
    public string Posts { get; set; } = string.Empty;
    public string Subdivision { get; set; } = string.Empty;
}