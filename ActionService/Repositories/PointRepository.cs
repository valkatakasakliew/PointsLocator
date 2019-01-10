using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataObjects.Interfaces;
using DataObjects.DAOs;
using BusinessObjects.Filters;

namespace ActionService.Repositories
{
    public class PointRepository : IPointRepository
    {
        static readonly IPointDao pointDao = DaoFactory.GetPointDao;

        public List<Point> GetPoints(List<YearsRangeFilterItem> ageFilters)
        {
            return pointDao.GetPoints(ageFilters);
        }
    }
}
