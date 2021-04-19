using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class LinqExample
    {
        public void Example()
        {
            var refTypes = new List<Person>()
            {
                new Person { Name = "Magnus" },
                new Person { Name = "Adam" },
                new Person { Name = "Charlotte" }
            };
            refTypes.Add(new Person { Name = "Magnus" });
            var adam = new Person { Name = "Adam" };

            refTypes.Insert(3, adam);

            
            //try
            //{
            //    var firstMarvy = refTypes.First(p => p.Name == "Marvy");
            //    var firstOrDefMagnus = refTypes.FirstOrDefault(p => p.Name == "Magnus");
            //    var singleOrDefMagnus = refTypes.SingleOrDefault(p => p.Name == "Magnus");
            //    Console.WriteLine(firstMarvy);
            //    Console.WriteLine(firstOrDefMagnus);
            //    Console.WriteLine(singleOrDefMagnus);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}

            //var selectAdam = refTypes.Select(p => p.Name == "Adam");
            //Console.WriteLine(selectAdam);
            //var selectAllAdams = refTypes.Select(p => p.Name == "Adam");



            var people = new List<Client>();

            people.Add(new Client() 
            { 
                Name = "Adam", 
                PhoneNumbers = new List<PhoneNumber>() 
                { 
                    new PhoneNumber() { Number = "0958833321" },
                    new PhoneNumber() { Number = "0958833322" },
                    new PhoneNumber() { Number = "0958833323" },
                    new PhoneNumber() { Number = "0958833324" },
                    new PhoneNumber() { Number = "0958833325" },
                } 
            });
            people.Add(new Client()
            {
                Name = "Magnus",
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber() { Number = "0958833331" },
                    new PhoneNumber() { Number = "0958833332" },
                    new PhoneNumber() { Number = "0958833333" },
                    new PhoneNumber() { Number = "0958833334" },
                    new PhoneNumber() { Number = "0958833335" },
                }
            });
            people.Add(new Client()
            {
                Name = "Charlotte",
                PhoneNumbers = new List<PhoneNumber>()
                {
                    new PhoneNumber() { Number = "0958823341" },
                    new PhoneNumber() { Number = "0958833342" },
                    new PhoneNumber() { Number = "0958833343" },
                    new PhoneNumber() { Number = "0958832344" },
                    new PhoneNumber() { Number = "0958833345" },
                }
            });

            // Select gets a list of lists of phone numbers
            IEnumerable<IEnumerable<PhoneNumber>> phoneLists = people.Select(p => p.PhoneNumbers);

            // SelectMany flattens it to just a list of phone numbers.
            IEnumerable<PhoneNumber> phoneNumbers = people.SelectMany(p => p.PhoneNumbers);

            // And to include data from the parent in the result: 
            // pass an expression to the second parameter (resultSelector) in the overload:
            var directory = people
               .SelectMany(p => p.PhoneNumbers,
                           (parent, child) => new { parent.Name, child.Number });

            var kindOfSorting = people.Where(p => p.Name == "Charlotte").SelectMany(n=>n.PhoneNumbers);
            
            foreach(var n in kindOfSorting.OrderBy(n=>n.Number))
            {
                Console.WriteLine(n.Number);
            }    
        }
    }

    public class PhoneNumber
    {
        public string Number { get; set; }
    }

    public class Client
    {
        public IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        public string Name { get; set; }
    }

    
}
