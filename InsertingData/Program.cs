using ActionService;
using BusinessObjects;
using Helping.Generators.Implementations;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace InsertingData
{
    class Program
    {
        static void Main(string[] args)
        {


            ITrafficService trafficService = ServicesFactory.CreateTrafficServcie();
            ICustomerService customerService = ServicesFactory.CreateCustomerService();

            List<string> genders = new List<string>() { "M", "F", "?" };
            List<string> bNumbers = new List<string>() { "tbaslacte", "ebanab", "HTML:internet/000", "blsl" };
            List<string> directions = new List<string>() { "<-", "->" };

            List<Coordinates> coorList = new List<Coordinates>();

            for (int p = 0; p < 500; p++)
            {
                coorList.Add(new Coordinates(new DecimalGenerator(48.1395m, 48.1693m).Generate(), new DecimalGenerator(17.0586m, 17.1730m).Generate() ));
            }

            for (int c = 0; c < 2000000; c++)
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

            //  Console.WriteLine(new DecimalGenerator(17.0586m, 17.1730m).Generate());

            //List<CustomerTraffic> listT = new List<CustomerTraffic>();

            //for (int t = 0; t < 500000; t++)
            //{
            //    listT.Add(new CustomerTraffic()
            //    {
            //        Number = new PhoneNumberGenerator().Generate(),
            //        Age = new IntegerGenerator(0, 100).Generate(),
            //        CellLat = new DecimalGenerator(48.1395m, 48.1693m).Generate(),
            //        CellLong = new DecimalGenerator(17.0586m, 17.1730m).Generate(),
            //        Gender = new FromListGetSingleGenerator<string>(genders).Generate()
            //    });
            //}

            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();

            //var json = GetMarkers(listT);

            //stopWatch.Stop();

            //TimeSpan ts = stopWatch.Elapsed;

            //Console.WriteLine("GetMarkers time execution"+ String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                                ts.Hours, ts.Minutes, ts.Seconds,
            //                                                ts.Milliseconds / 10));

            //stopWatch = new Stopwatch();
            //stopWatch.Start();

            //var newJson = Newtonsoft.Json.JsonConvert.SerializeObject(listT);

            //stopWatch.Stop();

            //ts = stopWatch.Elapsed;

            //Console.WriteLine("ToJson time execution" + String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //                                                ts.Hours, ts.Minutes, ts.Seconds,
            //                                                ts.Milliseconds / 10));

            //var obj = Newtonsoft.Json.JsonConvert.SerializeObject(listT);
            //Console.WriteLine(obj);

            //ICustomerTrafficService ctService = ServicesFactory.CreateCustomerTrafficService();
            //var l = ctService.GetListOfCustomerTraffics();

        }
        class Coordinates
        {
            public decimal Lat { get; set; }
            public decimal Long { get; set; }

            public Coordinates(decimal latitude, decimal longtitude)
            {
                Lat = latitude;
                Long = longtitude;
            }
        }
    }
}
