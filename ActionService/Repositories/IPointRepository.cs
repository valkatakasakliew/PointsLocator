using BusinessObjects;
using BusinessObjects.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService.Repositories
{
    public interface IPointRepository
    {
        List<Point> GetPoints(List<YearsRangeFilterItem> ageFilters);
    }
}
