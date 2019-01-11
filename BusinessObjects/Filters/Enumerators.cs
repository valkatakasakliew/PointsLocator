using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Filters
{
    public static class Enumerators
    {
        /// <summary>
        /// Gender filter enums
        /// </summary>
        public enum GenderFilterEnum
        {
            Male,
            Female,
            Unknown
        }

        /// <summary>
        /// Years ranges filter enums
        /// </summary>
        public enum YearsRangeFilterEnum
        {
            ToEighteen,
            NineteenTwentyFive,
            TwentySixThirtyFive,
            ThirtySixFourtyFive,
            FourtySixSixtyFive,
            OverSixstySix
        }
    }
}
