using Bazunov_visual_components;
using Bazunov_VisualComponents;

namespace TestApplication
{
    public partial class Form : System.Windows.Forms.Form
    {
        private bool EmptyFill = false;
        readonly List<Computer> computers = new()
        {
            new Computer { Id = 0, CPU = "Intel I7", GPU = "Nvidia RTX 3060", RAM = 8 },
            new Computer { Id = 1, CPU = "Apple M1", GPU = "Apple Graphics", RAM = 8 },
            new Computer { Id = 2, CPU = "Intel I3", GPU = "Nvidia GT 720", RAM = 4 },
            new Computer { Id = 3, CPU = "Intel I9", GPU = "Nvidia GTX 1060", RAM = 16 },
            new Computer { Id = 4, CPU = "AMD Ryzen 9", GPU = "Nvidia RTX 4060ti", RAM = 32 }
        };

        public Form()
        {
            InitializeComponent();
            CreateList();
        }

        private void CreateList()
        {
            for (int i = 0; i < 10; i++)
            {
                ItemList.Items.Add($"Item-{i}");
            }
        }

        private void CreateTable()
        {
            itemTable.ConfigColumn(new() {
                ColumnsCount = 4,
                NameColumn = new string[] { "Id", "CPU", "GPU", "RAM" },
                Width = new int[] { 10, 150, 250, 200 },
                Visible = new bool[] { false, true, true, true, true },
                PropertiesObject = new string[] { "Id", "CPU", "GPU", "RAM" }
            });

            foreach (Computer computer in computers) {
                for (int i = 0; i < 4; i++) {
                    itemTable.AddItem(computer, computer.Id, i);
                    itemTable.Update();
                }
            }
        }

        private void ButtonListClear_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
        }

        private void ButtonLoadList_Click(object sender, EventArgs e)
        {
            CreateList();
        }

        private void ItemList_ChangeEvent(object sender, EventArgs e)
        {
            object? selectedItem = ItemList.SelectedElement;
            MessageBox.Show($"Change selected item {selectedItem?.ToString()}");
        }

        private void dateBoxWithNull1_ChangeEvent(object sender, EventArgs e)
        {
            textBoxEvent.Text = "TextBox change";
        }

        private void dateBoxWithNull1_CheckBoxEvent(object sender, EventArgs e)
        {
            textBoxEvent.Text = "CheckBox change";
        }

        private void ButtonGetValue_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Value is {dateBoxWithNull.Value}");
        }

        private void ButtonSetValue_Click(object sender, EventArgs e)
        {
            if (EmptyFill)
            {
                dateBoxWithNull.Value = DateTime.Now;
            }
            else
            {
                dateBoxWithNull.Value = null;
            }
            EmptyFill = !EmptyFill;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            CreateTable();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            itemTable.ClearDataGrid();
        }

        private void ButtonSel_Click(object sender, EventArgs e)
        {
            Computer? computer = itemTable.GetSelectedObjectInRow<Computer>();
            if (computer is null) return;
            MessageBox.Show($"{computer.Id}-{computer.CPU}-{computer.GPU}-{computer.RAM}");
        }
    }
}