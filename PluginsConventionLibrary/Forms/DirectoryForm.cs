using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using System.ComponentModel;

namespace PluginsConventionLibrary.Forms
{
    public partial class DirectoryForm : Form
    {
        private readonly ISubdivisionLogic _logicS;
        BindingList<SubdivisionBindingModel> list;

        public DirectoryForm(ISubdivisionLogic logicS)
        {
            InitializeComponent();
            _logicS = logicS;
            dataGridView.AllowUserToDeleteRows = true;
            list = new BindingList<SubdivisionBindingModel>();
        }

        private void LoadData()
        {
            try
            {
                var list1 = _logicS.Read(null);
                list.Clear();
                foreach (var item in list1)
                {
                    list.Add(new()
                    {
                        Id = item.Id,
                        Name = item.Name,
                    });
                }
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Directory_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var typeName = (string)dataGridView.CurrentRow.Cells[1].Value;
            if (!string.IsNullOrEmpty(typeName))
            {
                if (dataGridView.CurrentRow.Cells[0].Value != null)
                {
                    _logicS.CreateOrUpdate(new()
                    {
                        Id = Convert.ToInt32(dataGridView.CurrentRow.Cells[0].Value),
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
                else
                {
                    _logicS.CreateOrUpdate(new()
                    {
                        Name = (string)dataGridView.CurrentRow.Cells[1].EditedFormattedValue
                    });
                }
            }
            else
            {
                MessageBox.Show("Empty name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadData();
        }

        private void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Insert)
            {
                if (dataGridView.Rows.Count == 0)
                {
                    list.Add(new());
                    dataGridView.DataSource = new List<SubdivisionBindingModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[0].Cells[1];
                    return;
                }
                if (dataGridView.Rows[^1].Cells[1].Value != null)
                {
                    list.Add(new());
                    dataGridView.DataSource = new List<SubdivisionBindingModel>(list);
                    dataGridView.CurrentCell = dataGridView.Rows[^1].Cells[1];
                    return;
                }
            }
            if (e.KeyData == Keys.Delete)
            {
                if (dataGridView.SelectedRows.Count == 1)
                {
                    if (MessageBox.Show("Confirm deleting", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                        try
                        {
                            if (!_logicS.Delete(new()
                            {
                                Id = id
                            }))
                            {
                                throw new Exception("Error on delete");
                            }
                            dataGridView.Rows.RemoveAt(dataGridView.SelectedRows[0].Index);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
