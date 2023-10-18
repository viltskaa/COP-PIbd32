using Bazunov_VisualComponents;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseDataBaseImplement.Models;
using Unity;

namespace Bazunov_application
{
    public partial class FormMain : Form
    {
        private readonly IEmployeeLogic _LogicE;
        private readonly ISubdivisionLogic _LogicS;
        public FormMain(IEmployeeLogic logicE, ISubdivisionLogic logicS)
        {
            InitializeComponent();
            _LogicE = logicE;
            _LogicS = logicS;
        }

        private void DropComponents()
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                DropComponents();
                listBoxMany.SetLayout("{Subdivision} {Id} {Fio} {Experience}", "{", "}");
                var list = _LogicE.Read(null);
                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        listBoxMany.AddItemInList(list[i], i, j);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void CreateEmployerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<EmployerForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void EditEmployerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<EmployerForm>();
            form.Id = Convert.ToInt32(listBoxMany.GetItemFromList<Employee>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteEmployerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete record", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(listBoxMany.GetItemFromList<Employee>().Id);
                try
                {
                    _LogicE.Delete(new EmployeeBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void ExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PdfToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void DirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Directory>();
            form.ShowDialog();
        }
    }
}