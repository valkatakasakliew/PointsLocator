using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BusinessObjects.Filters.Enumerators;

namespace BusinessObjects.Filters
{
    public interface IFilterItem
    {
        string FilterName { get; set; }
        FilterObject ToFilter { get; set; }
        string FilterText { get; set; }
    }
}
