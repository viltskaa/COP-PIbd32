using EnterpriseDataBaseImplement.Models;

namespace Bazunov_application
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            itemTable1.ConfigColumn(new()
            {
                ColumnsCount = 4,
                NameColumn = new string[] { "Id", "FIO", "Subdivision", "Experience" },
                Width = new int[] { 10, 150, 250, 200 },
                Visible = new bool[] { false, true, true, true },
                PropertiesObject = new string[] { "Id", "Fio", "Subdivision", "Experience" }
            });

            var list = new List<Employee>()
            {
                new() {Id=0, Fio="AMOGUS1", Experience=1, Subdivision="1"},
                new() {Id=1, Fio="AMOGUS2", Experience=2, Subdivision="2"},
            };

            for (int j = 0; j < list.Count; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    itemTable1.AddItem(list[j], j, i);
                    itemTable1.Update();
                }
            }
        }
    }
}