using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Traffic : BusinessObject
    {
        public string ANumber { get; set; }
        public string BNumber { get; set; }
        public string Direction { get; set; }
        public DateTime StartDateTime { get; set; }
        public decimal CellLong { get; set; }
        public decimal CellLat { get; set; }

        public override string ToString()
        {
            return String.Format("ANumber [{0}] ({1},{2} - {3})", ANumber, CellLong, CellLat, StartDateTime);
        }
    }
}
