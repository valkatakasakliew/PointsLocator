using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService
{
    public static class ServicesFactory
    {
        public static ICustomerService CreateCustomerService()
        {
            return new CustomerService();
        }

        public static ITrafficService CreateTrafficServcie()
        {
            return new TrafficService();
        }

        public static IPointService CreatePointService()
        {
            return new PointService();
        }
    }
}
