using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObjects.Filters.Enumerators;

namespace BusinessObjects.Filters
{ 
    public class GenderFilterItem : IFilterItem
    {
        public string FilterName { get; set; }
        public FilterObject ToFilter { get; set; }
        public string FilterText { get; set; }

        public GenderFilterItem(string filterName, FilterObject filterObject, string filterText)
        {
            FilterName = filterName;
            ToFilter = filterObject;
            FilterText = filterText;
        }
    }

}
