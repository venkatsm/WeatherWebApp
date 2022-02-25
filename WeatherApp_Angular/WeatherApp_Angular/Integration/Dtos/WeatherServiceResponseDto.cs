using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp_Angular.Integration.Dtos
{
    public class WeatherServiceResponseDto
    {
        public string Region { get; set; }
        public Currentconditions CurrentConditions { get; set; }
        public Next_Days[] Next_Days { get; set; }
        public Contact_Author Contact_Author { get; set; }
        public string Data_Source { get; set; }
    }

    public class Currentconditions
    {
        public string DayHour { get; set; }
        public Temp Temp { get; set; }
        public string Precip { get; set; }
        public string Humidity { get; set; }
        public Wind Wind { get; set; }
        public string IconURL { get; set; }
        public string Comment { get; set; }
    }

    public class Temp
    {
        public int C { get; set; }
        public int F { get; set; }
    }

    public class Wind
    {
        public int Km { get; set; }
        public int Mile { get; set; }
    }

    public class Contact_Author
    {
        public string Email { get; set; }
        public string Auth_Note { get; set; }
    }

    public class Next_Days
    {
        public string Day { get; set; }
        public string Comment { get; set; }
        public Temp Max_Temp { get; set; }
        public Temp Min_Temp { get; set; }
        public string IconURL { get; set; }
    }
}
