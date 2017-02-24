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
        //DataMan dt1 = new DataMan();

        public Processwindow()
        {
            InitializeComponent();
        }

        public void change(string h, List<Process> pp1)
        {
            this.textBox7.Text = h;

            LoteEjec.DataSource = pp1;
           
            
        }

    }

}
