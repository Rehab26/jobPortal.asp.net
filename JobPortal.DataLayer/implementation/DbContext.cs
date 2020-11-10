using JobPortal.Data.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortal.Data.implementation
{
    public class DbContext : IDbContext
    {
        public DbContext(string dbConnectionStringOrName)
            : base(dbConnectionStringOrName)
        {
        }
    }
}
