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

    
    public partial class Form1 : Form
    {
        int CurrentRow, IDs = 1;
        string sCurrentRow;


        public Form1()
        {
            InitializeComponent();
            IniRowID();
        
        }

        private void start_Click(object sender, EventArgs e)
        {

        /*    List<MyClass> list = new List<MyClass>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
              
            }
        */
            this.Hide();

            Processwindow WinProcess = new Processwindow();

            WinProcess.Show();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            CurrentRow = dataGridView1.CurrentRow.Index;
            IDs += 1;
            sCurrentRow = IDs.ToString();     
            dataGridView1.Rows[CurrentRow+1].Cells["ID"].Value = sCurrentRow;
        }

        private void IniRowID()
        {
            dataGridView1.Rows[0].Cells["ID"].Value = "1";
        }

    }
}
