using Bazunov_VisualComponents;
using CustomComponent.Models;
using CustomComponent;
using DocumentFormat.OpenXml.Spreadsheet;
using EnterpriseContracts.BindingModels;
using EnterpriseContracts.BusinessLogicContracts;
using EnterpriseDataBaseImplement.Models;
using Microsoft.VisualBasic.Devices;
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
using EnterpriseContracts.ViewModels;
using Bazunov_Components;
using EnterpriseBusinessLogic.BusinessLogics;
using DocumentFormat.OpenXml.Drawing;

namespace DesktopAppForComponents
{
    public partial class FormMain : Form
    {
        private readonly IEmployeeLogic _empLogic;
        private readonly ISkillLogic _skillLogic;
        public FormMain(IEmployeeLogic empLogic, ISkillLogic skillLogic)
        {
            InitializeComponent();
            _empLogic = empLogic;

            bazunovItemTable.ConfigColumn(new()
            {
                ColumnsCount = 4,
                NameColumn = new string[] { "Id", "ФИО", "Навык", "Номер телефона" },
                Width = new int[] { 10, 150, 250, 200 },
                Visible = new bool[] { false, true, true, true },
                PropertiesObject = new string[] { "Id", "FIO", "Skill", "PhoneNumber" }
            });
            _skillLogic = skillLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _empLogic.Read(null);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployee>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormEmployee>();
            form.Id = Convert.ToInt32(bazunovItemTable.GetSelectedObjectInRow<Employee>().Id);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(bazunovItemTable.GetSelectedObjectInRow<Employee>().Id);
                try
                {
                    _empLogic.Delete(new EmployeeBindingModel { Id = id });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                LoadData();
            }
        }

        private void навыкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormSkill>();
            form.ShowDialog();
        }

        private byte[] StringToImage(string bytes)
        {
            byte[] arrayimg = Convert.FromBase64String(bytes);
            return arrayimg;
        }

        private void wordСФотоToolStripMenuItem_Click(object sender, EventArgs e)
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
            var list = _empLogic.Read(null);
            var list_images = new List<byte[]>();
            foreach (var item in list)
            {
                var img = StringToImage(item.Photo);
                list_images.Add(img);
            }
            wordWithImages1.CreateDoc(new WordWithImageConfig
            {
                FilePath = fileName,
                Header = "Фотографии:",
                Images = list_images
            });
        }

        private void pdfТаблицаToolStripMenuItem_Click(object sender, EventArgs e)
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
                Data = _empLogic.Read(null)
            });
        }

        private void excelГистограммаToolStripMenuItem_Click(object sender, EventArgs e)
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

            string[] Names = { "Маленькая", "Большая" };
            var diapasons = _skillLogic.Read(null);

            var list2D = new Dictionary<string, List<(int Date, double Value)>>();
            var emps = _empLogic.Read(null);



        }
    }
}
