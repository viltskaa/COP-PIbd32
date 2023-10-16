using CustomComponent.Models;
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
/*            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }
            List<string[,]> tables = new List<string[,]>();
            var list = _employeeLogic.Read(null);
            if (list != null)
            {
                foreach (var book in list)
                {
                    string[,] readers = new string[,] { {book.Reader1, book.Reader2, book.Reader3,
                                                         book.Reader4, book.Reader5, book.Reader6 } };
                    tables.Add(readers);
                }
            }
            wordTablesContext.SaveData(fileName, "Последние читатели, бравшие книги", tables);*/
        }

        private void CreateExcel()
        {
/*            string fileName = "";
            using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName.ToString();
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                   MessageBoxIcon.Information);
                }
            }

            LineChartConfig data = new LineChartConfig();
            data.FilePath = fileName;
            data.Header = "Линейная диаграмма";
            data.ChartTitle = "Диаграмма";
            string[] Names = { "Маленькая", "Большая" };
            string[] diapasons = { "100-120", "120-140", "140-160", "160-180", "180-200" };

            var list2D = new Dictionary<string, List<int>>();
            var books = _bookLogic.Read(null);


            for (int i = 0; i < Names.Length; i++)
            {
                var row = new List<int>();
                for (int j = 0; j < diapasons.Length; j++)
                {
                    int count = 0;
                    foreach (var book in books)
                    {
                        if (book.Shape.Equals(Names[i]))
                        {
                            if (book.Annotation.Length >= 100 + j * 20 && book.Annotation.Length < 100 + (j + 1) * 20)
                            {
                                count++;
                            }
                        }
                    }
                    row.Add(count);
                }
                list2D.Add(Names[i], row);
            }

            data.Values = list2D;

            RomanovaExcelDiagram diagram = new RomanovaExcelDiagram();
            diagram.CreateExcel(data);*/
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
                    string readers = string.Concat("ФИО:", book.Name," Автобиография:", book.Autobiography);
                    tables.Add(readers);
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
