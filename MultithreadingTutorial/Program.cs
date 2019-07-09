using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultithreadingTutorial
{
    class Program
    {

        static void myFun()
        {
            Console.WriteLine("Running other Thread");
        }

        static void myThread()
        {
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} started");
            Thread.Sleep(2000);
            Console.WriteLine($"Thread {Thread.CurrentThread.Name} completed");
        }

        static void Main(string[] args)
        {

            //Informacije o thread-u
            Console.WriteLine("***Current Thread Information***");
            Thread t = Thread.CurrentThread;
            t.Name = "Primary_Thread";
            Console.WriteLine($"Thread Name: {t.Name}");
            Console.WriteLine($"Thread Status: {t.IsAlive}");
            Console.WriteLine($"Priority: {t.Priority}");
            Console.WriteLine($"Context ID: {Thread.CurrentContext.ContextID}");
            Console.WriteLine($"Current application domain: {Thread.GetDomain().FriendlyName}");

            Console.WriteLine();

            //Single Thread Creation
            //U sledecem primeru objasnjavamo Thread klasu i njenu implementaciju u kome konstruktor
            //Thread klase prihvata parametar delegata. Posto je Thread klasa kreirana, zapocinjemo
            //thread sa Start() metodom
            Thread t2 = new Thread(myFun);
            t2.Start();
            Console.WriteLine("Main Thread Running");
            //Napomena: Posto OS odlucuje koji ce se thread izvrsiti
            //nema garancije koji ce thread biti prvi izvrsen

            Console.WriteLine();

            //Background Thread
            //Proces aplikacije tece sve dok makar jedan thread radi.
            //Ako imamo vise threadova koji se izvrsavaju u trenutku kada se Main metoda zavrsi
            //proces aplikacije se nastavlja sve dok svi threadovi ne zavrse svoj rad
            //Kada kreiramo Thread mozemo ga definisati kao ili foreground ili background thread pomocu propertija isBackground

            Thread t3 = new Thread(myThread);
            t3.Name = "Thread3";
            t3.IsBackground = false;
            t3.Start();
            Console.WriteLine($"{t3.Name} running");


        }
    }
}
