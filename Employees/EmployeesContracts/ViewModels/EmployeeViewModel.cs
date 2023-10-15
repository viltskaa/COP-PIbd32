using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesContracts.ViewModels
{
    public class EmployeeViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string Name { get; set; }

        [DisplayName("Автобиография")]
        public string Autobiography { get; set; }
        [DisplayName("Должность")]
        public string Post { get; set; }
        [DisplayName("Дата повышения квалификации")]
        public DateTime? Upgrade { get; set; }
    }
}
