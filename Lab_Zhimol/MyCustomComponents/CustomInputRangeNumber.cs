using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ToolTip = System.Windows.Forms.ToolTip;

namespace MyCustomComponents
{
    public partial class CustomInputRangeNumber : UserControl
    {
        //Диапазон
        private string example = "Введите значение от "+ decimal.MinValue + " до " + decimal.MaxValue;

        //В случае ошибки
        public string Error { get; protected set; } = string.Empty;

        //2 публичных поля для настройки границ диапазона
        public decimal? MinValue { get; set; }
        public decimal? MaxValue { get; set; }

        //Публичное свойство для установки и получения введенного значения(set, get). При получении проводиться проверка,
        //если введенное значение не входит в диапазон, возвращать
        //значение null, а в отдельное поле выводить текст ошибки.При
        //установке должна проводиться проверка, если передаваемое
        //значение не входит в диапазон, то не заполнять поле компонента.
        public decimal? Value
        {
            get
            {
                if (MinValue == null || MaxValue == null)
                {
                    Error = "Диапазон не задан";
                    return null;
                }
                if (numericUpDown.Value >= MinValue && numericUpDown.Value <= MaxValue)
                {
                    return numericUpDown.Value;
                }
                Error = "Введенное значение" + " лежит \n вне диапазона " + MinValue + " - " + MaxValue;
                return null;
            }
            set
            {
                if (MinValue == null || MaxValue == null)
                {
                    Error = "Диапазон не задан";
                }
                if (value >= MinValue && value <= MaxValue && value.HasValue)
                {
                    numericUpDown.Value = value.Value;
                }
            }
        }

        public CustomInputRangeNumber()
        {
            InitializeComponent();
        }

        private void numericUpDown_Enter(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.Show(example, numericUpDown, 30, -20, 1000);
        }

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _changeEvent?.Invoke(sender, e);
        }

        private EventHandler _changeEvent;

        //Cобытие, вызываемое при смене значения.
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
