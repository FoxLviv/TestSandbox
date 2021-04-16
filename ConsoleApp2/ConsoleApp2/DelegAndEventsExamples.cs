using System;

namespace ConsoleApp2
{
    class DelegAndEventsExamples
    {
        delegate void Message();

        public void Example()
        {
            Message mes;
            if (DateTime.Now.Hour < 12)
            {
                mes = GoodMorning;
            }
            else
            {
                mes = GoodEvening;
            }
            mes();
            mes += GoodEvening;
            mes();
            //Action
            Action<int, int> op;

            op = Add;
            Operation(10, 6, op);
            op = Substract;
            Operation(10, 6, op);

            //Predicate
            Predicate<int> isPositive = delegate (int x) { return x > 0; };
            Console.WriteLine(isPositive(20));
            Console.WriteLine(isPositive(-20));

            //Func
            Func<int, int> retFunc = Factorial;
            int n1 = GetInt(6, retFunc);
            Console.WriteLine(n1);  // 720
            int n2 = GetInt(6, x => x * x);
            Console.WriteLine(n2); // 36

            Account acc = new Account(100);
            acc.Notify += DisplayMessage;   // Добавляем обработчик для события Notify
            acc.Put(20);    // добавляем на счет 20
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(70);   // пытаемся снять со счета 70
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            acc.Take(180);  // пытаемся снять со счета 180
            Console.WriteLine($"Сумма на счете: {acc.Sum}");
            Console.Read();

        }

        static void Operation(int x1, int x2, Action<int, int> op)
        {
            if (x1 > x2)
                op(x1, x2);
        }
        static void Add(int x1, int x2)
        {
            Console.WriteLine("Сумма чисел: " + (x1 + x2));
        }
        static void Substract(int x1, int x2)
        {
            Console.WriteLine("Разность чисел: " + (x1 - x2));
        }

        static int GetInt(int x1, Func<int, int> retF)
        {
            int result = 0;
            if (x1 > 0)
                result = retF(x1);
            return result;
        }
        static int Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            return result;
        }

        private void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }
    }

    class Account
    {
        public delegate void AccountHandler(string message);
        public event AccountHandler Notify;              // 1.Определение события
        public Account(int sum)
        {
            Sum = sum;
        }
        public int Sum { get; private set; }
        public void Put(int sum)
        {
            Sum += sum;
            Notify?.Invoke($"На счет поступило: {sum}");   // 2.Вызов события 
        }
        public void Take(int sum)
        {
            if (Sum >= sum)
            {
                Sum -= sum;
                Notify?.Invoke($"Со счета снято: {sum}");   // 2.Вызов события
            }
            else
            {
                Notify?.Invoke($"Недостаточно денег на счете. Текущий баланс: {Sum}"); ;
            }
        }
    }
}
