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
        int CurrentRow, IDs = 1, count = 0, num = 0, ind = 0;
        bool checkN;
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
            ind = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Process pr = new Process();
                ind++;
                pr.IDs = (string)row.Cells["ID"].Value;
                pr.Nombre = (string)row.Cells["NombProg"].Value;
                pr.TE = (string)row.Cells["TME"].Value;
                pr.OP = (string)row.Cells["Op"].Value;

                int cu = dataGridView1.RowCount;
                if (cu == ind)
                {
                    //SOLO PARA IGNORAR LA ULTIMA LINEA
                    continue;
                }
                else
                {
                    checkN =  dt.CheckIFNum(pr.TE);
                    if(dt.EvaOp(pr.OP,pr.IDs) == false)
                    {
                        return;
                    }

                    if (checkN == false || dt.num <= 0)
                    {
                        MessageBox.Show("ID: " + pr.IDs + "\nEl tiempo estimado (TE) ingresado no es un numero o es menor o igual a 0.");
                        return;
                    }
                    else
                    {
                        list1.Add(pr);
                    }
                }
 
            }

            count = list1.Count();

            if (count < 1)
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
