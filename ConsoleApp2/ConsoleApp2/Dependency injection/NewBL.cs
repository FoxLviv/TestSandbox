using LearnBasics.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnBasics.Sandbox.Dependency_injection
{
    class NewBL
    {
        private ILogger _log;

        public NewBL(ILogger log)
        {
            _log = log;
        }

        public void DoSome(string data)
        {
            _log.Print(data);
        }
    }
}
