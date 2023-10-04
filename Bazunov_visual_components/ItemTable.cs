namespace Bazunov_VisualComponents
{
    public partial class ItemTable : UserControl
    {
        public ItemTable()
        {
            InitializeComponent();
        }

        public int SelectedRow
        {
            get { return DataGridViewItems.SelectedRows[0].Index; }
            set
            {
                if (DataGridViewItems.SelectedRows.Count <= value || value < 0)
                    throw new ArgumentException(string.Format("{0} is an invalid row index.", value));
                else
                {
                    DataGridViewItems.ClearSelection();
                    DataGridViewItems.Rows[value].Selected = true;
                }
            }
        }

        public void ClearDataGrid()
        {
            DataGridViewItems.DataSource = null;
            DataGridViewItems.Rows.Clear();
        }

        public void ConfigColumn(ColumnsConfiguratoin columnsData)
        {
            DataGridViewItems.ColumnCount = columnsData.ColumnsCount;
            for (int i = 0; i < columnsData.ColumnsCount; i++)
            {
                DataGridViewItems.Columns[i].Name = columnsData.NameColumn[i];
                DataGridViewItems.Columns[i].Width = columnsData.Width[i];
                DataGridViewItems.Columns[i].Visible = columnsData.Visible[i];
                DataGridViewItems.Columns[i].DataPropertyName = columnsData.PropertiesObject[i];
            }
        }

        public T GetSelectedObjectInRow<T>() where T : class, new()
        {
            T val = new T();

            var propertiesObj = typeof(T).GetProperties();
            foreach (var properties in propertiesObj)
            {
                bool propIsExist = false;
                int columnIndex = 0;
                for (; columnIndex < DataGridViewItems.Columns.Count; columnIndex++)
                {
                    if (DataGridViewItems.Columns[columnIndex].DataPropertyName.ToString() == properties.Name)
                    {
                        propIsExist = true;
                        break;
                    }
                }
                if (!propIsExist) { throw new Exception($"Property: {properties.Name} isn't found!"); };
                object value = DataGridViewItems.SelectedRows[0].Cells[columnIndex].Value;
                properties.SetValue(val, Convert.ChangeType(value, properties?.PropertyType));
            }

            return val;
        }

        public void AddItem<T>(T item, int RowIndex, int ColumnIndex)
        {
            if (item == null)
                return;

            string propertyName = DataGridViewItems.Columns[ColumnIndex].DataPropertyName.ToString();
            string? value = item.GetType().GetProperty(propertyName)?.GetValue(item)?.ToString();

            if (RowIndex >= DataGridViewItems.Rows.Count)
            {
                DataGridViewItems.RowCount = RowIndex + 1; 
            }

            DataGridViewItems.Rows[RowIndex].Cells[ColumnIndex].Value = value;
        }
    }
}
