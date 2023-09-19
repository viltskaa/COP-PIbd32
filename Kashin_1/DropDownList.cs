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
        //Публичное свойство, которое передает ссылку на
        //свойство Items элемента ComboBox, через которое и идет
        //заполнение
        public ComboBox.ObjectCollection Items => ComboBox.Items;

        public event EventHandler _сhangeEvent;

        //событие, вызываемое при смене значения ComboBox
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

        //Публичное свойство (set, get) для установки и получения выбранного значения (возвращает пустую строку, если нет выбранного значения)
        public string SelectedValue
        {
            get { return ComboBox.SelectedItem?.ToString() ?? ""; }
            set { ComboBox.SelectedItem = value; }
        }

        //Отдельный публичный метод отчистки списка.
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
