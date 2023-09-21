

using CustomComponent;
using CustomComponent.Models;
using System.Security.Cryptography.Xml;
using System.Text;

namespace FormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var list = new List<string>() { "Значение 1", "Значение 2", "Значение 3", "Значение 4", "Значение 5" };
            dropDownList.Items.AddRange(list.ToArray());

            phoneTextBox.Pattern = @"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$";

            listBoxManys.SetLayout("Число: {Date}, День {Day}, Температура {Temperature}", "{", "}");


        }

        private int temp = 0;

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBoxList.Text))
            {
                dropDownList.Items.Add(TextBoxList.Text);
            }
            else
            {
                ToolTip tt = new ToolTip();
                tt.Show("Заполните поле", TextBoxList, 3000);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            dropDownList.Clear();
        }

        private void ButtonCheckDrop_Click(object sender, EventArgs e)
        {
            labelSelectedValue.Text = dropDownList.SelectedValue;

            if (string.IsNullOrEmpty(labelSelectedValue.Text))
            {
                labelSelectedValue.Text = ("Значение не выбрано");
            }

        }

        private void ButtonCheckText_Click(object sender, EventArgs e)
        {
            labelShowText.Text = phoneTextBox.TextBoxValue;
        }

        private void ButtonExample_Click(object sender, EventArgs e)
        {
            if (textBoxExample.Text == String.Empty)
            {
                return;
            }
            phoneTextBox.SetExample(textBoxExample.Text);
        }


        private void buttonInList_Click(object sender, EventArgs e)
        {
            if (dateTimePicker.Value == null || textBoxDay.Text == null || numericUpDown.Value == null)
            {
                return;
            }

            listBoxManys.AddItemInList(new DaysOfWeek(dateTimePicker.Value, textBoxDay.Text, Convert.ToInt32(numericUpDown.Value)), 0+temp, 0);
            listBoxManys.AddItemInList(new DaysOfWeek(dateTimePicker.Value, textBoxDay.Text, Convert.ToInt32(numericUpDown.Value)), 0+temp, 1);
            listBoxManys.AddItemInList(new DaysOfWeek(dateTimePicker.Value, textBoxDay.Text, Convert.ToInt32(numericUpDown.Value)), 0+temp, 2);
            temp++;
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            DaysOfWeek dow = listBoxManys.GetItemFromList<DaysOfWeek>();
            if (dow == null)
            {
                return;
            }
            dateTimePicker.Value = dow.Date;
            textBoxDay.Text = dow.Day.ToString();
            numericUpDown.Value = dow.Temperature;
        }

        private void ButtonDocumentWithContextTextPdf_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            (sender as Control).BackColor = Color.White;
            componentTextToPdf.CreateDoc(new ComponentTextToPdfConfig
            {
                FilePath = "PdfDocumentWithContextTextPdf.pdf",
                Header = "Заголовок",
                Paragraphs = new List<string>
                {
                    "По заданию будет 3 не визульных компонента, которые должны использоваться на формах.",
                    "Все компоненты отвечают за создание документов разного формата (word, excel или pdf). Компоненты разбиты условно на 3 блока (документ с контентом, документ с настраиваемой таблицей и документ с диаграммой)."
                }
            });
            (sender as Control).BackColor = Color.Green;
        }

        private void ButtonAdd_Click_1(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TextBoxList.Text))
            {
                dropDownList.Items.Add(TextBoxList.Text);
            }
            else
            {
                ToolTip tt = new ToolTip();
                tt.Show("Заполните поле", TextBoxList, 3000);
            }
        }

        private void ButtonCheckDrop_Click_1(object sender, EventArgs e)
        {
            labelSelectedValue.Text = dropDownList.SelectedValue;

            if (string.IsNullOrEmpty(labelSelectedValue.Text))
            {
                labelSelectedValue.Text = ("Значение не выбрано");
            }
        }
    }
}