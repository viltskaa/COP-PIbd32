using EmployeeLogic.BusinessLogics;
using EmployeesContracts.BusinessLogicsContracts;
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

        private ItemTable bazunovItemTable;
        private readonly IEmployeeLogic _employeeLogic;
        private readonly IPostLogic _postLogic;

        public MainPluginConvention()
        {
            _employeeLogic = new EmployeeLogic();
            _postLogic = new PostLogic();

            bazunovItemTable = new ItemTable();
            var menu = new ContextMenuStrip();
            var skillMenuItem = new ToolStripMenuItem("Формы");
            menu.Items.Add(skillMenuItem);
            skillMenuItem.Click += (sender, e) =>
            {
                var formSkill = new FormSkill(_postLogic);
                formSkill.ShowDialog();
            };
            bazunovItemTable.ContextMenuStrip = menu;
            ReloadData();
        }

        /// Название плагина
        string IPluginsConvention.PluginName => PluginName();
        public string PluginName()
        {
            return "Employees";
        }

        public UserControl GetControl => bazunovItemTable;

        PluginsConventionElement IPluginsConvention.GetElement => GetElement();

        public PluginsConventionElement GetElement()
        {
            var employee = bazunovItemTable.GetSelectedObjectInRow<MainPluginConventionElement>(); ;
            MainPluginConventionElement element = null;
            if (bazunovItemTable != null)
            {
                element = new MainPluginConventionElement
                {
                    Id = employee.Id,
                    FIO = employee.Skill,
                    PhoneNumber = employee.PhoneNumber,
                    Photo = employee.Photo,
                    Skill = employee.Skill,
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
            bazunovItemTable.ClearDataGrid();
            bazunovItemTable.ClearDataGrid();
            bazunovItemTable.ConfigColumn(new()
            {
                ColumnsCount = 4,
                NameColumn = new string[] { "Id", "ФИО", "Навык", "Номер телефона" },
                Width = new int[] { 10, 150, 250, 200 },
                Visible = new bool[] { false, true, true, true },
                PropertiesObject = new string[] { "Id", "FIO", "Skill", "PhoneNumber" }
            });
            var list = _employeeLogic.Read(null);
            if (list != null)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        bazunovItemTable.AddItem(list[j], j, i);
                        bazunovItemTable.Update();
                    }
                }
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
                var list = _employeeLogic.Read(null);
                var list_images = new List<byte[]>();
                foreach (var item in list)
                {
                    var img = StringToImage(item.Photo);
                    list_images.Add(img);
                }
                WordWithImages wordWithImages1 = new WordWithImages();
                wordWithImages1.CreateDoc(new WordWithImageConfig
                {
                    FilePath = fileName,
                    Header = "Фотографии:",
                    Images = list_images
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
                using (var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    }
                }
                ComponentTableToPdf componentTableToPdf1 = new ComponentTableToPdf();
                componentTableToPdf1.CreateDoc(new ComponentTableToPdfConfig<EmployeeViewModel>
                {
                    FilePath = fileName,
                    Header = "Таблица с сотрудниками",
                    UseUnion = true,
                    ColumnsRowsWidth = new List<(int, int)> { (20, 0), (20, 0), (20, 0), (20, 0) },
                    ColumnUnion = new List<(int StartIndex, int Count)> { (2, 2) },
                    Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Идент.", "Id"),
                    (1, 0, "ФИО", "FIO"),
                    (2, 0, "Работа", ""),
                    (2, 1, "Номер телефона", "PhoneNumber"),
                    (3, 1, "Навык", "Skill")
                },
                    Data = _employeeLogic.Read(null)
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
                using (var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" })
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileName = dialog.FileName.ToString();
                        MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                       MessageBoxIcon.Information);
                    }
                }

                var diapasons = _postLogic.Read(null);

                var list2D = new List<(string Date, double Value)>();
                var emps = _employeeLogic.Read(null);
                var skills = _postLogic.Read(null);

                foreach (var skill in skills)
                {
                    double count = 0;
                    foreach (var emp in emps)
                    {
                        if (skill.Name.Equals(emp.Skill))
                        {
                            count++;
                        }
                    }
                    var elem = (skill.Name, count);
                    list2D.Add(elem);
                }

                Random rnd = new Random();
                ExcelGistogram excelGistogram1 = new ExcelGistogram();
                excelGistogram1.CreateDoc(new()
                {
                    FilePath = fileName,
                    Header = "Chart",
                    ChartTitle = "BarChart",
                    LegendLocation = Bazunov_Components.Models.Location.Top,
                    Data = new Dictionary<string, List<(string Date, double Value)>>
                {
                    { "Series 1", list2D }
                }
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