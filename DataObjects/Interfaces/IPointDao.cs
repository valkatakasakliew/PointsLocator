using BusinessObjects;
using BusinessObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Interfaces
{
    public interface IPointDao
    {
        List<Point> GetPoints(List<YearsRangeFilterItem> ageFilters);
    }
}
