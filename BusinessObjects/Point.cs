using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Point : BusinessObject
    {
        public decimal CellLat { get; set; }
        public decimal CellLong { get; set; }
        public int SumM { get; set; }
        public int SumF { get; set; }
        public int SumUnknown { get; set; }
        public int SumToEighteen { get; set; }
        public int SumNineteenTwentyFive { get; set; }
        public int SumTwentySixThirtyFive { get; set; }
        public int SumThirtySixFourtyFive { get; set; }
        public int SumFourtySixSixtyFive { get; set; }
        public int SumOverSixstySix { get; set; }
    }
}
