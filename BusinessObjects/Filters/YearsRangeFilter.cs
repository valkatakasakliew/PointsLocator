using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObjects.Filters.Enumerators;

namespace BusinessObjects.Filters
{
    public class YearsRangeFilter : BaseFilter
    {

        //static List<YearsRangeFilterItem> _filterItems;


        public YearsRangeFilter()
        {
            _filterItems = new List<IFilterItem>();
            _filterItems.Add(new YearsRangeFilterItem("ToEighteen", new AgeFilterObject(1, 18), "1-18"));
            _filterItems.Add(new YearsRangeFilterItem("NineteenTwentyFive", new AgeFilterObject(19, 25), "19-25"));
            _filterItems.Add(new YearsRangeFilterItem("TwentySixThirtyFive", new AgeFilterObject(26, 35), "26-35"));
            _filterItems.Add(new YearsRangeFilterItem("ThirtySixFourtyFive", new AgeFilterObject(36, 45), "36-45"));
            _filterItems.Add(new YearsRangeFilterItem("FourtySixSixtyFive", new AgeFilterObject(46, 65), "46-65"));
            _filterItems.Add(new YearsRangeFilterItem("OverSixstySix", new AgeFilterObject(66, 100), "65+"));
        }

        public override List<IFilterItem> GetFilterItems()
        {
            return _filterItems;

        }

        public override IFilterItem GetFilterItem(string filterType)
        {
            return _filterItems.FirstOrDefault(f =>f.FilterName== filterType);
        }
    }
}

