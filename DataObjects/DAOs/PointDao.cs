using BusinessObjects;
using BusinessObjects.Filters;
using DataObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataObjects.DAOs
{
    public class PointDao : BaseDao, IPointDao
    {
        /// <summary>
        /// Get points 
        /// </summary>
        /// <param name="ageFilters">filtered by Age</param>
        /// <returns></returns>
        public List<Point> GetPoints(List<YearsRangeFilterItem> ageFilters, List<GenderFilterItem> genderFilters)
        {
            string procedure = "GetPointData";
            ageFilters = new List<YearsRangeFilterItem>() { new YearsRangeFilterItem("test",new AgeFilterObject(1,18),"test")};
            genderFilters = new List<GenderFilterItem>();
            IEnumerable<AgeFilter> listAgeFilters = ageFilters.Select(x => new AgeFilter(x));
            IEnumerable<GFilter> listGenderFilters = genderFilters.Select(x => new GFilter(x));

            DataTable dtAge = new DataTable();
            dtAge.Columns.Add("FromAge", typeof(int));
            dtAge.Columns.Add("ToAge", typeof(int));
            listAgeFilters.ToList().ForEach(x => dtAge.Rows.Add(x.FromAge, x.ToAge));
            SqlParameter ageParameter = new SqlParameter("@AgeFilter",SqlDbType.Structured);
            ageParameter.SqlValue = dtAge;
            ageParameter.TypeName = "AgeFilterType";

            DataTable dtGender = new DataTable();
            dtGender.Columns.Add("Gender", typeof(string));
            dtGender.Rows.Add(listGenderFilters);
            SqlParameter gParameter = new SqlParameter("@GenderFilter", dtGender);
            gParameter.SqlDbType = SqlDbType.Structured;
            gParameter.TypeName = "GenderFilterType";

            var parms = new SqlParameter[]
            {
                ageParameter,
                gParameter
            };


            return db.ReadStored(procedure, Make, parms).ToList();
        }

        /// <summary>
        ///  Extracts data from the datareader and adds 
        ///  these to the properties of the Point business object
        /// </summary>
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

    }
}
