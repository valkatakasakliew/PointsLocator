﻿using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionService.Repositories
{
    public interface ICustomerTrafficRepository
    {
        List<CustomerTraffic> GetCustomerTraffics();
    }
}
