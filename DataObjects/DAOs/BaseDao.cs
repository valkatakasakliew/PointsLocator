using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects.DAOs
{
    public abstract class BaseDao
    {
        protected readonly Db db = new Db("SmartCitiesConn");

    }
}
