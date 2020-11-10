using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.Contact
{
    public class IDbContext : DbContext
    {
        public IDbContext(string dbConnectionStringOrName) : base(dbConnectionStringOrName)
        {

        }
    }
}
