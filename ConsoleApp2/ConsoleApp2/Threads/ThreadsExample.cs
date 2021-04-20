using System;
using System.Threading;
using System.Threading.Tasks;

namespace LearnBasics.SandBox.Threads
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

            var thread = new Thread(new ThreadStart(GetMyName));
            thread.Start();
            Console.ReadKey();
        }

        private void GetMyName()
        {
            Console.WriteLine("Andriy");
        }

        public void SideFunc(object stateInfo)
        {
            Console.WriteLine("Hello from second funtion");
        }

        public void More(object stateInfo)
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
            var thread1 = new Thread(ObliviousFunction);
            var thread2 = new Thread(BlindFunction);

            thread1.Start();
            thread2.Start();

            while (true)
            {
                // Stare at the two threads in deadlock.
            }
        }
    }
}
