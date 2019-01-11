using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Filters
{
    public class FilterObject
    {
    }

    public class AgeFilterObject : FilterObject
    {
        public AgeFilterObject(int fromAge, int toAge)
        {
            this.FromAge = fromAge;
            this.ToAge = toAge;
        }
        public int FromAge { get; set; }
        public int ToAge { get; set; }
    }

    public class GenderFilterObject : FilterObject
    {
        public GenderFilterObject(string gender)
        {
            this.Gender = gender;
        }
        public string Gender { get; set; }
    }
}
