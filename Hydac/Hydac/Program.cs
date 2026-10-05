using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Hydac
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee employee = new Employee("Peter Jensen", 10);


            bool kører = true;

            while (kører)//loop der fortsætter med at kører programmet så længe "kører" er true
            {

                Console.WriteLine("===Vælg hvad du vil===");
                Console.WriteLine("1. Opret ny gæst");
                Console.WriteLine("2. Se liste over gæster");
                Console.WriteLine("3. Tjek gæst ud");
                string valg = Console.ReadLine();
                Console.Clear();
                switch (valg)
                {
                    case "1":
                        // Opret en ny gæst instans
                        Guest newGuest = new Guest();

                        Console.WriteLine("Indtast gæstens navn");
                        newGuest.SetName(Console.ReadLine());
                        // Sørger for at employee kan tilføje en gæst
                        employee.AddGuest(newGuest);
                        Console.WriteLine("Gæst tilføjet");

                        Console.WriteLine("Indtast navn på firma");
                        newGuest.SetCompany(Console.ReadLine());

                        Console.WriteLine("Indtast ankomst timetal");
                        newGuest.SetArrivalHour(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Indtast ankomst minuttal");
                        newGuest.SetArrivalMinute(int.Parse(Console.ReadLine()));
                        break;

                    case "2":
                        // Kalder PrintGuests metoden som viser gæstelisten
                        employee.PrintGuests();
                        break;

                    case "3":
                        bool udtjekningKører = true;

                        while (udtjekningKører) // Loop til udtjekning som kører så længe "udtjekningKører" er true
                        {
                            employee.PrintGuests();

                            // Gør det helt tydeligt, at man kan trykke 0 for at fortryde
                            Console.WriteLine("\nIndtast nummer på den gæst du vil tjekke ud");
                            Console.WriteLine("(Eller tryk '0' for at gå tilbage til hovedmenuen):");
                            string input = Console.ReadLine();

                            // Hvis brugeren skriver 0, afbryder vi udtjekningen og ryger tilbage til hovedmenuen
                            if (input == "0")
                            {
                                Console.WriteLine("Vender tilbage til hovedmenuen...\n");
                                udtjekningKører = false; // Stopper udtjeknings-løkken
                                break; // Bryder ud af while-løkken med det samme
                            }

                            // Forsøger at omdanne input til et heltal
                            if (int.TryParse(input, out int valgtGæst))
                            {
                                // Finder det korrekte indeks i arrayet
                                int indeks = valgtGæst - 1;
                                // Henter gæsten via medarbejderens metode
                                Guest guestCheckOut = employee.GetGuest(indeks);

                                // Tjekker om gæsten findes og at pladsen ikke er tom
                                if (guestCheckOut != null)
                                {
                                    // Spørger om medarbejderen vil bekræfte udtjekning
                                    Console.WriteLine($"Vil du melde {guestCheckOut.GetName()} ud? (ja/nej)");
                                    string choice = Console.ReadLine();

                                    if (choice == "ja")
                                    {
                                        // Try-catch bruges her i tilfælde af fejl
                                        try
                                        {
                                            // Fjerner gæsten fra arrayet og udskriver bekræftelse
                                            employee.RemoveGuest(indeks);
                                            Console.WriteLine($"{guestCheckOut.GetName()} er nu tjekket ud");
                                        }
                                        catch
                                        {
                                            Console.WriteLine("Fejl: Nog gik galt under udtjekning");
                                        }
                                    }
                                    else if (choice == "nej")
                                    {
                                        Console.WriteLine("Udtjekning annulleret. Vender tilbage til gæstelisten...\n");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ugyldigt gæstenummer. Prøv igen.\n");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Fejl: Du skal indtaste et gyldigt tal\n");
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Ugyldigt valg. Prøv igen.");
                        break;
                }
            }
        }
    }

}









