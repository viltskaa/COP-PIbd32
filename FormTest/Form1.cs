

using CustomComponent;
using CustomComponent.Models;
using System.Security.Cryptography.Xml;
using System.Text;

namespace FormTest
{
    public partial class Form1 : Form
    {
        readonly List<Employee> employees = new()
        {
            new Employee { Id = 1, State = "���", FirstName = "����", LastName = "������", Age = 34, Childrens = "���", Car = "����", Post = "�������", Department = "����������� 1", Experience = 6, Prize = 2000.1 },
            new Employee { Id = 2, State = "���", FirstName = "����", LastName = "������", Age = 44, Childrens = "����", Car = "����", Post = "�������", Department = "����������� 1", Experience = 12, Prize = 2000.1 },
            new Employee { Id = 3, State = "��", FirstName = "������", LastName = "�������", Age = 55, Childrens = "���", Car = "����", Post = "������������", Department = "����������� 1", Experience = 34, Prize = 5000.5 },
            new Employee { Id = 4, State = "���", FirstName = "�����", LastName = "�������", Age = 34, Childrens = "����", Car = "���", Post = "���������", Department = "�����������", Experience = 8, Prize = 2000.1 },
            new Employee { Id = 5, State = "��", FirstName = "�������", LastName = "�������", Age = 44, Childrens = "���", Car = "���", Post = "������� ���������", Department = "�����������", Experience = 14, Prize = 7000.6 }
        };

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
                Header = "��������� �������",
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

        private void ButtonDocumentWithTableHeaderRowPdf_Click(object sender, EventArgs e)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            (sender as Control).BackColor = Color.White;
            componentTableToPdf.CreateDoc(new ComponentTableToPdfConfig<Employee>
            {
                FilePath = "PdfDocumentWithTableHeaderRow.pdf",
                Header = "���������",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (5, 0), (5, 0), (10, 0), (10, 0), (8, 0), (7, 0), (7, 0), (10, 0), (10, 0), (8, 0) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 3), (7, 2) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "�����.", "Id"),
                    (1, 0, "������", "State"),
                    (2, 0, "������ ������", ""),
                    (2, 1, "���", "FirstName"),
                    (3, 1, "�������", "LastName"),
                    (4, 1, "�������", "Age"),
                    (5, 0, "����", "Childrens"),
                    (6, 0, "������", "Car"),
                    (7, 0, "������", ""),
                    (7, 1, "�������������", "Department"),
                    (8, 1, "���������", "Post"),
                    (9, 0, "������", "Prize"),
                },
                Data = employees
            });
            (sender as Control).BackColor = Color.Green;
        }

        private void ButtonDocumentWithChartLinePdf_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            (sender as Control).BackColor = Color.White;
            componentDiagramToPdf.CreateDoc(new ComponentDiagramToPdfConfig
            {
                FilePath = "PdfDocumentWithChartLine.pdf",
                Header = "���������",
                ChartTitle = "�������� ���������",
                LegendLocation = CustomComponent.Models.Location.Bottom,
                Data = new Dictionary<string, List<(string Name, double Value)>>
                {
                    { "����� 1", new() { ("�� ������� ��������?", 10), ("����� 1", 15), ("����� 1", 18) } },
                    { "����� 2", new(){ ("����� 2", 45), ("����� 2", 34), ("����� 2", 19) } },
                    { "����� 3", new() { ("����� 3", 25), ("����� 3", 2), ("����� 3", 7) } }
                }
            });
            (sender as Control).BackColor = Color.Green;
        }
    }
}