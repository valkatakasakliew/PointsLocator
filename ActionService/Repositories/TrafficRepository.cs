using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataObjects;
using DataObjects.DAOs;
using DataObjects.Interfaces;

namespace ActionService.Repositories
{
    public class TrafficRepository : ITrafficRepository
    {
        static readonly ITrafficDao trafficDao = DaoFactory.GetTrafficDao;

        public List<Traffic> GetTrafficsByNumber(string aNumber)
        {
            return trafficDao.GetTraficsByNumber(aNumber);
        }

        public List<Traffic> GetTraffics()
        {
           return trafficDao.GetTraffics();
        }

        public void InsertTraffic(Traffic traffic)
        {
            trafficDao.InsertTrafic(traffic);
        }
    }
}
