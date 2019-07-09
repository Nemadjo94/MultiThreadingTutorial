using System;
using System.Threading;

namespace Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            Thread[] tr = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                tr[i] = new Thread(new ThreadStart(t.Calculate));
                tr[i].Name = String.Format($"Working Thread: {i}");
            }

            //Start each thread
            foreach (Thread x in tr)
            {
                x.Start();
            }
        }
    }
}
