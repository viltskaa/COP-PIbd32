

using CustomComponent;
using System.Security.Cryptography.Xml;

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
            listBoxManys.AddItemInList(new DaysOfWeek(DateTime.Today.AddDays(-3), "Среда", 15),0,0);
        }

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

        public void buttonInList_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dateTimePicker.Text) || string.IsNullOrEmpty(textBoxDay.Text) || numericUpDown.Value == null)
            {
                return;
            }

            listBoxManys.AddItemInList(new DaysOfWeek(dateTimePicker.Value, textBoxDay.Text, Convert.ToInt32(numericUpDown.Value)), 0, 0);
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
    }
}