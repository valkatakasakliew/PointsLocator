using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService
{
    public interface ICustomerService
    {
        List<Customer> GetListOfCustomers();

        List<Customer> GetListOfCustomersFiltredByGender(string gender);

        void InsertNewCostumer(Customer customer);
    }
}
