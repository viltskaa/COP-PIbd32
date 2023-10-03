using Bazunov_Components.Helpers;
using Bazunov_Components.Models;
using System.ComponentModel;

namespace Bazunov_Components;

public partial class ExcelGistogram : Component
{
    public ExcelGistogram()
    {
        InitializeComponent();
    }

    public ExcelGistogram(IContainer container)
    {
        container.Add(this);
        InitializeComponent();
    }

    public void CreateDoc(ChartConfig config)
    {
        config.CheckFields();
        IContext creator = new WorkWithExcel();
        creator.CreateHeader(config.Header);
        creator.CreateBarChart(config);
        creator.SaveDoc(config.FilePath);
    }
}