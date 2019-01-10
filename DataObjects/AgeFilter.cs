using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
    public class AgeFilter
    {
        public int From { get; set; }

        public int To { get; set; }

        public AgeFilter(int from,int to)
        {
            this.From = from;
            this.To = to;
        }
    }
}
