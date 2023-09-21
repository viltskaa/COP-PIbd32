

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

            var list = new List<string>() { "�������� 1", "�������� 2", "�������� 3", "�������� 4", "�������� 5" };
            dropDownList.Items.AddRange(list.ToArray());

            phoneTextBox.Pattern = @"^\+7\(\d{3}\)\d{3}-\d{2}-\d{2}$";

            listBoxManys.SetLayout("�����: {Date}, ���� {Day}, ����������� {Temperature}", "{", "}");


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
                tt.Show("��������� ����", TextBoxList, 3000);
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
                labelSelectedValue.Text = ("�������� �� �������");
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
                Header = "���������",
                Paragraphs = new List<string>
                {
                    "�� ������� ����� 3 �� ��������� ����������, ������� ������ �������������� �� ������.",
                    "��� ���������� �������� �� �������� ���������� ������� ������� (word, excel ��� pdf). ���������� ������� ������� �� 3 ����� (�������� � ���������, �������� � ������������� �������� � �������� � ����������)."
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
                tt.Show("��������� ����", TextBoxList, 3000);
            }
        }

        private void ButtonCheckDrop_Click_1(object sender, EventArgs e)
        {
            labelSelectedValue.Text = dropDownList.SelectedValue;

            if (string.IsNullOrEmpty(labelSelectedValue.Text))
            {
                labelSelectedValue.Text = ("�������� �� �������");
            }
        }
    }
}