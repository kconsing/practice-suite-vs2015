// With threads you can execute multiple pieces of code that share resources and data without corrupting it.
// Simple thread example, sleep, a more advanced with lock, Priority, and how to pass data to a thread.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Practice_Threads
{
    // LOCKS PRACTICE 

    class BankAcct
    {
        private Object acctLock = new object();
        double Balance { get; set; }

        public BankAcct(double bal)
        {
            Balance = bal;
        }

        public double Withdraw(double amt)
        {
            if((Balance - amt) < 0)
            {
                Console.WriteLine($"Sorry ${Balance} in Account");
                return Balance;
            }

            lock (acctLock)
            {
                Console.WriteLine("Removed {0} and {1} left in Account", amt, (Balance-amt));
                Balance -= amt;
            }
            return Balance; 
            // * NOTE: Threads can only point at methods without arguments or return nothing (void)
        }

        public void IssueWithdraw()
        {
            Withdraw(1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {


            Console.ReadLine();
        }

        static void ThreadsExample()
        {
            Thread t = new Thread(Print1);

              t.Start();

            for (int i = 0; i<1000; i++)
            {
                Console.Write(0);
            }

            Console.ReadLine();
        }

        static void Print1()
        {
        for(int i=0; i<1000; i++)
            {
                Console.Write(1);
            }
        }

        static void LockExample()
        {
            BankAcct acct = new BankAcct(10);

            Thread[] threads = new Thread[15];

            Thread.CurrentThread.Name = "main"; // You can name your current thread

            for (int i = 0; i < 15; i++)
            {
                Thread t = new Thread(new ThreadStart(acct.IssueWithdraw));
                t.Name = i.ToString();
                threads[i] = t;
            }

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Thread {0} Alive: {1}", threads[i].Name, threads[i].IsAlive); // Check if thread is currently started

                threads[i].Start();

                Console.WriteLine("Thread {0} Alive: {1}", threads[i].Name, threads[i].IsAlive);
            }

            Console.WriteLine("Current Priority : {0}", Thread.CurrentThread.Priority); // You change priority of Thread but doesn't guarantee it will take precedence. Normal is default.

            Console.WriteLine("Thread {0} Ending", Thread.CurrentThread.Name);
        }

        static void CountTo(int maxNum)
        {
            for(int i = 0; i <= maxNum; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void LambdaExpressionExample()
        {
            Thread t = new Thread(() => CountTo(10));
            t.Start();

            new Thread(() =>
            {
                CountTo(5);
                CountTo(6);
            }).Start();

            Console.ReadLine();
        }
    }

}
