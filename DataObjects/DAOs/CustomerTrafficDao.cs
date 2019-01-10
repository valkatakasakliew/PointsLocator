using BusinessObjects;
using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.DAOs
{
    class CustomerTrafficDao :BaseDao, ICustomerTrafficDao
    {
        public List<CustomerTraffic> GetCustomerTraffics()
        {
            string procedure = "GetCustomersAndTraffic";


            return db.ReadStored(procedure, Make).ToList();

            
        }

        static Func<IDataReader, CustomerTraffic> Make = reader =>
           new CustomerTraffic
           {
               Number = reader["Number"].AsString(),
               Gender = reader["Gender"].AsString(),
               Age = reader["Age"].AsInt(),
               CellLat = reader["cellLat"].AsDecimal(),
               CellLong = reader["cellLong"].AsDecimal()
           };
    }
}
