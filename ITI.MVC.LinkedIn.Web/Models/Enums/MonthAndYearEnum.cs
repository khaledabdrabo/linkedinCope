using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.MVC.LinkedIn.Web.Models.Enums
{
    
    public enum MonthEnum
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class YearList
    {
      public static List<int> YearListFun()
        {
            List<int> years = new List<int>();
            for(int i = 1950; i <= DateTime.Now.Year; i++)
            {
                years.Add(i);
            }
            return years;
        }

        public static List<MonthEnum> MonthListFun()
        {
            List<MonthEnum> Months = new List<MonthEnum>();

            for (int i = 1; i <= 12; i++)
            {
                Months.Add((MonthEnum)i);
            }
            return Months;
        }

        public static List<int> DaysListFun()
        {
            List<int> Days = new List<int>();
            for (int i = 1; i <= 31; i++)
            {
                Days.Add(i);
            }
            return Days;
        }
    }
}