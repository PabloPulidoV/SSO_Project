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
    public partial class Select_Process : Form
    {
        Random rnd = new Random();
        public List<Process>[] list1 = new List<Process>[100];
        DataMan DM = new DataMan();
        int CantProcess = 0, rndm = 0, NumA, NumE, ID, Ops, TT, ListInd = 0, numlot;
        string OP, cOp, IDs;
        string[] OpArray = { "+", "-", "/", "*" };

         

        public Select_Process()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numlot = 0;
            list1[0] = new List<Process>();
            CantProcess = int.Parse(comboBox1.Text);
            
            for (int i = 1; i<= CantProcess; i++)
            {
                Process pr = new Process();
                
                GenID();
                GenOp();
                GenTE();

                numlot++;               
                pr.IDs = ID.ToString();
                pr.OP = cOp;
                pr.TE = TT.ToString();
                pr.Nombre = "--";
                pr.Flag = "0";

                if (numlot <= 4)
                {
                    list1[ListInd].Add(pr);
                }
                else if (numlot > 4)
                {
                    ListInd++;
                    numlot = 1;
                    list1[ListInd] = new List<Process>();
                    list1[ListInd].Add(pr);
                }

            }

            this.Hide();
            Processwindow wp1 = new Processwindow(list1);
            wp1.Show();
        }

        private string GenOp()
        {
            Ops = rnd.Next(0,3);
            OP = OpArray[Ops];
            NumA = rnd.Next(0, 1000);
            NumE = rnd.Next(0, 1000);

            cOp = NumA.ToString() + OP + NumE.ToString();

            return cOp;

        }

        private int GenID()
        {
            ID = rnd.Next(1, 1000);
            return ID;
        }

        private int GenTE()
        {
            TT = rnd.Next(1, 20);
            return TT;
        }

    }
}
