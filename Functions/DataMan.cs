using Sem_SO_Project.Class;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Sem_SO_Project.Functions
{
    public class DataMan
    {
        Processwindow wp = new Processwindow();
        public List<Process> ls = new List<Process>();
        System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        string ld, id, op, res;
        int cantProcess, timing, TT = 0, TR = 0, controlP, sh1= 0;
        public int num;
        public static int h;
        string value;



        public void recorrer() //Se encarga de recorrer la lista. 
        {
            foreach(Process pr in ls)
            {
                ld = pr.Nombre;
            }
        }

        public void IniProcess(List<Process> pro)
        {
            ls = pro;
            cantProcess = ls.Count;
            controlP = cantProcess;
            wp.LoteEjec.DataSource = pro;
            wp.Show();
            EjecProcess();
        }

        public bool CheckIFNum(string str)
        {

            int n;
            bool isNum = int.TryParse(str, out n);
            num = n;
            h = num;
            return isNum;

        }

        public void SendToFinal(int a)
        {
            id = wp.LoteEjec.Rows[a].Cells["IDs"].Value.ToString();
            op = wp.textBox3.Text = wp.LoteEjec.Rows[a].Cells["OP"].Value.ToString();
            //res = "0";
            EvaOp(op,id);
            

        }
        
        public bool  EvaOp(string op, string id)
        {
            try
            {
                string math = op;
                value = new DataTable().Compute(math, null).ToString();
                if (String.IsNullOrEmpty(value))
                {
                    return false;
                }
                else
                {
                    wp.LoteFinal.Rows.Add(id, op, value);
                    return true;

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("ID: " + id + "\La operación ingresada no es valida.");
                return false;
            }
         
        }



        public void incTT()
        {
            if (TT <= num)
            {
                
                wp.textBox5.Text = TT.ToString();
                wp.textBox6.Text = TR.ToString();
                TT++;
                TR = h-TT;               

            }
            else if (TT >= num)
            {
                controlP--;

                if (controlP == 0)
                {
                    SendToFinal(sh1);
                    t.Stop();

                    MessageBox.Show("El proceso termino");
                }
                else if (controlP > 0)
                {
                    SendToFinal(sh1);
                    sh1++;
                    TT = 0;
                    TR = 0;
                }

            }

        }
        
        private void setProcess(int a)
        {
            
            CheckIFNum(wp.LoteEjec.Rows[a].Cells["TE"].Value.ToString());
            timing = num;
            wp.textBox1.Text = wp.LoteEjec.Rows[a].Cells["IDs"].Value.ToString();
            wp.textBox2.Text = wp.LoteEjec.Rows[a].Cells["Nombre"].Value.ToString();
            wp.textBox3.Text = wp.LoteEjec.Rows[a].Cells["OP"].Value.ToString();
            wp.textBox4.Text = wp.LoteEjec.Rows[a].Cells["TE"].Value.ToString();

           
        }

        public void timer_Tick(object sender, EventArgs e)
        {

            setProcess(sh1);
            incTT();
           
        }

        public  void geTiming()
        {
           
             t.Interval = 1000; // specify interval time as you want
             t.Tick += new EventHandler(timer_Tick);
             t.Start();
        }

        public  void EjecProcess()
        {

            geTiming();

        }

    }  

}
