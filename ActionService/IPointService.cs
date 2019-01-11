using BusinessObjects;
using BusinessObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService
{
    public interface IPointService
    {
        List<Point> GetListOfPoints(List<YearsRangeFilterItem> ageFilters,List<GenderFilterItem> genderFilters);
    }
}
