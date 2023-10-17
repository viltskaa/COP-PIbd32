namespace Bazunov_Components.Models;

public class TableWithHeaderConfig<T> : DocumentConfig
{
    public (int Columns, int Rows) ColumnsRowsDataCount { get; set; }
    public List<(int Column, int Row)>? ColumnsRowsWidth { get; init; }
    public List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>? Headers { get; init; }
    public List<T>? Data { get; init; }
    public string NullReplace { get; set; } = "null";

    public void CheckFields()
    {
        if (Data == null || Data.Count == 0)
            throw new ArgumentNullException("No data");
        if (ColumnsRowsWidth is null || ColumnsRowsWidth.Count == 0)
            throw new ArgumentNullException("Rows width invalid");
        if (Headers is null || Headers.Count == 0)
            throw new ArgumentNullException("Header data invalid");
    }
}