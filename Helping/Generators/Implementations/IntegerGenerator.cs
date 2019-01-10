﻿using Helping.Generators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helping.Generators.Implementations
{
    public class IntegerGenerator : IGenerator<int>
    {
        Random random;

        public int MinimumValue { get; set; }
        public int MaximumValue { get; set; }

        public IntegerGenerator()
            : this(0, 100)
        { }

        public IntegerGenerator(int minimumValue, int maximumValue)
        {
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;

            random = RandomSingleton.Instance.Random;
        }

        public int Generate()
        {
            return random.Next(MinimumValue, MaximumValue + 1);
        }
    }
}
