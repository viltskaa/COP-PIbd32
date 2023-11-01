using Bazunov_Components;
using Bazunov_Components.Models;
using CustomComponent;
using CustomComponent.Models;
using EmployeeLogic.BusinessLogics;
using EmployeesContracts.BindingModels;
using EmployeesContracts.BusinessLogicsContracts;
using EmployeesContracts.ViewModels;
using EmployeesView;
using MyCustomComponents;
using MyCustomComponents.Models;
using PluginsConventionLibrary.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluginsConventionLibrary.MyPlugin
{
    [Export(typeof(IPluginsConvention))]
    public class MainPluginConvention : IPluginsConvention
    {

        private CustomTreeCell customTreeCell;
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IPostLogic _postLogic;

        public MainPluginConvention()
        {
            _employeeLogic = new EmployeeLogic.BusinessLogics.EmployeeLogic();
            _postLogic = new PostLogic();

            customTreeCell = new CustomTreeCell();
            var menu = new ContextMenuStrip();
            var skillMenuItem = new ToolStripMenuItem("Формы");
            menu.Items.Add(skillMenuItem);
            skillMenuItem.Click += (sender, e) =>
            {
                var formSkill = new FormPost(_postLogic);
                formSkill.ShowDialog();
            };
            customTreeCell.ContextMenuStrip = menu;
            ReloadData();
        }

        /// Название плагина
        string IPluginsConvention.PluginName => PluginName();
        public string PluginName()
        {
            return "Employees";
        }

        public UserControl GetControl => customTreeCell;

        PluginsConventionElement IPluginsConvention.GetElement => GetElement();

        public PluginsConventionElement GetElement()
        {
            var employee = customTreeCell.GetSelectedObject<MainPluginConventionElement>(); ;
            MainPluginConventionElement element = null;
            if (customTreeCell != null)
            {
                element = new MainPluginConventionElement
                {
                    Id = employee.Id,
                    Autobiography = employee.Autobiography,
                    Name = employee.Name,
                    Post = employee.Post,
                    Upgrade = employee.Upgrade,
                };
            }
            return (new PluginsConventionElement { Id = element.Id });
        }

        public Form GetForm(PluginsConventionElement element)
        {
            var formOrder = new FormEmployee(_employeeLogic, _postLogic);
            if (element != null)
            {
                formOrder.Id = element.Id;
            }
            return formOrder;
        }

        public bool DeleteElement(PluginsConventionElement element)
        {
            try
            {
                _employeeLogic.Delete(new EmployeeBindingModel { Id = element.Id });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public void ReloadData()
        {
            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("Post");
            nodeNames.Enqueue("Id");
            nodeNames.Enqueue("Upgrade");
            nodeNames.Enqueue("Name");
            var treeConfig = new DataTreeNodeConfig { NodeNames = nodeNames };


            customTreeCell.LoadConfig(treeConfig);

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

        private byte[] StringToImage(string bytes)
        {
            byte[] arrayimg = Convert.FromBase64String(bytes);
            return arrayimg;
        }

        public bool CreateSimpleDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
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

            WordWithDiagram wordWithDiagram = new WordWithDiagram();
            wordWithDiagram.CreateDoc(new WordWithDiagramConfig
            {
                FilePath = fileName,
                Header = "Диаграмма",
                ChartTitle = "Круговая диаграмма",
                LegendLocation = MyCustomComponents.Models.Location.Bottom,
                Data = list2D
            });
        }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateTableDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
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
                ExcelWithCustomTable excelWithCustomTable = new ExcelWithCustomTable();
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool CreateChartDocument(PluginsConventionSaveDocument saveDocument)
        {
            try
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
                ComponentTextToPdf componentTextToPdf = new ComponentTextToPdf();
                componentTextToPdf.CreateDoc(new ComponentTextToPdfConfig
                {
                    FilePath = fileName,
                    Header = " Формировать документ в Pdf по сотрудникам, проходившим квалификацию(в каждой строке текст с информацией: ФИО и автобиография)",
                    Paragraphs = tables
                });
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}