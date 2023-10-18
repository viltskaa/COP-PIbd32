using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponent
{
    public partial class ListBoxMany : UserControl
    {
        private string LayoutString;
        private string StartS;
        private string EndS;
        private int SelectedStr;

        public ListBoxMany()
        {
            InitializeComponent();
        }

        public int SelectedIndex
        {
            get
            {
                if (listBox.SelectedIndex == -1)
                {
                    return -1;
                }
                return listBox.SelectedIndex;
            }
            set
            {
                if (listBox.Items.Count != 0)
                {
                    listBox.SelectedIndex = value;
                }
            }
        }
        public void SetLayout(string layoutString, string startS, string endS)
        {
            if (layoutString == null || startS == null || endS == null) return;
            LayoutString = layoutString;
            StartS = startS;
            EndS = endS;
        }
        public void AddItemInList<T>(T Object, int rowIndex, int columnIndex)
        {
            if (Object == null)
            {
                throw new ArgumentNullException();
            }

            if (listBox.Items.Count <= rowIndex)
            {
                for (int i = listBox.Items.Count; i <= rowIndex; i++)
                {
                    listBox.Items.Add(LayoutString);
                }
            }

            string str = listBox.Items[rowIndex].ToString();

            var properties = Object.GetType().GetProperties();
            if (columnIndex < properties.Length)
            {
                var prop = properties[columnIndex];
                string str1 = $"{StartS}{prop.Name}{EndS}";
                str = str.Replace(str1, prop.GetValue(Object)?.ToString());
            }

            listBox.Items[rowIndex] = str;
        }


        public T GetItemFromList<T>() where T : class, new()
        {
            string SelectedStr = "";
            if (listBox.SelectedIndex != -1)
            {
                SelectedStr = listBox.SelectedItem.ToString();
            }

            T currentObject = new T();

            foreach (var prop in typeof(T).GetProperties())
            {
                if (!prop.CanWrite)
                {
                    continue;
                }
                int startS = SelectedStr.IndexOf(StartS);
                int endS = SelectedStr.IndexOf(EndS);
                if (startS == -1 || endS == -1)
                {
                    break;
                }
                string propValue = SelectedStr.Substring(startS + 1, endS - startS - 1);
                SelectedStr = SelectedStr.Substring(endS + 1);
                prop.SetValue(currentObject, Convert.ChangeType(propValue, prop.PropertyType));
            }
            return currentObject;
        }
    }
}
