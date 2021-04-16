using System;
using System.Collections;

namespace ConsoleApp2
{
    class EnumerationExample
    {
        public void Example()
        {
            Numbers numbers = new Numbers();
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
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

    class Numbers
    {
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 6; i++)
            {
                yield return i * i;
            }
        }
    }
}
