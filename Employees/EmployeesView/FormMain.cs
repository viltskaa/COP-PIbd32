using Bazunov_Components.Models;
using CustomComponent.Models;
using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.ViewModels;
using EmployeesDatabaseImplement.Models;
using MyCustomComponents;
using MyCustomComponents.Models;
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
        private readonly IPostLogic _postLogic;

        public FormMain(IEmployeeLogic employeeLogic, IPostLogic postLogic)
        {
            _employeeLogic = employeeLogic;
            _postLogic = postLogic;
            InitializeComponent();

            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("Post");
            nodeNames.Enqueue("Id");
            nodeNames.Enqueue("Upgrade");
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
                    }
                    customTreeCell.Update();
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

        private void CreateWord()
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }

            var positions = _postLogic.Read(null).Select(p => p.Name).ToList();
            var employees = _employeeLogic.Read(null);
            var employeeCounts = positions.Select(p =>
            {
                int count = employees.Count(e => e.Post != p && e.Upgrade == null);
                return (Date: p, Value: count);
            }).ToList();


            var list2D = new Dictionary<string, List<(string Date, double Value)>>()
            {
                { "Не прошедшие повышение", employeeCounts.Select(x => (x.Date, (double)x.Value)).ToList() }
            };

            wordWithDiagram.CreateDoc(new WordWithDiagramConfig
            {
                FilePath = fileName,
                Header = "Диаграмма",
                ChartTitle = "Круговая диаграмма",
                LegendLocation = MyCustomComponents.Models.Location.Bottom,
                Data = list2D
            });
        }


        private void CreateExcel()
        {
            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }

            var employees = _employeeLogic.Read(null);
            string FilePatht = fileName;
            string Headert = "Заголовое";
            List<(int Column, int Row)>? ColumnsRowsWidtht = new() { (5, 5), (10, 5), (10, 0), (5, 0), (7, 0) };
            List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>? Headerst = new()
            {
                (0, 0, "Id", "Id"),
                (1, 0, "Название", "Name"),
                (2, 0, "Описание", "Post"),
                (3, 0, "Категория", "Upgrade"),
                (4, 0, "Стоимость книг", "Autobiography")
            };
            List<EmployeeViewModel>? Datat = employees;
            excelWithCustomTable.CreateDoc(new TableWithHeaderConfig<EmployeeViewModel>
            {
                FilePath = FilePatht,
                Header = Headert,
                ColumnsRowsWidth = ColumnsRowsWidtht,
                Headers = Headerst,
                Data = Datat,
                NullReplace = "не проходил"
            });

            }

        private void CreatePdf()
        {

            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }

            List<string> tables = new List<string>();
            var list = _employeeLogic.Read(null);
            if (list != null)
            {
                foreach (var book in list)
                {
                    if (book.Upgrade != null)
                    {
                        string readers = string.Concat("ФИО:", book.Name, " Автобиография:", book.Autobiography);
                        tables.Add(readers);
                    }
                }
            }
            componentTextToPdf.CreateDoc(new ComponentTextToPdfConfig
            {
                FilePath = fileName,
                Header = " Формировать документ в Pdf по сотрудникам, проходившим квалификацию(в каждой строке текст с информацией: ФИО и автобиография)",
                Paragraphs = tables
            });
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

        private void документВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreatePdf();
        }

        private void отчетВEXCELToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateExcel();
        }

        private void диаграммаВWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateWord();
        }
    }
}
