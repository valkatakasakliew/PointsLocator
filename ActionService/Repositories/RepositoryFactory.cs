using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService.Repositories
{
    public static class RepositoryFactory
    {
        public static ICustomerRepository GetCustomerRepository { get { return new CustomerRepository(); } }

        public static ITrafficRepository GetTrafficRepository { get { return new TrafficRepository(); } }

        public static IPointRepository GetPointRepository { get { return new PointRepository(); } }
    }
}
