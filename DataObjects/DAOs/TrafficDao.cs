using BusinessObjects;
using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataObjects.DAOs
{
    public class TrafficDao : BaseDao, ITrafficDao
    {
        /// <summary>
        /// Get all traffics
        /// </summary>
        /// <returns></returns>
        public List<Traffic> GetTraffics()
        {
            string procName = "GetTraffics";

            return db.Read<Traffic>(procName, Make).ToList();
        }
        /// <summary>
        /// Get traffics by number
        /// </summary>
        /// <param name="aNumber"></param>
        /// <returns></returns>
        public List<Traffic> GetTraficsByNumber(string aNumber)
        {
            string procedure = "GetTrafficByNumber";

            return db.ReadStored(procedure, Make, new SqlParameter("aNumber", aNumber)).ToList();
        }

        /// <summary>
        /// Insert traffic record
        /// </summary>
        /// <param name="traffic"></param>
        public void InsertTrafic(Traffic traffic)
        {
            string procedure = "InsertTraffic";

            db.InsertStored(procedure, Take(traffic));
        }

        /// <summary>
        ///  Extracts data from the datareader and adds 
        ///  these to the properties of the Traffic business object
        /// </summary>
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

        /// <summary>
        ///  extracts property values from the business object 
        ///  and adds these to an SqlParameter array
        /// </summary>
        /// <param name="traffic"></param>
        /// <returns></returns>
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
