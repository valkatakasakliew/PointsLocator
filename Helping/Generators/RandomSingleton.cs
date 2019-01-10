using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helping.Generators
{
    public sealed class RandomSingleton
    {
        private static readonly object SyncRoot = new Object();
        private static volatile RandomSingleton instance;

        public Random Random { get; private set; }

        private RandomSingleton()
        {
            Random = new Random();
        }

        public static RandomSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (instance == null)
                            instance = new RandomSingleton();
                    }
                }

                return instance;
            }
        }
    }
}
