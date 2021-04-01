using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CSharpThreadTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Threads counting from 1 to 10
            Thread t = new Thread(() => PrintNumber(1));

            t.Start();

            PrintNumber(0);

            t.Join();

            Console.WriteLine();

            // Threads for withdrawing from BankAcct class
            BankAcct acct = new BankAcct(10);
            Thread[] threads = new Thread[15];
            Thread.CurrentThread.Name = "main";
            for (int i = 0; i < 15; i++)
            {
                // ThreadStart (and ParameterizedThreadStart) delegate
                /*
                    Thread tmpT = new Thread(new ThreadStart(acct.IssueWithThread));
                    Thread tmpT = new Thread(new ThreadStart(() =>
                    {
                        acct.Withdraw(1);
                    }));
                */
                Thread tmpT = new Thread(() => { acct.Withdraw(1); });
                tmpT.Name = i.ToString();
                threads[i] = tmpT;
            }
            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Thread {0} isAlive: {1}", threads[i].Name, threads[i].IsAlive);
                threads[i].Start();
                Console.WriteLine("Thread {0} isAlive: {1}", threads[i].Name, threads[i].IsAlive);
            }

            Console.WriteLine("Current Priority: {0}", Thread.CurrentThread.Priority);

            Console.ReadLine();
        }

        static void PrintNumber(int num)
        {
            for (int i = 0; i < 100; i++)
            {
                // Thread.Sleep(100);
                Console.Write(num);
            }
        }
    }
}
