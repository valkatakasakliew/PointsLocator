using Helping.Generators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helping.Generators.Implementations
{
    public class DecimalGenerator : IGenerator<decimal>
    {
        readonly Random random;

        public decimal MinimumValue { get; set; }
        public decimal MaximumValue { get; set; }

        public DecimalGenerator()
            :this(0.0m,100)
        {

        }

        public DecimalGenerator(decimal minimumValue,decimal maximumValue)
        {
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;

            random = RandomSingleton.Instance.Random;
        }

        public decimal Generate()
        {
            byte fromScale = new System.Data.SqlTypes.SqlDecimal(MinimumValue).Scale;
            byte toScale = new System.Data.SqlTypes.SqlDecimal(MaximumValue).Scale;

            byte scale = (byte)(fromScale + toScale);
            if (scale > 28)
                scale = 28;

            decimal r = new decimal(random.Next(), random.Next(), random.Next(), false, scale);
            if (Math.Sign(MinimumValue) == Math.Sign(MaximumValue) || MinimumValue == 0 || MaximumValue == 0)
                return decimal.Remainder(r, MaximumValue - MinimumValue) + MinimumValue;

            bool getFromNegativeRange = (double)MinimumValue + random.NextDouble() * ((double)MaximumValue - (double)MinimumValue) < 0;
            return getFromNegativeRange ? decimal.Remainder(r, -MinimumValue) + MinimumValue : decimal.Remainder(r, MaximumValue);
        }
    }
}
