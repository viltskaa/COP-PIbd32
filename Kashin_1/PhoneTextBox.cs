using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CustomComponent
{
    public partial class PhoneTextBox : UserControl
    {


        private string? pattern;
        private string example = "+7(XXX)XXX-XX-XX";
        public PhoneTextBox()
        {
            InitializeComponent();
        }

		public string? Pattern
		{
			get { return pattern; }
			set { pattern = value; }
		}

		public string TextBoxValue
		{
			get
			{
				Regex regex = new Regex(Pattern);
				bool isValid = regex.IsMatch(textBox.Text);
				if (isValid)
				{
					return textBox.Text;
				}
				else
				{
					Error = "Неправильный ввод";
					return null;
				}
			}
			set
			{
				Regex regex = new Regex(Pattern);
				bool isValid = regex.IsMatch(value);
				if (isValid)
				{
					textBox.Text = value;
				}
				else
				{
					Error = "Неправильно";
				}
			}
		}

		public string Error
		{
			get; private set;
		}
		public void SetExample(string exampleStr)
		{
			Regex regex = new Regex(Pattern);
			bool isValid = regex.IsMatch(exampleStr);
			if (isValid)
			{
				example = exampleStr;
			}
		}

		private void textBox_Enter(object sender, EventArgs e)
		{
			ToolTip tt = new ToolTip();
			tt.Show(example, textBox, 30, -20, 1000);
		}

		private void textBox_TextChanged(object sender, EventArgs e)
		{
			_changeEvent?.Invoke(sender, e);
		}

		private EventHandler _changeEvent;
		public event EventHandler ChangeEvent
		{
			add
			{
				_changeEvent += value;
			}
			remove
			{
				_changeEvent -= value;
			}
		}
	}
}
