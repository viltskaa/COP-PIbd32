using Bazunov_Components.Helpers;
using Bazunov_Components.Models;
using System.ComponentModel;

namespace Bazunov_Components;

public partial class ExcelWithCustomTable : Component
{
    public ExcelWithCustomTable()
    {
        InitializeComponent();
    }

    public ExcelWithCustomTable(IContainer container)
    {
        container.Add(this);
        InitializeComponent();
    }

    public void CreateDoc<T>(TableWithHeaderConfig<T> config)
    {
        config.CheckFields();
        config.ColumnsRowsDataCount = (config.ColumnsRowsWidth.Count, config.Data.Count + 1);
        IContext creator = new WorkWithExcel();
        creator.CreateHeader(config.Header);
        creator.CreateTableWithHeader();
        creator.CreateMultiHeader(config);
        var array = new string[config.Data.Count, config.Headers.Count];
        for (var j = 0; j < config.Data.Count; j++)
        {
            for (var i = 0; i < config.Headers.Count; i++)
            {
                (int, int, string, string) first = (0, 0, null, null)!;
                foreach (var x in config.Headers.Where(x => x.ColumnIndex == i))
                {
                    first = x;
                    break;
                }

                var (_, _, _, name) = first;
                if (name != null)
                {
                    object? value = config.Data[j]?.GetType().GetProperty(name)!.GetValue(config.Data[j], null);
                    array[j, i] = value == null 
                        ? config.NullReplace 
                        : value.ToString();
                }
            }
        }

        creator.LoadDataToTableWithMultiHeader(array, config.ColumnsRowsWidth[1].Row);
        creator.SaveDoc(config.FilePath);
    }
}