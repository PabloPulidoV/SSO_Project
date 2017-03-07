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
        Processwindow wp; //= new Processwindow();
        //public List<Process> ls = new List<Process>();
        public List<Process>[] ls = new List<Process>[100];
        public System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();

        string ld, id, op, name, tmpt;
        public int cantProcess, timing, TT = 0, TR = 0, controlP, sh1= 0, sh2 = 0, numlot, lotIND, reloj = 0, kd = 1;
        public int num, iTTR;
        public static int h;
        string value;

        public void uno (Processwindow pw)
        {
            wp = pw;
        }

        
        public void IniProcess(List<Process>[] pro)
        {
            ls = pro;
            cantProcess = ls[0].Count;
            controlP = cantProcess;
            wp.LoteEjec.DataSource = ls[0];
            arrayUse();
            
            wp.Show();
            EjecProcess();
 
        }

        public void arrayUse()
        {
            for(int i= 0; i <= 100; i++)
            {
                if(ls[i] == null)
                {
                    break;
                }
                else
                {
                    numlot++;
                    continue;
                }
            }
        }

        public bool CheckIFNum(string str)
        {

            int n;
            bool isNum = int.TryParse(str, out n);
            num = n;
            h = num;
            return isNum;

        }

        public bool CheckIFNum2(string str)
        {

            int n;
            bool isNum = int.TryParse(str, out n);
            iTTR = n;
            return isNum;

        }

        public void SendToFinal(int a, bool error)
        {
            id = wp.LoteEjec.Rows[a].Cells["IDs"].Value.ToString();
            op = wp.textBox3.Text = wp.LoteEjec.Rows[a].Cells["OP"].Value.ToString();
            name = wp.LoteEjec.Rows[a].Cells["Nombre"].Value.ToString();
            tmpt = wp.LoteEjec.Rows[a].Cells["TE"].Value.ToString();
            EvaOp(op,id,true,error);                      

        }

        public void Interrupt()
        {

            GetCurrentProcess(sh1);

            Process pr2 = new Process();

            pr2.IDs = id;
            pr2.Nombre = name;
            pr2.TE = tmpt;
            pr2.OP = op;
            pr2.TT = TT;
            pr2.TR = TR;
            pr2.Flag = "1";

            ls[lotIND].Add(pr2);
            //controlP++;

            EliminateProcess(false);

            TT = 0;
            TR = 0;
        }

        public void GetCurrentProcess(int index)
        {
            id = wp.LoteEjec.Rows[index].Cells["IDs"].Value.ToString();
            op = wp.LoteEjec.Rows[index].Cells["OP"].Value.ToString();
            name = wp.LoteEjec.Rows[index].Cells["Nombre"].Value.ToString();
            tmpt = wp.LoteEjec.Rows[index].Cells["TE"].Value.ToString();


        }

        public void EliminateProcess(bool Ekey)
        {
            if(Ekey == true)
            {
                controlP--;
            }
            ls[lotIND].RemoveAt(sh1);
            wp.LoteEjec.DataSource = null;
            wp.LoteEjec.Rows.Clear();
            wp.LoteEjec.Refresh();
            wp.LoteEjec.DataSource = ls[lotIND];

            TT = 0;
            TR = 0;
        }

        public bool  EvaOp(string op, string id, bool active, bool error)
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
                    if (active == true)
                    {
                        if (error == false)
                        {
                            wp.LoteFinal.Rows.Add(id, op, value);
                            return true;
                        }
                        else if (error == true)
                        {
                            wp.LoteFinal.Rows.Add(id, op, "ERROR");
                            return true;
                        }
                        
                    }

                    return true;                

                }

            }
            catch (Exception e)
            {
                MessageBox.Show("ID: " + id + "\nLa operación ingresada no es valida.");
                return false;
            }
         
        }

        public void incTT()
        {
            if (TT <= num)
            {
                
                wp.textBox5.Text = TT.ToString();
                wp.textBox6.Text = TR.ToString();
                wp.textBox7.Text = numlot.ToString();
                wp.textBox8.Text = reloj.ToString();
                reloj++;
                TT++;
                TR = h-TT;               

            }
            else if (TT >= num)
            {
                controlP--;

                if (controlP == 0)
                {
                    numlot--;

                    if(numlot == 0)
                    {
                        SendToFinal(sh1, false); 
                        t.Stop();
                        wp.textBox7.Text = "0";
                        MessageBox.Show("El proceso termino");
                    }
                    else
                    {
                        SendToFinal(sh1, false);
                        EliminateProcess(false);
                        lotIND++;
                        //sh1 = 0;
                        TT = 0;
                        TR = 0;
                        cantProcess = ls[lotIND].Count;
                        controlP = cantProcess;
                        wp.LoteEjec.DataSource = ls[lotIND];
                    }
                    
                }
                else if (controlP > 0)
                {
                    SendToFinal(sh1, false);
                    EliminateProcess(false);
                    //sh1++;
                    TT = 0;
                    TR = 0;
                }

            }

        }
        
        private void setProcess(int a)
        {
            string flg;
 
            CheckIFNum(wp.LoteEjec.Rows[a].Cells["TE"].Value.ToString());
            timing = num;
            wp.textBox1.Text = wp.LoteEjec.Rows[a].Cells["IDs"].Value.ToString();
            wp.textBox2.Text = wp.LoteEjec.Rows[a].Cells["Nombre"].Value.ToString();
            wp.textBox3.Text = wp.LoteEjec.Rows[a].Cells["OP"].Value.ToString();
            wp.textBox4.Text = wp.LoteEjec.Rows[a].Cells["TE"].Value.ToString();

            flg = wp.LoteEjec.Rows[a].Cells["Flag"].Value.ToString();

            if (flg == "1")
            {
                CheckIFNum2(wp.LoteEjec.Rows[a].Cells["TT"].Value.ToString());
                TT = iTTR;
                CheckIFNum2(wp.LoteEjec.Rows[a].Cells["TR"].Value.ToString());
                TR = iTTR;
                wp.LoteEjec.Rows[a].Cells["Flag"].Value = "0";
            }
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
