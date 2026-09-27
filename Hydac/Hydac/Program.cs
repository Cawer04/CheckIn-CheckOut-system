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
                Console.WriteLine("3. Tjek gæst ud");
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

                    Console.WriteLine("Indtast navn på firma");
                    newGuest.SetCompany(Console.ReadLine());

                    Console.WriteLine("Indtast ankomst timetal");
                    newGuest.SetArrivalHour(int.Parse(Console.ReadLine()));
                    Console.WriteLine("Indtast ankomst minuttal");
                    newGuest.SetArrivalMinute(int.Parse(Console.ReadLine()));
                }



                else if (valg == "2")
                {
                    employee.PrintGuests();
                }
                else if (valg == "3")
                {
                    bool udtjekningKører = true;

                    while (udtjekningKører)
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
                        //Forsøger at omdanne input til et heltal
                        if (int.TryParse(input, out int valgtGæst))
                        {
                            //Finder den korrekte indeks i arrayet
                            int indeks = valgtGæst - 1;
                            //Henter gæsten via medarbejderens metode
                            Guest guestCheckOut = employee.GetGuest(indeks);
                            //Tjekker om gæsten findes og at pladsen ikke er tom
                            if (guestCheckOut != null)
                            {
                                //spørger om medarbejderen vil bekræfte udtjekning
                                Console.WriteLine($"Vil du melde {guestCheckOut.GetName()} ud? (ja/nej)");
                                string choice = Console.ReadLine();

                                if (choice == "ja")
                                {
                                   try
                                    {
                                        
                                        //Fjerner gæsten fra arrayet og udskriver bekræfteslse
                                        employee.RemoveGuest(indeks);
                                        Console.WriteLine($"{guestCheckOut.GetName()} er nu tjekket ud");

                                        
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Fejl: Du skal indtaste et gyldigt tal");
                                    }
                                }
                                else if (choice == "nej")
                                {
                                    Console.WriteLine("Udtjekning annulleret. Vender tilbage til gæstelisten...\n");
                                    // Her fortsætter løkken bare, så man kan se listen og vælge igen (eller trykke 0)
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ugyldigt gæstenummer. Prøv igen.\n");
                            }
                        }
                    }
                }

            }






        }
    }
}
