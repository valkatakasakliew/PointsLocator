using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionService.Repositories;
using BusinessObjects;

namespace ActionService
{
    public class TrafficService : ITrafficService
    {
        static readonly ITrafficRepository trafficRepository = RepositoryFactory.GetTrafficRepository;

        public void InsertNewTraffic(Traffic traffic)
        {
            trafficRepository.InsertTraffic(traffic);
        }

        public List<Traffic> GetListOfTraffics()
        {
            return trafficRepository.GetTraffics();
        }

        public List<Traffic> GetListOfTrafficsFilteredByNumber(string aNumber)
        {
            return trafficRepository.GetTrafficsByNumber(aNumber);
        }
    }
}
