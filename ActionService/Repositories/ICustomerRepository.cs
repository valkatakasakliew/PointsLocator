using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService.Repositories
{
    public interface ICustomerRepository
    {
        List<Customer> GetCustomers();

        List<Customer> GetCustomersByGender(string gender);

        void InsertCustomer(Customer customer);
    }
}
