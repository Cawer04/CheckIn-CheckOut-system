using System;
using System.Collections.Generic;
using System.Text;

namespace Hydac
{
    public class Employee
    {
        //private fields
        //Andre klasser kan ikke ændre på dem 
        private string employeeName;
        private Guest[] guests; //Array til at gemme gæsterne
        private int guestCount; //Holder styr på hvor mange gæster der er oprettet

        public Employee(string EmployeeName, int maxGuests)
        {
            this.employeeName = EmployeeName;
            this.guests = new Guest[maxGuests]; //opretter arrayet med den faste størrelse
            this.guestCount = 0; //Antal gæster starter på 0

        }
        //property til vores employees navn
        public string GetEmployeeName()
        {
            return employeeName;
        }
        //Metode til at tilføje en gæst til medarbejderns array
        public bool AddGuest(Guest newGuest)
        {
            if (guestCount < guests.Length)
            {
                guests[guestCount] = newGuest; //Bruges til at lægge gæsten ind på en ledig plads
                guestCount++; //Bruges til at tælle op, man er kldar til næste gæst
                return true; //hvis der er plads i arrayet, vil den være true
            }
            return false; //Hvis vores array er fyldt op, vil den være false
        }
        //Metode til at udskrive alle gæster der er knyttet til medarbejderen

        public void RemoveGuest(int indeks)
        {
            //  Tjek om det valgte indeks er inden for gyldigt rækkevidde
            if (indeks >= 0 && indeks < guestCount)
            {
                // 2. Flytter alle efterfølgende gæster et skridt tilbage i arrayet for at lukke hullet
                for (int i = indeks; i < guestCount - 1; i++)
                {
                    guests[i] = guests[i + 1];
                }

                //  Nulstil den sidste plads i arrayet, da den gæst nu er rykket eller fjernet
                guests[guestCount - 1] = null;

                //  Tæl det samlede antal gæster én ned, da der nu er én gæst mindre
                guestCount--;
            }
        }
        // Metode til at hente en bestemt gæst ud fra et indeks i arrayet
        public Guest GetGuest(int indeks)
        {
            // Tjek om det indtastede indeks er gyldigt (inden for arrayets grænser og færre end antallet af gæster)
            if (indeks >= 0 && indeks < guestCount)
            {
                //  Hvis det er gyldigt, returner gæsten fra den plads i arrayet
                return guests[indeks];
            }

            //  Hvis indekset er ugyldigt (f.eks. for lavt eller for højt), returner null (ingenting)
            return null;
        }

        // Metode til at printe alle gæster der er knyttet til medarbejderen
        public void PrintGuests()
        {
            //  Udskriv overskriften med medarbejderens navn
            Console.WriteLine($"---Gæsteliste---");

            //  Tjek om der overhovedet er nogle gæster på listen endnu
            if (guestCount == 0)
            {
                Console.WriteLine("Ingen gæster registreret endnu");
                return; // Stopper metoden her, hvis listen er tom
            }

            //  Gå igennem alle registrerede gæster en efter en ved hjælp af et for-loop
            for (int i = 0; i < guestCount; i++)
            {
                //  Udskriv gæstens nummer (i + 1), navn, firma og ankomsttid (time og minut) og viser hvem den ansvarlige medarbejder er til gæsten
                Console.WriteLine($"{i + 1}. Navn: {guests[i].GetName()} | Firma: {guests[i].GetCompany()} " +
                    $"| Ankomstid: {guests[i].GetArrivalHour()}.{guests[i].GetArrivalMinute()} | Ansvarlig medarbejder: {employeeName} ");
            }
        }






    }
}
