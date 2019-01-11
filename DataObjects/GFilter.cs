using BusinessObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class GFilter
    {
        public GFilter(GenderFilterItem filterItem)
        {
            GenderFilterObject fo = (GenderFilterObject)filterItem.ToFilter;
            this.Gender = fo.Gender;
        }

        string Gender { get; set; }
    }
}
