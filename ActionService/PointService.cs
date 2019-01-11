using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using ActionService.Repositories;
using BusinessObjects.Filters;

namespace ActionService
{
    public class PointService : IPointService
    {
        IPointRepository pointRepo = RepositoryFactory.GetPointRepository;

        public List<Point> GetListOfPoints(List<YearsRangeFilterItem> ageFilters , List<GenderFilterItem> genderFilters)
        {
            return pointRepo.GetPoints(ageFilters,genderFilters);
        }
    }
}
