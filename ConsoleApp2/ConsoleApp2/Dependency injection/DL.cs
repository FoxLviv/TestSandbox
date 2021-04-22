using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBasics.Sandbox.Dependency_injection
{
    class DL : IProduct
    {
        public string InsertData()
        {
            string val = "Dependency injection injected";
            Console.WriteLine(val);
            return val;
        }
    }
}
