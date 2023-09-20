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

namespace DesktopWithMyVisualComponents
{
    public partial class FormMain : Form
    {
        readonly List<Transport> transports = new()
        {
            new Transport { Id = 1, Fuel="Авиакеросин", Mileage=239000, Owner="Аэрофлот", Price=70000000, State="Эксплуатируется", RegNumber = "EW-009EC", TransportType = "Воздушный транспорт", Model = "Ан-30" },
            new Transport { Id = 2, Fuel="Авиакеросин", Mileage=452005, Owner="Азимут", Price=95000000, State="Не эксплуатируется", RegNumber = "EW-987ZY", TransportType = "Воздушный транспорт", Model = "Ан-28" },
            new Transport { Id = 3, Fuel="Мазут", Mileage=790222, Owner="ВМФ США", Price=100000000, State="Эксплуатируется", RegNumber = "SSH-988", TransportType = "Морской транспорт", Model = "авианосец 'Нимиц'" },
            new Transport { Id = 4, Fuel="92", Mileage=105777, Owner="Ползунова Татьяна Михайловна",State="Не эксплуатируется", Price=400000, RegNumber = "B901AУ74", TransportType = "Наземный транспорт", Model = "Renault Logan" },
            new Transport { Id = 5, Fuel="Газ", Mileage=66782, Owner="Аветесян Сергей Георгиевич", State="Эксплуатируется", Price=160000, RegNumber = "Р187КН73", TransportType = "Наземный транспорт", Model = "Daewoo Matiz" },
        };
        public FormMain()
        {
            InitializeComponent();
            var list = new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" };
            customSelectedCheckedListBoxProperty.Items.AddRange(list.ToArray());

            comboBoxTransportType.Items.Add("Наземный транспорт");
            comboBoxTransportType.Items.Add("Воздушный транспорт");
            comboBoxTransportType.Items.Add("Морской транспорт");

            var nodeNames = new Queue<string>();
            nodeNames.Enqueue("TransportType");
            nodeNames.Enqueue("Model");
            nodeNames.Enqueue("RegNumber");
            var treeConfig = new DataTreeNodeConfig { NodeNames = nodeNames };

            customTreeCell.LoadConfig(treeConfig);

            int counter = 0;
            foreach (var transport in transports)
            {

                customTreeCell.AddCell(0, transport);
                customTreeCell.AddCell(1, transport);
                customTreeCell.AddCell(2, transport);
                customTreeCell.AddCell(3, transport);

                counter++;
            }
        }

        private void buttonCheck_Click(object sender, EventArgs e)
        {
            labelCheckValue.Text = customInputRangeNumber.Value.ToString();
            if (labelCheckValue.Text == "")
            {
                labelCheckValue.Text = customInputRangeNumber.Error;
            }
        }

        private void buttonSetBorders_Click(object sender, EventArgs e)
        {
            if (!customInputRangeNumber.SetBorders(textBoxMin.Text, textBoxMax.Text))
            {
                labelCheckValue.Text = customInputRangeNumber.Error;
                return;
            }
            labelCheckValue.Text = "Граница установлена";
            customInputRangeNumber.SetBorders(textBoxMin.Text, textBoxMax.Text);
        }

        private void textBoxMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void textBoxMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8 && ch != 45)
            {
                e.Handled = true;
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxAdd.Text != "" && !customSelectedCheckedListBoxProperty.Items.Contains(textBoxAdd.Text))
                customSelectedCheckedListBoxProperty.Items.Add(textBoxAdd.Text);
            else if (customSelectedCheckedListBoxProperty.Items.Contains(textBoxAdd.Text))
                customSelectedCheckedListBoxProperty.SelectedElement = textBoxAdd.Text;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            customSelectedCheckedListBoxProperty.Clear();
        }

        private void buttonGetSelected_Click(object sender, EventArgs e)
        {
            labelSelectedValue.Text = customSelectedCheckedListBoxProperty.SelectedElement;
            if (labelSelectedValue.Text == "")
            {
                labelSelectedValue.Text = "Значение \nне выбрано";
            }
        }

        private void buttonAddToTree_Click(object sender, EventArgs e)
        {
            if (textBoxRegNumber.Text == null || textBoxModel.Text == null || comboBoxTransportType.SelectedItem == null)
            {
                return;
            } 
            customTreeCell.AddCell<Transport>(2, new(textBoxRegNumber.Text, comboBoxTransportType.SelectedItem.ToString(), textBoxModel.Text));
            customTreeCell.Update();
        }

        private void buttonGetFromTree_Click(object sender, EventArgs e)
        {
            Transport tp = customTreeCell.GetSelectedObject<Transport>();
            if (tp == null)
            {
                return;
            }
            textBoxRegNumber.Text = tp.RegNumber;
            textBoxModel.Text = tp.Model;
            comboBoxTransportType.SelectedItem = tp.TransportType;
        }

        private void buttonWordWithImage_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            bool flag = true;
            var images = new List<byte[]>();
            while (flag)
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    images.Add(File.ReadAllBytes(openFileDialog.FileName));
                }
                else
                {
                    flag = false;
                }
            }
            wordWithImages.CreateDoc(new WordWithImageConfig
            {
                FilePath = "WordWithImageDocx.docx",
                Header = "Картинки:",
                Images = images
            });
        }

        private void buttonWordWithTable_Click(object sender, EventArgs e)
        {
            wordWithTable.CreateDoc(new WordWithTableDataConfig<Transport>
            {
                FilePath = "WordWithTableDocx.docx",
                Header = "Таблица:",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (0, 5), (0, 5), (0, 10), (0, 10), (0, 7), (0, 7), (0, 10), (0, 10), (0, 8) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 3), (5, 3) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Номер", "Id"),
                    (1, 0, "Статус", "State"),
                    (2, 0, "Личные данные", ""),
                    (2, 1, "Регистрационный номер", "RegNumber"),
                    (3, 1, "Пробег", "Mileage"),
                    (4, 1, "Владелец", "Owner"),
                    (5, 0, "Общие данные", ""),
                    (5, 1, "Топливо", "Fuel"),
                    (6, 1, "Тип транспорта", "TransportType"),
                    (7, 1, "Модель", "Model"),
                    (8, 0, "Стоимость", "Price"),
                },
                Data = transports
            });
        }

        private void buttonWordWithDiagram_Click(object sender, EventArgs e)
        {
            wordWithDiagram.CreateDoc(new WordWithDiagramConfig
            {
                FilePath = "WordWithDiagramDocx.docx",
                Header = "Диаграмма",
                ChartTitle = "Круговая диаграмма",
                LegendLocation = MyCustomComponents.Models.Location.Bottom,
                Data = new Dictionary<string, List<(int Date, double Value)>>
                {
                    { "Серия 1", new List<(int Date, double Value)> { (1, 20), (2, 30), (3, 50) } }
                }
            });
        }
    }
}
