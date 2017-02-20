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

        public List<Process> ls = new List<Process>();
        string ld;
        int lt,clt;


        public void recorrer() //Se encarga de recorrer la lista. 
        {
            foreach(Process pr in ls)
            {
                ld = pr.Nombre;
                
            }
        }

        public void Lotescount()
        {
            
        }

    }

}
