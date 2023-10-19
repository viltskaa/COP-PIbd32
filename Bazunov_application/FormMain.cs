using Bazunov_VisualComponents;
using DocumentFormat.OpenXml.Office2010.Excel;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseContracts.ViewModels;
using EnterpriseDataBaseImplement.Models;
using MyCustomComponents.Models;
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
                if (list == null) throw new Exception("Error on read");
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
            form.Id = Convert.ToInt32(listBoxMany.GetItemFromList<EmployeeViewModel>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void DeleteEmployerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete record", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var ent = listBoxMany.GetItemFromList<EmployeeViewModel>();
                
                try
                {
                    int id = Convert.ToInt32(ent.Id);
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
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Success", "Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            var ent = listBoxMany.GetItemFromList<EmployeeViewModel>();
            var Empl = _LogicE.Read(new EmployeeBindingModel { Id = ent.Id })[0];
            var Data = new string[1,5];
            int i = 0;
            foreach (var post in Empl.Posts.Split(","))
            {
                Data[0, i++] = post;
            }
            
            excelTable.CreateDoc(new Bazunov_Components.Models.TableConfig
            {
                FilePath = fileName,
                Header = "Example",
                Data = new List<string[,]> { Data }
            });
        }

        private void WordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Success", "Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            var list = _LogicE.Read(null);
            wordWithTable.CreateDoc(new WordWithTableDataConfig<EmployeeViewModel>
            {
                FilePath = fileName,
                Header = "Table:",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Id", "Id"),
                    (1, 0, "Fio", "Fio"),
                    (2, 0, "Work", ""),
                    (2, 1, "Subdivision", "Subdivision"),
                    (3, 1, "Experience", "Experience"),
                },
                Data = list
            });
        }

        private void PdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Success", "Ready", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            var listEmp = _LogicE.Read(null);
            var listSubd = _LogicS.Read(null);
            var Data = new Dictionary<string, List<(string Name, double Value)>>();
            foreach (var item in listSubd)
            {
                var listSorted = listEmp.Where(x => x.Subdivision.Equals(item.Name));
                (int, int, int, int) x = (
                    listSorted.Where(y => y.Experience >= 1 && y.Experience < 5).Count(),
                    listSorted.Where(y => y.Experience >= 5 && y.Experience < 10).Count(),
                    listSorted.Where(y => y.Experience >= 10 && y.Experience < 20).Count(),
                    listSorted.Where(y => y.Experience >= 20 && y.Experience < 30).Count());
                Data.Add(item.Name, new() { ("1-5", x.Item1), ("5-10", x.Item2), ("10-20", x.Item3), ("20-30", x.Item4) });
            }
            componentDiagramToPdf.CreateDoc(new()
            {
                FilePath = fileName,
                Header = "Chart",
                ChartTitle = "Chart",
                Data = Data
            });
        }

        private void DirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<Directory>();
            form.ShowDialog();
        }
    }
}