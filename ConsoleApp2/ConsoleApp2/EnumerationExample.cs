using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp2
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
}
