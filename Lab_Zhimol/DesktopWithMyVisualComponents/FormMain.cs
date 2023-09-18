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
        public FormMain()
        {
            InitializeComponent();
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
    }
}
