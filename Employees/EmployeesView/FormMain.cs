using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.ViewModels;
using EmployeesDatabaseImplement.Models;
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

namespace EmployeesView
{
    public partial class FormMain : Form
    {
        private readonly IEmployeeLogic _employeeLogic;

        public FormMain(IEmployeeLogic employeeLogic)
        {
            _employeeLogic = employeeLogic;
            InitializeComponent();

            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("Name");
            nodeNames.Enqueue("Autobiography");
            nodeNames.Enqueue("Post");
            nodeNames.Enqueue("Upgrade");
            var treeConfig = new DataTreeNodeConfig { NodeNames = nodeNames };

            customTreeCell.LoadConfig(treeConfig);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                customTreeCell.Clear();
                var list = _employeeLogic.Read(null);
                if (list != null)
                {
                    foreach (var book in list)
                    {
                        customTreeCell.AddCell<EmployeeViewModel>(3, book);
                        customTreeCell.Update();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewElement()
        {
            var form = Program.Container.Resolve<FormEmployee>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewElement();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPost>();
            form.ShowDialog();
        }
    }
}
