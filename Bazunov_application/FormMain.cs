using Bazunov_VisualComponents;
using EnterpriseDataBaseImplement.Models;

namespace Bazunov_application
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            itemTable1.ConfigColumn(new ColumnsConfiguratoin
            {
                ColumnsCount = 4,
                NameColumn = new[] { "Id", "FIO", "Subdivision", "Experience" },
                Width = new[] { 10, 150, 250, 200 },
                Visible = new[] { false, true, true, true },
                PropertiesObject = new[] { "Id", "Fio", "Subdivision", "Experience" }
            });

            var list = new List<Employee>()
            {
                new() {Id=0, Fio="AMOGUS1", Experience=1, Subdivision=null},
                new() {Id=1, Fio="AMOGUS2", Experience=2, Subdivision=null},
            };

            for (var j = 0; j < list.Count; j++)
            {
                for (var i = 0; i < 4; i++)
                {
                    itemTable1.AddItem(list[j], j, i);
                    itemTable1.Update();
                }
            }
        }
    }
}