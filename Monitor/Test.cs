using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Monitor
{
    public class Test
    {
        private object tLock = new object();

        public void Calculate()
        {
            Monitor.Enter(tLock);
            using (Monitor.Enter(tLock))
            {


                Console.WriteLine($"{Thread.CurrentThread.Name} is executing");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(new Random().Next(5));
                    Console.Write($" {i},");
                }
                Console.WriteLine();
            }
        }
    }
}
