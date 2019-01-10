using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ActionService;
using BusinessObjects;

namespace Chalenge.Model
{
    public class Point
    {
        Customer Customer { get; set; }

        List<Traffic> Traffics { get; set; }

        public Point(Customer customer)
        {
            this.Customer = customer;

            ITrafficService service = ServicesFactory.CreateTrafficServcie();
            Traffics = service.GetListOfTrafficsFilteredByNumber(customer.Number);
        }
    }
}