using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Deadlock
{

    class Program
    {
        static object obj1 = new object();
        static object obj2 = new object();

        public static void DeadLock1()
        {
            lock (obj1)
            {
                Console.WriteLine("Thread 1 got locked");
                Thread.Sleep(500);

                lock (obj2)
                {
                    Console.WriteLine("Thread 2 got locked");
                }
            }
        }

        public static void DeadLock2()
        {
            lock (obj2)
            {
                Console.WriteLine("Thread 2 got locked");
                Thread.Sleep(500);
                lock (obj1)
                {
                    Console.WriteLine("Thread 1 got locked");
                }
            }
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DeadLock1));
            Thread t2 = new Thread(new ThreadStart(DeadLock2));
            t1.Start();
            t2.Start();
        }
    }
}
