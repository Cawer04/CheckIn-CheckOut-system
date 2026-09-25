using System.Security.Cryptography;

namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guest guest = new Guest();

            Employee employee = new Employee("Peter", 10);


            bool kører = true;

            while (kører)
            {

                Console.WriteLine("===Vælg hvad du vil===");
                Console.WriteLine("1. Opret ny gæst");
                Console.WriteLine("2. Se liste over gæster");
                Console.WriteLine("3. Afslut");
                string valg = Console.ReadLine();

                if (valg == "1")
                {
                    //opret en ny gæst instans
                    Guest newGuest = new Guest();

                    Console.WriteLine("Indtast gæstens navn");
                    newGuest.SetName(Console.ReadLine());
                    //Sørger for at employee kan tilføje en gæst
                    employee.AddGuest(newGuest);
                    Console.WriteLine("Gæest tilføjet");
                }



                else if (valg == "2")
                {
                    employee.PrintGuests();
                }

            }






        }
    }
}
