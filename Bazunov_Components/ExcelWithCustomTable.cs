using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazunov_Components
{
    public partial class ExcelWithCustomTable : Component
    {
        public ExcelWithCustomTable()
        {
            InitializeComponent();
        }

        public ExcelWithCustomTable(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
