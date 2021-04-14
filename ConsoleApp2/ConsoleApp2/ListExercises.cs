using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ListExercises
    {

        public void Exercise()
        {
            var primitiveNumbers = new List<int>() { 1, 2 };
            primitiveNumbers.Add(3);

            primitiveNumbers.Insert(3, 4);

            for (int i = 0; i < primitiveNumbers.Count; i++)
            {
                Console.WriteLine(primitiveNumbers[i]);
            }                

            if (primitiveNumbers.Contains(4))
            {
                primitiveNumbers.Remove(4);
            }//по індексу  IEnumerable IQuarable         

            var res = primitiveNumbers.Distinct().ToDictionary(x => x, x => string.Format("Val{0}", x));//ILookup why?
            var res2 = res.ToList();
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
