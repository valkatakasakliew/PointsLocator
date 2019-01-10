using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Interfaces
{
    public interface ICustomerDao
    {
        List<Customer> GetCustomers();

        List<Customer> GetCustomersByGender(string gender);

        void InsertCustomer(Customer customer);
    }
}
