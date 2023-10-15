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
            nodeNames.Enqueue("Post");
            nodeNames.Enqueue("Upgrade");
            nodeNames.Enqueue("Id");
            nodeNames.Enqueue("Name");
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

        private void UpdateElement()
        {
            var form = Program.Container.Resolve<FormEmployee>();
            var selectedEmployee = customTreeCell.GetSelectedObject<Employee>();
            if (selectedEmployee != null)
            {
                form.Id = Convert.ToInt32(selectedEmployee.Id);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
            else
            {
                // Обработка ситуации, когда объект Employee не выбран
                MessageBox.Show("Выберите сотрудника для редактирования");
            }
        }

        private void DeleteElement()
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(customTreeCell.GetSelectedObject<Employee>().Id);
                try
                {
                    _employeeLogic.Delete(new EmployeeBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateElement();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteElement();
        }
    }
}
