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
        //static Db db= new Db("SmartCitiesConn");

        public List<Customer> GetCustomers()
        {
            string sql = 
                @"select Number , Gender, Age 
                from [Customer]";
            return db.Read<Customer>(sql,Make).ToList();
        }

        public List<Customer> GetCustomersByGender(string gender)
        {
            string sql =
                @"select Number , Gender, Age 
                from [Customer]
                where Gender=@Gender";
            object[] parametres = new object[]
            {
                "@Gender",gender
            };
            return db.Read<Customer>(sql, Make,parametres).ToList();
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
