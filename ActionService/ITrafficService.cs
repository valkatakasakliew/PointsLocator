using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService
{
    public interface ITrafficService
    {
        List<Traffic> GetListOfTraffics();

        List<Traffic> GetListOfTrafficsFilteredByNumber(string aNumber);

        void InsertNewTraffic(Traffic traffic);
    }
}
