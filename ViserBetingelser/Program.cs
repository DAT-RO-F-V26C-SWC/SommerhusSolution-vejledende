// See https://aka.ms/new-console-template for more information
using SommerhusLib.model;

Console.WriteLine("Hello, World!");

Sommerhus? hus = null;
try
{
    hus = new Sommerhus(6, "Strandvejen 45", 4000, "Roskilde", 90, 120, 5, false, true, true, false, 2400);

    hus.RentId = -2;




}
catch (ArgumentException ae)
{
    //Console.WriteLine("Fejl: " + ae.Message);
}

Console.WriteLine(hus);