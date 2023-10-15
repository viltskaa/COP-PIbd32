using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace EmployeesView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void AddNewElement()
        {
   
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewElement();
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormPost>();
            form.ShowDialog();
        }
    }
}
