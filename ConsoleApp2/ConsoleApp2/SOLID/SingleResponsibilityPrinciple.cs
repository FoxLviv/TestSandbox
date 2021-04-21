using System;
using System.Collections.Generic;
using System.IO;

namespace LearnBasics.Sandbox.SOLID
{
    class SingleResponsibilityPrinciple
    {
        public void Example()
        {
            var store = new MobileStore(
                new ConsolePhoneReader(), new GeneralPhoneBinder(),
                new GeneralPhoneValidator(), new TextPhoneSaver());
            store.Process();
        }
    }
    class Phone
    {
        public string Model { get; set; }
        public int Price { get; set; }
    }

    class MobileStore
    {
        private List<Phone> _phones = new List<Phone>();

        public IPhoneReader Reader { get; set; }
        public IPhoneBinder Binder { get; set; }
        public IPhoneValidator Validator { get; set; }
        public IPhoneSaver Saver { get; set; }

        public MobileStore(IPhoneReader reader, IPhoneBinder binder, IPhoneValidator validator, IPhoneSaver saver)
        {
            Reader = reader;
            Binder = binder;
            Validator = validator;
            Saver = saver;
        }

        public void Process()
        {
            PhoneModel data = Reader.GetInputData();
            var phone = Binder.CreatePhone(data);
            if (Validator.IsValid(phone))
            {
                _phones.Add(phone);
                Saver.Save(phone, "store.txt");
                Console.WriteLine("Data succesfully analysed");
            }
            else
            {
                Console.WriteLine("Incorrect data");
            }
        }
    }

    class PhoneModel
    {
        public string Model { get; set; }
        public string Price { get; set; }
        public PhoneModel(string model, string price)
        {
            Model = model;
            Price = price;
        }
    }

    interface IPhoneReader
    {
        PhoneModel GetInputData();
    }
    class ConsolePhoneReader : IPhoneReader
    {
        public PhoneModel GetInputData()
        {
            Console.WriteLine("Input model:");
            string model = Console.ReadLine();
            Console.WriteLine("Input price:");
            string price = Console.ReadLine();
            return new PhoneModel ( model, price );//class
        }
    }

    interface IPhoneBinder
    {
        Phone CreatePhone(PhoneModel data);
    }

    class GeneralPhoneBinder : IPhoneBinder
    {
        public Phone CreatePhone(PhoneModel data)
        {
            if (data != null)
            {
                int price = 0;
                if (Int32.TryParse(data.Price, out price))
                {
                    return new Phone { Model = data.Price, Price = price };
                }
                else
                {
                    throw new Exception("Model binder erorr for Phone. Incorrect data for Price");
                }
            }
            else
            {
                throw new Exception("Model binder erorr for Phone. Not enough data to create model");
            }
        }
    }

    interface IPhoneValidator
    {
        bool IsValid(Phone phone);
    }

    class GeneralPhoneValidator : IPhoneValidator
    {
        public bool IsValid(Phone phone)
        {
            if (String.IsNullOrEmpty(phone.Model) || phone.Price <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }
    }

    interface IPhoneSaver
    {
        void Save(Phone phone, string fileName);
    }

    class TextPhoneSaver : IPhoneSaver
    {
        public void Save(Phone phone, string fileName)
        {
            using (var writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(phone.Model);
                writer.WriteLine(phone.Price);
            }
        }
    }
}
