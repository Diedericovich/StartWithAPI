using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartWithAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int CalculateAge (this DateTime date)
        {
            int age = DateTime.Now.Year - date.Year;
            return age;
        }
    }
}
