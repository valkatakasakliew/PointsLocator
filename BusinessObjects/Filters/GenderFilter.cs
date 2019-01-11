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
            _filterItems.Add(new GenderFilterItem("Male", new GenderFilterObject("Male"), "M"));
            _filterItems.Add(new GenderFilterItem("Female", new GenderFilterObject("Female"), "F"));
            _filterItems.Add(new GenderFilterItem("Unknown", new GenderFilterObject("Unknown"), "?"));
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
