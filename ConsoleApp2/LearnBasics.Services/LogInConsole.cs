using LearnBasics.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBasics.Services
{
    public class LogInConsole : ILogger
    {
        public void Print(string data)
        {
            Console.WriteLine(data);
        }
    }
}
