using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simr.DataLayer.DbEntities;

namespace Simr.DataLayer
{
    public class EntityContext : DbContext
    {
        static EntityContext()
        {
            // Forging
            var type = typeof(System.Data.Entity.SqlServer.SqlProviderServices);

            if (type == null)
            {
                throw new Exception();
            }
        }

        public EntityContext() : base("SimrDatabase")
        {
        }

        public DbSet<DbSiberiaBranch> DbSiberiaBranches { get; set; }

        public DbSet<DbAuthor> DbAuthors { get; set; }

        public DbSet<DbBook> DbBooks { get; set; }

        public DbSet<DbUser> DbUsers { get; set; }
    }
}
