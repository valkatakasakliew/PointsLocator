using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService.Repositories
{
    public interface ITrafficRepository
    {
        List<Traffic> GetTraffics();

        List<Traffic> GetTrafficsByNumber(string aNumber);

        void InsertTraffic(Traffic traffic);
    }
}
