using BusinessObjects;
using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.DAOs
{
    public class CustomerDao : BaseDao,ICustomerDao
    {
        /// <summary>
        /// Get all customers
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetCustomers()
        {
            string procName = "GetCustomers";

            return db.Read<Customer>(procName,Make).ToList();
        }

        /// <summary>
        /// Get customers by gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        public List<Customer> GetCustomersByGender(string gender)
        {
            string procName ="GetCustomerByGender";
            
            return db.ReadStored<Customer>(procName, Make,new SqlParameter("@gender",gender)).ToList();
        }

        public void InsertCustomer(Customer customer)
        {
            string procName = "InsertCustomer";

            db.InsertStored(procName, Take(customer));
        }

        static Func<IDataReader, Customer> Make = reader =>
           new Customer
           {
               Number = reader["Number"].AsString(),
               Gender = reader["Gender"].AsString(),
               Age = reader["Age"].AsInt()
           };

        SqlParameter[] Take(Customer customer)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@Number", customer.Number),
                new SqlParameter("@Gender", customer.Gender),
                new SqlParameter("@Age", customer.Age)
            };
        }
    }
}
