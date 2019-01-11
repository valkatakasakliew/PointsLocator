using ActionService;
using BusinessObjects;
using Helping.Generators.Implementations;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace InsertingData
{
    class Program
    {
        static void Main(string[] args)
        {
            // this will create DB objects
            CreateObjectsInDB();

            //Inserting data to DB
            InsertDataIntoCustomerAndTrafficTables(500, 10000);

        }

        /// <summary>
        /// Create object in DB
        /// </summary>
        private static void CreateObjectsInDB()
        {
            string sqlConnectionString = @"Persist Security Info=False;Integrated Security=true;Initial Catalog=SMART_CITIES;server=.\SQLEXPRESS";
            string path = Path.Combine(Environment.CurrentDirectory, @"CreatingSCripts.sql");
            string script = File.ReadAllText(path);

            SqlConnection conn = new SqlConnection(sqlConnectionString);
            Server server = new Server(new ServerConnection(conn));
            server.ConnectionContext.ExecuteNonQuery(script);
        }

        /// <summary>
        /// Inserting data to Customer and Traffic tables
        /// </summary>
        /// <param name="pointsCount">How many point there will be</param>
        /// <param name="customersCount">How many costumers there will be ( will have 5 traffic per customer ) </param>
        private static void InsertDataIntoCustomerAndTrafficTables(int pointsCount,int customersCount)
        {
            ITrafficService trafficService = ServicesFactory.CreateTrafficServcie();
            ICustomerService customerService = ServicesFactory.CreateCustomerService();

            List<string> genders = new List<string>() { "M", "F", "?" };
            List<string> bNumbers = new List<string>() { "tbaslacte", "ebanab", "HTML:internet/000", "blsl" };
            List<string> directions = new List<string>() { "<-", "->" };

            List<Coordinates> coorList = new List<Coordinates>();

            for (int p = 0; p < pointsCount; p++)
            {
                coorList.Add(new Coordinates(new DecimalGenerator(48.1395m, 48.1693m).Generate(), new DecimalGenerator(17.0586m, 17.1730m).Generate()));
            }

            for (int c = 0; c < customersCount; c++)
            {
                Console.WriteLine("------------------------------------------------------");
                string aNumber = new PhoneNumberGenerator().Generate();

                var customer = new Customer()
                {
                    Age = new IntegerGenerator(0, 100).Generate(),
                    Gender = new FromListGetSingleGenerator<string>(genders).Generate(),
                    Number = aNumber
                };
                Console.WriteLine("Trying to add customer " + customer);
                customerService.InsertNewCostumer(customer);
                Console.WriteLine("Customer added successfuly");

                for (int t = 0; t < 5; t++)
                {
                    var coord = new FromListGetSingleGenerator<Coordinates>(coorList).Generate();

                    var trafic = new Traffic()
                    {
                        ANumber = aNumber,
                        BNumber = new FromListGetSingleGenerator<string>(bNumbers).Generate(),
                        Direction = new FromListGetSingleGenerator<string>(directions).Generate(),
                        StartDateTime = new DateTimeGenerator(DateTime.Now.AddHours(-6), DateTime.Now.AddHours(6)).Generate(),
                        CellLat = coord.Lat,
                        CellLong = coord.Long
                    };

                    Console.WriteLine("Trying to add traffic " + trafic);

                    trafficService.InsertNewTraffic(trafic);
                    Console.WriteLine("Traffic added successfuly");
                }

                Console.WriteLine("------------------------------------------------------");
            }

            Console.WriteLine("Operation successfuly");
        }
        
        /// <summary>
        /// Helping to create coordinate for points
        /// </summary>
        class Coordinates
        {
            /// <summary>
            /// Latitude
            /// </summary>
            public decimal Lat { get; set; }
           
            /// <summary>
            /// Longitude
            /// </summary>
            public decimal Long { get; set; }

            /// <summary>
            /// Create coordinate by latitude and longitude
            /// </summary>
            /// <param name="latitude"></param>
            /// <param name="longitude"></param>
            public Coordinates(decimal latitude, decimal longitude)
            {
                Lat = latitude;
                Long = longitude;
            }
        }
    }
}
