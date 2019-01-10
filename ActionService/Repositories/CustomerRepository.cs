using BusinessObjects;
using DataObjects.DAOs;
using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        static readonly ICustomerDao customerDao = DaoFactory.GetCustomerDao;

        public List<Customer> GetCustomers()
        {
            return customerDao.GetCustomers();
        }

        public List<Customer> GetCustomersByGender(string gender)
        {
            return customerDao.GetCustomersByGender(gender);
        }

        public void InsertCustomer(Customer customer)
        {
            customerDao.InsertCustomer(customer);
        }
    }
}
