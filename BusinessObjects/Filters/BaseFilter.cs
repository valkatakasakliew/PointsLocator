using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Filters
{
    public abstract class BaseFilter
    {
        protected List<IFilterItem> _filterItems;

       public abstract List<IFilterItem> GetFilterItems();

        public  abstract IFilterItem GetFilterItem(string filterType);

    }
}
