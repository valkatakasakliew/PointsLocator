using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Customer: BusinessObject
    {
        public string Number { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return string.Format("Number:[{0}],Age:{1} - {2}", Number, Age, Gender);
        }
    }
}
