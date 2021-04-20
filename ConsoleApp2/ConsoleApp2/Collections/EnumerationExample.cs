using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace LearnBasics.SandBox.Collections
{
    class EnumerationExample
    {
        public void Example()
        {
            var theGalaxies = new Galaxies();
            foreach (Galaxy theGalaxy in theGalaxies.NextGalaxy)
            {
                Console.WriteLine(theGalaxy.Name + " " + theGalaxy.MegaLightYears.ToString());
            }
            Console.ReadKey();
        }

        public void AllEx2()
        {
            var people = new List<Owner>
        { new Owner { LastName = "Haas",
                       Pets = new Cat[] { new Cat { Name="Barley", Age=10 },
                                          new Cat { Name="Boots", Age=14 },
                                          new Cat { Name="Whiskers", Age=6 }}},
          new Owner { LastName = "Fakhouri",
                       Pets = new Cat[] { new Cat { Name = "Snowball", Age = 1}}},
          new Owner { LastName = "Antebi",
                       Pets = new Cat[] { new Cat { Name = "Belle", Age = 8} }},
          new Owner { LastName = "Philips",
                       Pets = new Cat[] { new Cat { Name = "Sweetie", Age = 2},
                                          new Cat { Name = "Rover", Age = 13}} }
        };

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            // Determine which people have pets that are all older than 5.
            IEnumerable<string> names = from person in people
                                        where person.Pets.AsQueryable().All(pet => pet.Age > 5)
                                        select person.LastName;
            stopwatch.Stop();

            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            stopwatch.Reset();



            stopwatch.Start();
            IEnumerable<string> names2 = from person in people
                                         where person.Pets.AsEnumerable().All(pet => pet.Age > 5)
                                         select person.LastName;
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);



            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            foreach (string name in names2)
            {
                Console.WriteLine(name);
            }


            /* This code produces the following output:
             *
             * Haas
             * Antebi
             */
        }
        //    IEnumerable<Phone> phoneIEnum = db.Phones;
        //    var phones = phoneIEnum.Where(p => p.Id > id).ToList();

        //SELECT
        //[Extent1].[Id] AS[Id], 
        //[Extent1].[Name] AS[Name], 
        //[Extent1].[Company] AS[Company]
        //FROM[dbo].[Phones] AS[Extent1]

        //IQueryable<Phone> phoneIQuer = db.Phones;
        //var phones = phoneIQuer.Where(p => p.Id > id).ToList();

        //        SELECT
        //    [Extent1].[Id] AS[Id], 
        //    [Extent1].[Name] AS[Name], 
        //    [Extent1].[Company]
        //        AS[Company]
        //FROM[dbo].[Phones]
        //        AS[Extent1]
        //WHERE[Extent1].[Id] >3
    }

    public class Galaxies
    {

        public IEnumerable<Galaxy> NextGalaxy
        {
            get
            {
                yield return new Galaxy { Name = "Tadpole", MegaLightYears = 400 };
                yield return new Galaxy { Name = "Pinwheel", MegaLightYears = 25 };
                yield return new Galaxy { Name = "Milky Way", MegaLightYears = 0 };
                yield return new Galaxy { Name = "Andromeda", MegaLightYears = 3 };
            }
        }
    }

    public class Galaxy
    {
        public string Name { get; set; }
        public int MegaLightYears { get; set; }
    }

    class Cat
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Owner
    {
        public string LastName { get; set; }
        public Cat[] Pets { get; set; }
    }


}
