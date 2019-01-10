using BusinessObjects;
using BusinessObjects.Filters;
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
    public class PointDao : BaseDao, IPointDao
    {
        public List<Point> GetPoints(List<YearsRangeFilterItem> ageFilters)
        {
            string procedure = "GetPointData";

            var l = ageFilters.Select(x => new AgeFilter(x.FromValue, x.ToValue));
            DataTable dataTable = new DataTable();
            SqlParameter sqlParameter = new SqlParameter("@AgeFilter", CreateDataTable(ageFilters));
            sqlParameter.SqlDbType = SqlDbType.Structured;
            sqlParameter.TypeName = "AgeFilterType";


            return db.ReadStored(procedure, Make, sqlParameter).ToList();
        }

        static readonly Func<IDataReader, Point> Make = reader =>
         new Point
         {
             CellLat = reader["CellLat"].AsDecimal(),
             CellLong = reader["CellLong"].AsDecimal(),
             SumM = reader["SumM"].AsInt(),
             SumF = reader["SumF"].AsInt(),
             SumUnknown = reader["SumUnknown"].AsInt(),
             SumToEighteen = reader["SumToEighteen"].AsInt(),
             SumNineteenTwentyFive = reader["SumNineteenTwentyFive"].AsInt(),
             SumTwentySixThirtyFive = reader["SumTwentySixThirtyFive"].AsInt(),
             SumThirtySixFourtyFive = reader["SumThirtySixFourtyFive"].AsInt(),
             SumFourtySixSixtyFive = reader["SumFourtySixSixtyFive"].AsInt(),
             SumOverSixstySix = reader["SumOverSixstySix"].AsInt()
         };

        private static DataTable CreateDataTable(IEnumerable<YearsRangeFilterItem> filterItems)
        {
            DataTable table = new DataTable();
            table.Columns.Add("FromAge", typeof(int));
            table.Columns.Add("ToAge", typeof(int));
            foreach (YearsRangeFilterItem filterItem in filterItems)
            {
                table.Rows.Add(filterItem.FromValue,filterItem.ToValue);
            }
            return table;
        }
    }
}
