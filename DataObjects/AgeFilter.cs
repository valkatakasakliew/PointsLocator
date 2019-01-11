using BusinessObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class AgeFilter
    {
        public int FromAge { get; set; }

        public int ToAge { get; set; }

        public AgeFilter(YearsRangeFilterItem yearsRangeFilter)
        {
            AgeFilterObject fo = (AgeFilterObject)yearsRangeFilter.ToFilter;
            this.FromAge = fo.FromAge;
            this.ToAge = fo.ToAge;
        }
    }
}
