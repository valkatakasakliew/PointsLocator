using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class CustomerTraffic : BusinessObject
    {
        public string Number { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public decimal CellLong { get; set; }

        public decimal CellLat { get; set; }
    }
}
