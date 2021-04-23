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

            IU.RegisterType<BL>();
            IU.RegisterType<DL>();

            IU.RegisterType<IProduct, DL>();

            BL objDL = IU.Resolve<BL>();
            objDL.Insert();
            Console.ReadKey();
        }
    }
}
