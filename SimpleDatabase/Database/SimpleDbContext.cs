using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDatabase.Database
{
    class SimpleDbContext:DbContext
    {
        public SimpleDbContext():base()
        {

        }
        public DbSet<Models.User> Users { get; set; }
        
    }
}
