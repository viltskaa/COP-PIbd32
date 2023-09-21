using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyCustomComponents
{
    public partial class CustomSelectedCheckedListBoxProperty : UserControl
    {
        //Публичное свойство, которое передает ссылку на
        //свойство Items элемента ComboBox, через которое и идет
        //заполнение
        public CheckedListBox.ObjectCollection Items => checkedListBox.Items;

        public CustomSelectedCheckedListBoxProperty()
        {
            InitializeComponent();
        }

        //Отдельный публичный метод отчистки списка.
        public void Clear()
        {
            checkedListBox.Items.Clear();
        }
        private EventHandler _changeEvent;

        private void checkedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changeEvent?.Invoke(sender, e);
        }

        //Cобытие, вызываемое при смене значения в CheckedListBox
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

        //Публичное свойство (set, get) для установки и получения выбранного значения (возвращает пустую строку, если нет выбранного значения)
        public string SelectedElement
        {
            get
            {
                return (checkedListBox.SelectedIndex > -1 && checkedListBox.GetItemChecked(checkedListBox.SelectedIndex)) ? checkedListBox.SelectedItem.ToString() : string.Empty;
            }
            set
            {
                if (checkedListBox.Items.Contains(value))
                {
                    checkedListBox.SelectedItem = value;
                }
            }
        }

        private void checkedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked && checkedListBox.CheckedItems.Count > 0)
            {
                checkedListBox.ItemCheck -= checkedListBox_ItemCheck;
                checkedListBox.SetItemChecked(checkedListBox.CheckedIndices[0], value: false);
                checkedListBox.ItemCheck += checkedListBox_ItemCheck;
            }
        }
    }
}
