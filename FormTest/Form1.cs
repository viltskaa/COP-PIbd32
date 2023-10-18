

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
            new Employee { Id = 1, State = "нет", FirstName = "Иван", LastName = "Иванов", Age = 34, Childrens = "нет", Car = "есть", Post = "Инженер", Department = "Департамент 1", Experience = 6, Prize = 2000.1 },
            new Employee { Id = 2, State = "нет", FirstName = "Петр", LastName = "Петров", Age = 44, Childrens = "есть", Car = "есть", Post = "Инженер", Department = "Департамент 1", Experience = 12, Prize = 2000.1 },
            new Employee { Id = 3, State = "да", FirstName = "Сергей", LastName = "Сергеев", Age = 55, Childrens = "нет", Car = "есть", Post = "Руководитель", Department = "Департамент 1", Experience = 34, Prize = 5000.5 },
            new Employee { Id = 4, State = "нет", FirstName = "Ольга", LastName = "Иванова", Age = 34, Childrens = "есть", Car = "нет", Post = "Бухгалтер", Department = "Бухгалтерия", Experience = 8, Prize = 2000.1 },
            new Employee { Id = 5, State = "да", FirstName = "Татьяна", LastName = "Петрова", Age = 44, Childrens = "нет", Car = "нет", Post = "Старший бухгалтер", Department = "Бухгалтерия", Experience = 14, Prize = 7000.6 }
        };

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
                Header = "Заголовок главный",
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

        private void ButtonDocumentWithTableHeaderRowPdf_Click(object sender, EventArgs e)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            (sender as Control).BackColor = Color.White;
            componentTableToPdf.CreateDoc(new ComponentTableToPdfConfig<Employee>
            {
                FilePath = "PdfDocumentWithTableHeaderRow.pdf",
                Header = "Заголовок",
                UseUnion = true,
                ColumnsRowsWidth = new List<(int, int)> { (5, 0), (5, 0), (10, 0), (10, 0), (8, 0), (7, 0), (7, 0), (10, 0), (10, 0), (8, 0) },
                ColumnUnion = new List<(int StartIndex, int Count)> { (2, 3), (7, 2) },
                Headers = new List<(int ColumnIndex, int RowIndex, string Header, string PropertyName)>
                {
                    (0, 0, "Идент.", "Id"),
                    (1, 0, "Статус", "State"),
                    (2, 0, "Личные данные", ""),
                    (2, 1, "Имя", "FirstName"),
                    (3, 1, "Фамилия", "LastName"),
                    (4, 1, "Возраст", "Age"),
                    (5, 0, "Дети", "Childrens"),
                    (6, 0, "Машина", "Car"),
                    (7, 0, "Работа", ""),
                    (7, 1, "Подразделение", "Department"),
                    (8, 1, "Должность", "Post"),
                    (9, 0, "Премия", "Prize"),
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
                Header = "Заголовок",
                ChartTitle = "Линейная диаграмма",
                LegendLocation = CustomComponent.Models.Location.Bottom,
                Data = new Dictionary<string, List<(string Name, double Value)>>
                {
                    { "Серия 1", new() { ("Че реально работает?", 10), ("Текст 1", 15), ("Текст 1", 18) } },
                    { "Серия 2", new(){ ("Текст 2", 45), ("Текст 2", 34), ("Текст 2", 19) } },
                    { "Серия 3", new() { ("Текст 3", 25), ("Текст 3", 2), ("Текст 3", 7) } }
                }
            });
            (sender as Control).BackColor = Color.Green;
        }
    }
}