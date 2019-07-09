using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RaceCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread[] tr = new Thread[5];

            for(int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(t.Calculate));
                tr[i].Name = String.Format($"Working Thread: {i}");
            }

            //Start each thread
            foreach(Thread x in tr)
            {
                x.Start();
            }
        }
    }
}
