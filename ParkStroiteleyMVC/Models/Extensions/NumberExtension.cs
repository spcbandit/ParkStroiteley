using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkStroiteleyMVC.Models.Extensions
{
    public static class NumberExtension
    {
        public static string ToStringDF(this double number)
        {
            try
            {
                return Convert.ToString(number).Replace(",", ".");
            }
            catch
            {
                return "";
            }
        }
        public static string ToStringIF(this int number)
        {
            try
            {
                var countV = number.ToString().Count();
                switch (countV)
                {
                    case 10:
                        return number.ToString("# ### ### ###");
                    case 9:
                        return number.ToString("### ### ###");
                    case 8:
                        return number.ToString("## ### ###");
                    case 7:
                        return number.ToString("# ### ###");
                    case 6:
                        return number.ToString("### ###");
                    case 5:
                        return number.ToString("## ###");
                    case 4:
                        return number.ToString("# ###");
                    default:
                        return number.ToString();
                }
            }
            catch
            {
                return "";
            }
        }
        //public static string ShowAsNumber(this int number)
        //{ 

        //}
    }
}
