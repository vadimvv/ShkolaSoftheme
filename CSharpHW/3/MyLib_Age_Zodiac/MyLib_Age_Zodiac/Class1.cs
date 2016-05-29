using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib_Age_Zodiac
{
    public class CheckAge_And_ZodiacSign
    {
        public string GetInfo()
        {
            int day = 0, month = 0, year = 0;
            try
            {
                Console.WriteLine("Enter your day of birth:");
                day = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your month of birth:");
                month = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter your year of birth:");
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Plese, input correct data");
                GetInfo();
            }
            if (!BirthDateCheck(day, month, year))
            {
                Console.Clear();
                Console.WriteLine("Sorry, but your date is wrong. Please, try again");
                GetInfo();
            }
            DateTime birthDate = new DateTime(year, month, day);
            return UserInfo(birthDate);
        }



        public bool BirthDateCheck(int day, int month, int year)
        {
            try
            {
                DateTime birthDay = new DateTime(year, month, day);
            }
            catch
            {
                return false;
            }
            return true;
        }



        public string UserInfo(DateTime birthDate)
        {
            string Info = GetYear(birthDate) + " " + GetZodiakSign(birthDate);
            return Info;
        }

        public string GetZodiakSign(DateTime birthDate)
        {
            string ZodiacType = "";
            int NomOfDay = birthDate.DayOfYear;

            if (NomOfDay >= 80 && NomOfDay <= 109)
                return "Aries";
            else if (NomOfDay >= 110 && NomOfDay <= 140)
                return "Taurus";
            else if (NomOfDay >= 141 && NomOfDay <= 171)
                return "Gemini";
            else if (NomOfDay >= 172 && NomOfDay <= 202)
                return "Cancer";
            else if (NomOfDay >= 203 && NomOfDay <= 232)
                return "Leo";
            else if (NomOfDay >= 233 && NomOfDay <= 265)
                return "Virgo";
            else if (NomOfDay >= 266 && NomOfDay <= 295)
                return "Libra";
            else if (NomOfDay >= 296 && NomOfDay <= 326)
                return "Scorpio";
            else if (NomOfDay >= 327 && NomOfDay <= 356)
                return "Sagittarius";
            else if (NomOfDay >= 357 || NomOfDay <= 20)
                return "Capricorn";
            else if (NomOfDay >= 21 && NomOfDay <= 50)
                return "Aquarius";
            else if (NomOfDay >= 51 && NomOfDay <= 79)
                return "Pisces";

            return ZodiacType;
        }

        public string GetYear(DateTime birthDate)
        {
            DateTime Today = DateTime.Now;
            int Age = 0;

            if (birthDate.Month <= Today.Month && birthDate.Day <= birthDate.Day)
                Age = Today.Year - birthDate.Year;
            else Age = Today.Year - birthDate.Year - 1;

            return Age + "";
        }
    }
}
