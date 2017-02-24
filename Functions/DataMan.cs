using Sem_SO_Project.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_SO_Project.Functions
{
    public class DataMan
    {
        Processwindow WinProcess = new Processwindow();
        public List<Process> ls = new List<Process>();
        string ld;
        
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
            recorrer();
            WinProcess.Show();
            WinProcess.textBox7.Text = "100";
            WinProcess.textBox1.Text = "600";
            WinProcess.LoteEjec.DataSource = pro;
            //WinProcess.change("20", pro);
            //EjecProcess();
        }

        public void EjecProcess()
        {
            WinProcess.textBox7.Text = "100";
        }

    }  

}
