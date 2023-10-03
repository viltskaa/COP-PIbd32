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
}