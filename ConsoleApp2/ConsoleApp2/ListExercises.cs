using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
    public class ListExercises
    {

        public void Exercise()
        {
            var primitiveNumbers = new List<int>() { 1, 2 };
            primitiveNumbers.Add(3);

            primitiveNumbers.Insert(3, 4);

            //for (int i = 0; i < primitiveNumbers.Count; i++)
            //{
            //    Console.WriteLine(primitiveNumbers[i]);
            //}                


            if (primitiveNumbers.Contains(4))
            {
                primitiveNumbers.Remove(4);
            }

            primitiveNumbers.RemoveAt(primitiveNumbers.Count - 1);

            for (int i = 0; i < primitiveNumbers.Count; i++)
            {
                Console.WriteLine(primitiveNumbers[i]);
            }

            var res = primitiveNumbers.Distinct().ToDictionary(x => x, x => string.Format("Val{0}", x));
            var res2 = res.ToList();

            //Ref type in list

            var refTypes = new List<Person>()
            {
                new Person { Name = "Hedlund, Magnus" },
                new Person { Name = "Adams, Terry" },
                new Person { Name = "Weiss, Charlotte" }
            };
            refTypes.Add(new Person { Name = "Magnus, Carlsen" });
            var adam = new Person { Name = "Adam, West" };

            refTypes.Insert(3, adam);


            Console.WriteLine(refTypes.Count());
            //if (refTypes.Contains(adam))
            //{
            //    adam.Name = String.Empty;
            //}
            
            var copy = refTypes.Select(person => new Person { Name = person.Name }).ToList();
            
            copy.RemoveAt(1);
            PrintList(refTypes);
            PrintList(copy);
        }

        private void PrintList(List<Person> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i].Name);
            }
            Console.WriteLine('\n');
        }

        public void JoinEx1()
        {
            Person magnus = new Person { Name = "Hedlund, Magnus" };
            Person terry = new Person { Name = "Adams, Terry" };
            Person charlotte = new Person { Name = "Weiss, Charlotte" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, charlotte };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };

            var query =
                people.Join(pets,
                            person => person,
                            pet => pet.Owner,
                            (person, pet) =>
                                new { OwnerName = person.Name, Pet = pet.Name });

            foreach (var obj in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.OwnerName,
                    obj.Pet);
            }
        }        
    }

    class Person
    {
        public string Name { get; set; }
    }

    class Pet
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    

}
