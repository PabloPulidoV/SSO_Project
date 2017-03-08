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
        //DataMan dt;
        DataMan dt = new DataMan();
        public List<Process>[] ls = new List<Process>[100];

        public Processwindow(List<Process>[]ll)
        {

            if (ll == null)
            {
                MessageBox.Show("La lista esta Vacía");
            }
            else
            {
                InitializeComponent();
                dt.uno(this);
                dt.IniProcess(ll);
            }

        }

        private void Processwindow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.I)
            {
                dt.Interrupt();

            }
            else if (e.KeyChar == (char)Keys.E)
            {
                dt.SendToFinal(0, true);
                dt.EliminateProcess(true);
            }
            else if (e.KeyChar == (char)Keys.C)
            {
                dt.t.Start();
            }
            else if (e.KeyChar == (char)Keys.P)
            {
               
                dt.t.Stop();
            }
        }

    
    }

}
