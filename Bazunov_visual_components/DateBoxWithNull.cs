using System;
using System.Globalization;

namespace Bazunov_VisualComponents
{
    public partial class DateBoxWithNull : UserControl
    {
        public EventHandler? _changeEvent;
        public EventHandler? _checkBoxEvent;
        public Exception? Error;
        public DateBoxWithNull()
        {
            InitializeComponent();
        }

        public DateTime? Value
        {
            get
            {
                Error = null;
                if (!CheckBoxNull.Checked)
                {
                    if (string.IsNullOrEmpty(TextBoxDate.Text))
                    {
                        Error = new NotFilledException("Text box can't be empty, click checkbox if value must be empty!");
                        return null;
                    }
                    if (DateTime.TryParseExact(TextBoxDate.Text, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime parsedDate))
                    {
                        return parsedDate;
                    }
                    else
                    {
                        Error = new ParseException($"Wrong format <{TextBoxDate.Text}>!");
                        return null;
                    }
                }
                return null;
            }
            set
            {
                if (value is null)
                {
                    CheckBoxNull.Checked = true;
                }
                else
                {
                    TextBoxDate.Text = value?.ToString("dd/MM/yyyy");
                    CheckBoxNull.Checked = false;
                }
            }
        }

        public event EventHandler CheckBoxEvent
        {
            add { _checkBoxEvent += value; }
            remove { _checkBoxEvent += value; }
        }

        public event EventHandler ChangeEvent
        {
            add { _changeEvent += value; }
            remove { _changeEvent += value; }
        }

        private void TextBoxDate_TextChanged(object sender, EventArgs e)
        {
            _changeEvent?.Invoke(sender, e);
        }

        private void CheckBoxNull_CheckedChanged(object sender, EventArgs e)
        {
            TextBoxDate.Enabled = !CheckBoxNull.Checked;
            _checkBoxEvent?.Invoke(sender, e);
        }
    }
}
