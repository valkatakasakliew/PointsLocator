using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.Interfaces
{
    public interface ITrafficDao
    {
        List<Traffic> GetTraffics();

        List<Traffic> GetTraficsByNumber(string aNumber);

        void InsertTrafic(Traffic traffic);
    }
}
