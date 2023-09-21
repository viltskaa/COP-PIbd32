using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kashin_1
{
    public partial class DropDownList : UserControl
    {

        public ComboBox.ObjectCollection Items => ComboBox.Items;

        public event EventHandler _сhangeEvent;

        public event EventHandler ChangeEvent
        {
            add
            {
                _сhangeEvent += value;
            }
            remove
            {
                _сhangeEvent -= value;
            }

        }

        public DropDownList()
        {
            InitializeComponent();

        }

        public string SelectedValue
        {
            get
            {
                return ComboBox.Items.Contains(ComboBox.SelectedItem) ? ComboBox.SelectedItem?.ToString() ?? "" : "";
            }
            set
            {
                if (ComboBox.Items.Contains(value))
                {
                    ComboBox.SelectedItem = value;
                }
                else
                {
                    ComboBox.SelectedIndex = -1;
                }
            }
        }

        public void Clear()
        {
            Items.Clear();
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _сhangeEvent?.Invoke(this, e);
        }
    }
}
