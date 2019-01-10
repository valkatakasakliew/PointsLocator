using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.DAOs
{
    public static class DaoFactory
    {
        public static ICustomerDao GetCustomerDao { get { return new CustomerDao(); } }

        public static ITrafficDao GetTrafficDao { get { return new TrafficDao(); } }

        public static ICustomerTrafficDao GetCustomerTrafficDao { get { return new CustomerTrafficDao(); } }

        public static IPointDao GetPointDao { get { return new PointDao(); } }
    }
}
