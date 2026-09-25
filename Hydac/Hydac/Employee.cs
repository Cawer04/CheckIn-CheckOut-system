using System;
using System.Collections.Generic;
using System.Text;

namespace Hydac
{
    internal class Employee
    {

        private string employeeName;
        private Guest[] guests; //Array til at gemme gæsterne
        private int guestCount; //Holder styr på hvor mange gæster der er oprettet

        public Employee(string EmployeeName, int maxGuests)
        {
            employeeName = EmployeeName;
            this.guests = new Guest[maxGuests]; //opretter arrayet med den faste størrelse
            this.guestCount = 0; //Antal gæster starter på 0

        }
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
        public void PrintGuests()
        {
            Console.WriteLine($"---Gæsteliste for {employeeName}---");

            if (guestCount == 0)
            {
                Console.WriteLine("Ingen gæster registreret endnu");
                return;
            }

            for (int i = 0; i < guestCount; i++)
            {

                Console.WriteLine($"{i + 1}. Navn: {guests[i].GetName()}");
            }
        }






    }
}
