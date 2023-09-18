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
        private string example = "Введите значение от "+ decimal.MinValue + " до " + decimal.MaxValue;

        //В случае ошибки
        public string Error { get; protected set; } = string.Empty;

        //2 публичных поля для настройки границ диапазона

        [Category("Спецификация")]
        [Description("Минимальное число")]
        public decimal MinValue { get; set; } = decimal.MinValue;


        [Category("Спецификация")]
        [Description("Максимальное число")]
        public decimal MaxValue { get; set; } = decimal.MaxValue;

        public bool SetBorders(string minval, string maxval)
        {
            if (Decimal.Parse(maxval) < Decimal.Parse(minval))
            {
                Error = "Введенный диапазон \n неверен, MinValue должен \n быть меньше, чем MaxValue";
                return false;
            }
            MinValue = Decimal.Parse(minval);
            MaxValue = Decimal.Parse(maxval);
            example = "Введите значение от " + MinValue + " до " + MaxValue;
            return true;
        }

        [Category("Спецификация")]
        [Description("Значение")]
        //Публичное свойство для установки и получения введенного значения(set, get). При получении проводиться проверка,
        //если введенное значение не входит в диапазон, возвращать
        //значение null, а в отдельное поле выводить текст ошибки.При
        //установке должна проводиться проверка, если передаваемое
        //значение не входит в диапазон, то не заполнять поле компонента.
        public decimal? Value
        {
            get
            {
                if (numericUpDown.Value >= MinValue && numericUpDown.Value <= MaxValue)
                {
                    return numericUpDown.Value;
                }
                Error = "Введенное значение" + " лежит \n вне диапазона " + MinValue + " - " + MaxValue;
                return null;
            }
            set
            {
                decimal? num = value;
                decimal minValue = MinValue;
                int num2;
                if ((num.GetValueOrDefault() > minValue) & num.HasValue)
                {
                    num = value;
                    minValue = MaxValue;
                    num2 = (((num.GetValueOrDefault() < minValue) & num.HasValue) ? 1 : 0);
                }
                else
                {
                    num2 = 0;
                }

                if (num2 != 0)
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

        [Category("Спецификация")]
        [Description("Событие смены значения")]
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
