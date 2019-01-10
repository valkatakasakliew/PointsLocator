using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActionService.Repositories;
using BusinessObjects;

namespace ActionService
{
    public class CustomerTrafficService : ICustomerTrafficService
    {
        static readonly ICustomerTrafficRepository customerTrafficRepository = RepositoryFactory.GetCustomerTrafficRepository;

        public List<CustomerTraffic> GetListOfCustomerTraffics()
        {
            return customerTrafficRepository.GetCustomerTraffics();
        }
    }
}
