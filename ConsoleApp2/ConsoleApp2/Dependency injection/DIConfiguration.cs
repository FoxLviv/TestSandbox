using LearnBasics.Common;
using LearnBasics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace LearnBasics.Sandbox.Dependency_injection
{
    class DIConfiguration
    {
        public void Main()
        {
            var IU = new UnityContainer();

            //IU.RegisterType<BL>();
            //IU.RegisterType<DL>();

            //IU.RegisterType<IProduct, DL>();

            //BL objDL = IU.Resolve<BL>();
            //objDL.Insert();

            //LOGGER implementation
            IU.RegisterType<NewBL>();
            IU.RegisterType<LogInConsole>();
            IU.RegisterType<LogInFile>();

            IU.RegisterType<ILogger, LogInConsole>();
            IU.RegisterType<ILogger, LogInFile>();

            NewBL objDL = IU.Resolve<NewBL>();
            objDL.DoSome("hello");

            Console.ReadKey();
        }
    }
}
