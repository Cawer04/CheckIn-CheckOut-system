using System;
using System.Collections.Generic;
using System.Text;

namespace Hydac
{
    public class Guest
    {
        private string guestName;
        private string company;
        private int arrivalHour;
        private int arrivalMinute;

        

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


    }
}
