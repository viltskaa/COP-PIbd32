using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormTest
{
    public class DaysOfWeek
    {
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public int Temperature { get; set; }
        public DaysOfWeek(DateTime date, string day, int temperature)
        {
            Date = date;
            Day = day;
            Temperature = temperature;
        }
        public DaysOfWeek() { }
    }
}
