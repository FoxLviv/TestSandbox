namespace ConsoleApp2
{
    class EnumerationExample
    {
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
}
