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
        creator.CreateMultiHeader<T>(config);
        string[,] array = new string[config.Data.Count, config.Headers.Count];
        for (int j = 0; j < config.Data.Count; j++)
        {
            int i;
            for (i = 0; i < config.Headers.Count; i++)
            {
                var (num, num2, text, name) = config.Headers.FirstOrDefault<(int, int, string, string)>(((int ColumnIndex, int RowIndex, string Header, string PropertyName) x) => x.ColumnIndex == i);
                array[j, i] = config.Data[j].GetType().GetProperty(name)!.GetValue(config.Data[j], null)!.ToString();
            }
        }

        creator.LoadDataToTableWithMultiHeader(array, config.ColumnsRowsWidth[1].Row);
        creator.SaveDoc(config.FilePath);
    }
}