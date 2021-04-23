using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LearnBasics.Sandbox.Patterns
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public string Date { get; private set; }

        private Singleton()
        {
            Date = "Day ";  //DateTime.Now.TimeOfDay.ToString();
        }

        public static Singleton GetInstance()
        {
            return instance;
        }
    }
    public class SingletonExample
    {
        public void Example()
        {
            (new Thread(() =>
            {                
                var singleton2 = Singleton.GetInstance();
                Console.WriteLine(singleton2.Date + "1");
                
            })).Start();
            (new Thread(() =>
            {
                var singleton3 = Singleton.GetInstance();
                Console.WriteLine(singleton3.Date + "2");
                
            })).Start();
            (new Thread(() =>
            {
                var singleton3 = Singleton.GetInstance();
                Console.WriteLine(singleton3.Date+"3");
            })).Start();

            var singleton1 = Singleton.GetInstance();
            Console.WriteLine(singleton1.Date + "4");
        }
    }
}
