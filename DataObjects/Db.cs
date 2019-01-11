using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataObjects
{
    public class Db
    {
        static DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
        private string ConnectionString { get; set; }

        public Db(string conn = null)
        {
            if (conn == null) 
                ConnectionString =ConfigurationManager.ConnectionStrings[1].ConnectionString;
            else
                ConnectionString = ConfigurationManager.ConnectionStrings[conn].ConnectionString;
        }


        // fast read and instantiate (i.e. make) a collection of objects

        public IEnumerable<T> Read<T>(string sql, Func<IDataReader, T> make, params object[] parms)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand(sql, connection, parms))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return make(reader);
                        }
                    }
                }
            }
        }

        public IEnumerable<T> ReadStored<T>(string procedure, Func<IDataReader, T> make, params SqlParameter[] parms)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateStoredCommand(procedure, connection, parms))
                {
                    command.CommandTimeout = 2000;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return make(reader);
                        }
                    }
                }
            }
        }

        
        // insert a new record

        public int Insert(string sql, params object[] parms)
        {

            using (var connection = CreateConnection())
            {
                using (var command = CreateCommand(sql + ";SELECT SCOPE_IDENTITY();", connection, parms))
                {
                    return int.Parse(command.ExecuteScalar().ToString());
                }
            }

        }

        // insert new records via stored procedure
        public void InsertStored(string procedure,params SqlParameter[] parms)
        {
            using (var connection = CreateConnection())
            {
                using (var command = CreateStoredCommand(procedure,connection,parms))
                {
                    command.ExecuteScalar();
                }
            }
        }

        // creates a connection object

        DbConnection CreateConnection()
        {
            var connection = dbProviderFactory.CreateConnection();
            connection.ConnectionString = ConnectionString;
            connection.Open();
            return connection;
        }

        // creates a command object

        DbCommand CreateCommand(string sql, DbConnection conn, params object[] parms)
        {
            var command = dbProviderFactory.CreateCommand();
            command.Connection = conn;
            command.CommandText = sql;
            command.AddParameters(parms);
            return command;
        }

        DbCommand CreateStoredCommand(string procedure, DbConnection conn, params SqlParameter[] parms)
        {
            var command = dbProviderFactory.CreateCommand();
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procedure;
            command.Parameters.AddRange(parms);
            return command;
        }
    }

    // extension methods

    public static class DbExtentions
    {
        // adds parameters to a command object

        public static void AddParameters(this DbCommand command, object[] parms)
        {
            if (parms != null && parms.Length > 0)
            {
                //  processes a name/value pair at each iteration

                for (int i = 0; i < parms.Length; i += 2)
                {
                    string name = parms[i].ToString();

                    // no empty strings to the database

                    if (parms[i + 1] is string && (string)parms[i + 1] == "")
                        parms[i + 1] = null;

                    // if null, set to DbNulls

                    object value = parms[i + 1] ?? DBNull.Value;

                    var dbParameter = command.CreateParameter();
                    dbParameter.ParameterName = name;
                    dbParameter.Value = value;

                    command.Parameters.Add(dbParameter);
                }
            }
        }

    }
}
