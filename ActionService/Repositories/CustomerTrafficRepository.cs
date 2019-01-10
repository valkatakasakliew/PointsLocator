using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataObjects.DAOs;
using DataObjects.Interfaces;

namespace ActionService.Repositories
{
    public class CustomerTrafficRepository : ICustomerTrafficRepository
    {
        static readonly ICustomerTrafficDao customerTrafficDao = DaoFactory.GetCustomerTrafficDao;

        public List<CustomerTraffic> GetCustomerTraffics()
        {
            return customerTrafficDao.GetCustomerTraffics();
        }
    }
}
