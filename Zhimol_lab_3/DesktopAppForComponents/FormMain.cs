using Bazunov_VisualComponents;
using DocumentFormat.OpenXml.Spreadsheet;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseDataBaseImplement.Models;
using Microsoft.VisualBasic.Devices;
using MyCustomComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace DesktopAppForComponents
{
    public partial class FormMain : Form
    {
        private readonly IEmployeeLogic _empLogic;
        public FormMain(IEmployeeLogic empLogic)
        {
            InitializeComponent();
            _empLogic = empLogic;

            bazunovItemTable.ConfigColumn(new()
            {
                ColumnsCount = 4,
                NameColumn = new string[] { "Id", "FIO", "Skill", "PhoneNumber" },
                Width = new int[] { 10, 150, 250, 200 },
                Visible = new bool[] { false, true, true, true },
                PropertiesObject = new string[] { "Id", "FIO", "Skill", "PhoneNumber" }
            });

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _empLogic.Read(null);
                if (list != null)
                {
                    for (int j=0;j<list.Count;j++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            bazunovItemTable.AddItem(list[j], j, i);
                            bazunovItemTable.Update();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployee>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployee>();
            form.Id = Convert.ToInt32(bazunovItemTable.GetSelectedObjectInRow<Employee>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(bazunovItemTable.GetSelectedObjectInRow<Employee>().Id);
                try
                {
                    _empLogic.Delete(new EmployeeBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }
    }
}
