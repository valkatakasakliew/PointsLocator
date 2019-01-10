using Helping.Generators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helping.Generators.Implementations
{
    public class PhoneNumberGenerator : IGenerator<string>
    {
        Random random;

        public PhoneNumberGenerator()
        {
            random = RandomSingleton.Instance.Random;
        }

        public string Generate()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("+421");
            int phoneNum = (int)random.Next(100000000, 999999999);

            sb.Append(phoneNum.ToString());
            return sb.ToString();
        }

    }
}
