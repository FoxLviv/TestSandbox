using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class TypesExercises
    {
        public int TestReferenceType()
        {
            var tmp = new A();
            tmp.Prop = 10;
            A b = tmp;

            EvaluateA(b);
            Console.WriteLine(tmp.Prop);
            return 1;
        }

        public void Test2CloneReferenceType() /*https://docs.microsoft.com/ru-ru/dotnet/api/system.object.memberwiseclone?redirectedfrom=MSDN&view=net-5.0*/
        {
            var tmp = new A();
            tmp.Prop = 10;
            tmp.BClassValue = new B(16.6);

            //var testSwallowCopy = tmp.SwallowCopy();
            //EvaluateACopy(testSwallowCopy);

            var testDeepCopy = tmp.DeepCopy();
            EvaluateACopy(testDeepCopy);

            Console.WriteLine(tmp.Prop);
            Console.WriteLine(tmp.BClassValue.DeeperValue);
        }

        private void EvaluateA(A tmp)
        {
            int temp = 5;
            tmp.Prop = temp + tmp.Prop;
        }

        private void EvaluateACopy(A tmp)
        {
            int valTypeAdd = 5;
            double refTypeAdd = 3.4;
            tmp.Prop = valTypeAdd + tmp.Prop;
            tmp.BClassValue.DeeperValue += refTypeAdd;
        }

        public void BoxingExample()
        {
            int valType = 123;
            object refType = valType;
            Unboxing(refType);
            Console.WriteLine((int)refType);
        }

        private void Unboxing(object obj)
        {
            int res = 0;
            try
            {
                 res = (int)obj;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            res = res + 321;
            obj = res;
        }
    }

    public class A
    {
        public int Prop;
        public B BClassValue;

        public A DeepCopy()
        {
            var other = (A)this.MemberwiseClone();
            other.BClassValue = new B(BClassValue.DeeperValue);
            return other;
        }

        public A SwallowCopy()
        {
            return (A)this.MemberwiseClone();
        }
    }

    public class B
    {
        public double DeeperValue;

        public B(double DeeperValue)
        {
            this.DeeperValue = DeeperValue;
        }
    }

    public abstract class Car
    {
        public abstract void Service();
    }

    public interface IMovable
    {
        void Move();
    }
}
