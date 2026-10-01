using System;
using System.Collections.Generic;
using System.Text;

namespace Hydac
{
    public class Guest
    {
        //private fields
        //Andre klasser kan ikke få i dem og ændre dem
        private string guestName;
        private string company;
        private int arrivalHour;
        private int arrivalMinute;
   
        private int departureHour;
        private int departureMinute;

        //Properties til vores gæst i form af Get og Set.

        public void SetName(string name)
        {
            guestName = name;
        }
        public string GetName()
        {
            return guestName;
        }
        public void SetCompany(string company)
        {
           this.company = company;
        }
        public string GetCompany()
        {
            return company;
        }
        public void SetArrivalHour(int arrivalHour)
        {
            this.arrivalHour = arrivalHour;
        }
        public int GetArrivalHour()
        {
            return arrivalHour;
        }
        public void SetArrivalMinute(int arrivalMinute)
        {
            this.arrivalMinute = arrivalMinute;
        }
        public int GetArrivalMinute()
        {
            return arrivalMinute;
        }
        public int GetDepartureHour()
        {
            return departureHour;
        }
        public void SetDepartureHour(int departureHour)
        {
            this.departureHour = departureHour;
        }
        public void SetDepartureMinute(int departureMinute)
        {
            this.departureMinute = departureMinute;
        }
        public int GetDepartureMinute()
        {
            return departureMinute;
        }

    }
}
