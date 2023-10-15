using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeesView
{
    public partial class FormEmployee : Form
    {
        public int Id { set { id = value; } }

        private readonly IEmployeeLogic _logic;
        private readonly IPostLogic _logicS;

        private int? id;

        public FormEmployee(IEmployeeLogic logic, IPostLogic logicS)
        {
            InitializeComponent();
            _logic = logic;
            _logicS = logicS;
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            List<PostViewModel> viewS = _logicS.Read(null);
            if (viewS != null)
            {
                foreach (PostViewModel s in viewS)
                {
                    dropDownList.Items.Add(s.Name);
                }
            }
            if (id.HasValue)
            {
                try
                {
                    EmployeeViewModel view = _logic.Read(new EmployeeBindingModel { Id = id.Value })?[0];
                    if (view != null)
                    {
                        textBoxAutobiography.Text = view.Autobiography;
                        textBoxName.Text = view.Name;
                        dropDownList.SelectedValue = view.Post;
                        dateTimePicker.Value = (DateTime)view.Upgrade;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(dropDownList.SelectedValue))
            {
                MessageBox.Show("Выберите должность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxAutobiography.Text == null)
            {
                MessageBox.Show("Заполните автобиографию", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DateTime? upgrade = dateTimePicker.Value;
            if (checkBox.Checked == true)
            {
                upgrade = null;
            }



            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = id,
                    Autobiography = textBoxAutobiography.Text,
                    Name = textBoxName.Text,
                    Post = dropDownList.SelectedValue.ToString(),
                    Upgrade = upgrade
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
