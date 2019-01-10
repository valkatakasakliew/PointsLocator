using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Filters
{


        public class YearsRangeFilter
        {

            static List<YearsRangeFilterItem> filterItems;


            public YearsRangeFilter()
            {
                filterItems = new List<YearsRangeFilterItem>();
                filterItems.Add(new YearsRangeFilterItem(YearsRangeFilterEnum.ToEighteen, 1, 18, "1-18"));
                filterItems.Add(new YearsRangeFilterItem(YearsRangeFilterEnum.NineteenTwentyFive, 19, 25, "19-25"));
                filterItems.Add(new YearsRangeFilterItem(YearsRangeFilterEnum.TwentySixThirtyFive, 26, 35, "26-35"));
                filterItems.Add(new YearsRangeFilterItem(YearsRangeFilterEnum.ThirtySixFourtyFive, 36, 45, "36-45"));
                filterItems.Add(new YearsRangeFilterItem(YearsRangeFilterEnum.FourtySixSixtyFive, 46, 65, "46-65"));
                filterItems.Add(new YearsRangeFilterItem(YearsRangeFilterEnum.OverSixstySix, 66, 100, "65+"));
            }

            public List<YearsRangeFilterItem> GetYearsRangeItems()
            {
                return filterItems;

            }

            public static YearsRangeFilterItem GetFilter(YearsRangeFilterEnum filterEnum)
            {
                return filterItems.FirstOrDefault(f => f.YearsRangeFilterType.Equals(filterEnum));
            }
        }



        public class YearsRangeFilterItem
        {
            public YearsRangeFilterEnum YearsRangeFilterType { get; set; }
            public int FromValue { get; set; }
            public int ToValue { get; set; }
            public string Description { get; set; }

            public YearsRangeFilterItem(YearsRangeFilterEnum type, int from, int to, string description)
            {
                YearsRangeFilterType = type;
                FromValue = from;
                ToValue = to;
                Description = description;
            }
        }

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

