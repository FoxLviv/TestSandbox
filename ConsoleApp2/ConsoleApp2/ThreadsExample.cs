using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class ThreadsExample
    {
        public void Example()
        {
            ThreadPool.QueueUserWorkItem(SideFunc);
            ThreadPool.QueueUserWorkItem(More);
            Console.WriteLine("Main func do something, then sleep");
            Thread.Sleep(100);
            Console.WriteLine("Main thread exits");

            var task = Task.Run(() => Console.WriteLine("Hello Task!"));

            var thread = new Thread(new ThreadStart(getMyName));
            thread.Start();
            Console.ReadKey();
        }

        private void getMyName()
        {
            Console.WriteLine("Andriy");
        }

        public void SideFunc(Object stateInfo)
        {
            Console.WriteLine("Hello from second funtion");
        }

        public void More(Object stateInfo)
        {
            Console.WriteLine("Hello from third funtion");
        }

        //Stack overflow example
        object object1 = new object();
        object object2 = new object();

        public void ObliviousFunction()
        {
            lock (object1)
            {
                Thread.Sleep(1000); // Wait for the blind to lead
                lock (object2)
                {
                }
            }
        }

        public void BlindFunction()
        {
            lock (object2)
            {
                Thread.Sleep(1000); // Wait for oblivion
                lock (object1)
                {
                }
            }
        }

        public void DeadLockExample()
        {
            var thread1 = new Thread((ThreadStart)ObliviousFunction);
            var thread2 = new Thread((ThreadStart)BlindFunction);

            thread1.Start();
            thread2.Start();

            while (true)
            {
                // Stare at the two threads in deadlock.
            }
        }
    }
}
