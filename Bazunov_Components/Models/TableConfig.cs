using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazunov_Components.Models
{
    public class TableConfig : DocumentConfig
    {
        public List<string[,]> Data { get; set; }

        public void CheckFields()
        {
            if (Data == null || Data.Count == 0 || Data.All((string[,] x) => x.Length == 0))
            {
                throw new ArgumentNullException("Нет данных для вставки в документ");
            }
        }
    }
}
