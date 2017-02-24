using Sem_SO_Project.Class;
using Sem_SO_Project.Functions;
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
        int CurrentRow, IDs = 1, count = 0;
        string sCurrentRow;
        public List<Process> list1 = new List<Process>();
        DataMan dt = new DataMan();

        public Form1()
        {
            InitializeComponent();
            IniRowID(); 
        }

        private void start_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Process pr = new Process();

                pr.IDs = (string)row.Cells["ID"].Value;
                pr.Nombre = (string)row.Cells["NombProg"].Value;
                pr.TE = (string)row.Cells["TME"].Value;

                list1.Add(pr);
            }

            count = list1.Count();

            if (count < 2)
            {
                MessageBox.Show("La lista de Procesos esta vacía");
                return;
            }
            else
            {
                this.Hide();
                dt.IniProcess(list1);
            }
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
