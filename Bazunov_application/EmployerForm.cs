using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.ViewModels;
using System.Data;

namespace Bazunov_application
{
    public partial class EmployerForm : Form
    {
        private readonly IEmployeeLogic _logic;
        private readonly ISubdivisionLogic _logicS;
        public int? Id { get; set; }

        public EmployerForm(IEmployeeLogic logic, ISubdivisionLogic logicS)
        {
            InitializeComponent();
            _logic = logic;
            _logicS = logicS;
            customInputRangeNumber.MinValue = 1M;
            customInputRangeNumber.MaxValue = 30M;
        }

        private void ButtonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                _logic.CreateOrUpdate(new EmployeeBindingModel
                {
                    Id = Id,
                    Fio = textBoxFio.Text,
                    Subdivision = dropDownList.SelectedValue,
                    Posts = textBoxPosts.Text,
                    Experience = (new Random()).Next(1, 30)
                });
                MessageBox.Show("Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmployerForm_Load(object sender, EventArgs e)
        {
            List<SubdivisionViewModel>? viewS = _logicS.Read(null);

            if (viewS != null)
            {
                dropDownList.Items.AddRange(viewS.Select(x => x.Name).ToArray());
            }

            if (Id.HasValue)
            {
                try
                {
                    EmployeeViewModel? view = _logic.Read(new EmployeeBindingModel { Id = Id.Value })?[0];
                    if (view != null)
                    {
                        textBoxFio.Text = view.Fio;
                        dropDownList.SelectedValue = view.Subdivision;
                        customInputRangeNumber.Value = view.Experience;
                        textBoxPosts.Text = view.Posts;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EmployerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //DialogResult = DialogResult.Cancel;
        }
    }
}
