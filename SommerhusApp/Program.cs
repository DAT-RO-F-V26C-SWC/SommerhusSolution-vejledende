// See https://aka.ms/new-console-template for more information
using SommerhusLib;
using SommerhusLib.model;

Console.WriteLine("Hello, World!");

int numberOfTestData = 100;
SommerhusRegister register = new SommerhusRegister(numberOfTestData);
SommerhusService service = new SommerhusService(register);


//foreach (var sommerhus in register.GetAll())
//{
//    Console.WriteLine(sommerhus);
//}

//Filter filter = new Filter();
//filter.MinBeds = 4;
//filter.AllowPets = true;
//filter.Dishwasher = true;
//filter.MaxPrice = 4000;

//List<Sommerhus> huse = service.GetByFilter(filter);

//foreach (var sommerhus in huse)
//{
//    Console.WriteLine(sommerhus);
//}
//Console.WriteLine("Antal= " + huse.Count);


//List<Sommerhus> sortHuse = service.SortByPrice();
//List<Sommerhus> sortHuse = service.SortByDistance();
List<Sommerhus> sortHuse = service.SortByBeds();

foreach (var sommerhus in sortHuse)
{
    Console.WriteLine(sommerhus);
}
Console.WriteLine("Antal= " + sortHuse.Count);