using Sem_SO_Project.Functions;
using Sem_SO_Project.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sem_SO_Project
{
    public partial class Processwindow : Form
    {
        DataMan dt1 = new DataMan();
        public Processwindow(List<Process> pro)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt1.recorrer();
        }
    }

}
