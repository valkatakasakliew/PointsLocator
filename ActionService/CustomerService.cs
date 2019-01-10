using ActionService.Repositories;
using BusinessObjects;
using DataObjects.DAOs;
using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService
{
    public class CustomerService : ICustomerService
    {
        static readonly ICustomerRepository customerRepository = RepositoryFactory.GetCustomerRepository;
        
        public List<Customer> GetListOfCustomers()
        {
            return customerRepository.GetCustomers();
        }

        public List<Customer> GetListOfCustomersFiltredByGender(string gender)
        {
            return customerRepository.GetCustomersByGender(gender);
        }

        public void InsertNewCostumer(Customer customer)
        {
            customerRepository.InsertCustomer(customer);
        }
    }
}
