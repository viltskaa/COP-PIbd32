using Bazunov_Components.Helpers;
using Bazunov_Components.Models;
using System.ComponentModel;

namespace Bazunov_Components;

public partial class ExcelTable : Component
{
    public ExcelTable()
    {
        InitializeComponent();
    }

    public ExcelTable(IContainer container)
    {
        container.Add(this);
        InitializeComponent();
    }

    public void CreateDoc(TableConfig config)
    {
        config.CheckFields();
        IContext creator = new WorkWithExcel();
        creator.CreateHeader(config.Header);
        if (config.Data != null)
            foreach (var datum in config.Data)
            {
                creator.CreateTable(datum);
            }

        creator.SaveDoc(config.FilePath);
    }
}