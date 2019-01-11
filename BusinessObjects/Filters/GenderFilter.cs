using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObjects.Filters.Enumerators;

namespace BusinessObjects.Filters
{
    public class GenderFilter : BaseFilter
    {
        public GenderFilter()
        {
            _filterItems = new List<IFilterItem>();
            _filterItems.Add(new GenderFilterItem("M", new GenderFilterObject("M"), "Male"));
            _filterItems.Add(new GenderFilterItem("F", new GenderFilterObject("F"), "Female"));
            _filterItems.Add(new GenderFilterItem("?", new GenderFilterObject("?"), "Unknown"));
        }

        public override IFilterItem GetFilterItem(string filterType)
        {
            return _filterItems.FirstOrDefault(f => f.FilterName == filterType);
        }

        public override List<IFilterItem> GetFilterItems()
        {
            return _filterItems;
        }

    }
}
