﻿using Helping.Generators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helping.Generators.Implementations
{
    public class DateTimeGenerator : IGenerator<DateTime>
    {
        Random random;
        public DateTime MinimumValue { get; private set; }
        public DateTime MaximumValue { get; private set; }

        public DateTimeGenerator()
            : this(DateTime.Now.AddYears(-10), DateTime.Now.AddYears(10))
        { }


        public DateTimeGenerator(DateTime minimumValue, DateTime maximumValue)
        {
            MinimumValue = minimumValue;
            MaximumValue = maximumValue;

            random = RandomSingleton.Instance.Random;
        }

        public DateTime Generate()
        {
            TimeSpan timeSpan = MaximumValue - MinimumValue;
            int dayOffset = random.Next(0, timeSpan.Days);
            return MinimumValue.Date.AddDays(dayOffset) + new TimeSpan(random.Next(0, 24), random.Next(0, 59), random.Next(0, 59));

        }
    }
}
