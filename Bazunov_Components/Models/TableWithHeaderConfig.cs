using System.Linq;

namespace Bazunov_Components.Models
{
    public class TableWithHeaderConfig<T> : DocumentConfig
    {
        public (int Columns, int Rows) ColumnsRowsDataCount { get; set; }
        public List<(int Column, int Row)> ColumnsRowsWidth { get; set; }
        public List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)> Headers { get; set; }
        public List<T> Data { get; set; }

        public void CheckFields()
        {
            if (Data == null || Data.Count == 0)
                throw new ArgumentNullException("No data");
            if (ColumnsRowsDataCount.Rows == 0 || ColumnsRowsDataCount.Columns == 0)
                throw new ArgumentException("Rows or Columns count is zero");
            if (ColumnsRowsWidth is null || ColumnsRowsWidth.Count == 0)
                throw new ArgumentNullException("Rows width invalid");
            if (Headers is null || Headers.Count == 0)
                throw new ArgumentNullException("Header data invalid");
        }
    }
}
