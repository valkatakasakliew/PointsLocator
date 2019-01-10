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
    public class TrafficDao : BaseDao, ITrafficDao
    {
        public List<Traffic> GetTraffics()
        {
            string sql =
               @"SELECT [aNumber]
                      ,[direction]
                      ,[bNumber]
                      ,[startDateTime]
                      ,[cellLong]
                      ,[cellLat]
                  FROM [dbo].[Traffic]";
            return db.Read<Traffic>(sql, Make).ToList();
        }


        public List<Traffic> GetTraficsByNumber(string aNumber)
        {
            string procedure = "GetTrafficByNumber";

            return db.ReadStored(procedure, Make, new SqlParameter("aNumber", aNumber)).ToList();
        }

        public void InsertTrafic(Traffic traffic)
        {
            string procedure = "InsertTraffic";

            db.InsertStored(procedure, Take(traffic));
        }

        static readonly Func<IDataReader, Traffic> Make = reader =>
          new Traffic
          {
              ANumber = reader["aNumber"].AsString(),
              BNumber = reader["bNumber"].AsString(),
              CellLat = reader["cellLat"].AsDecimal(),
              CellLong = reader["cellLong"].AsDecimal(),
              Direction = reader["direction"].AsString(),
              StartDateTime = reader["startDateTime"].AsDateTime()
          };

        SqlParameter[] Take(Traffic traffic)
        {
            return new SqlParameter[]
            {
                new SqlParameter("@aNumber",traffic.ANumber),
                new SqlParameter("@direction",traffic.Direction),
                new SqlParameter("@bNumber",traffic.BNumber),
                new SqlParameter("@startDateTime",traffic.StartDateTime),
                new SqlParameter("@cellLong",traffic.CellLong),
                new SqlParameter("@cellLat",traffic.CellLat)
            };
        }

    }
}
