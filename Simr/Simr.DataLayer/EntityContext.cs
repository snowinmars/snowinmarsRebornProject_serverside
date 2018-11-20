using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<Guid>()
                .Where(x => x.Name.ToLower() == "id")
                .Configure(x => x.HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed));
        }

        public IDbSet<DbSiberiaEnvironment> DbSiberiaEnvironments { get; set; }

        public IDbSet<DbAuthor> DbAuthors { get; set; }

        public IDbSet<DbBook> DbBooks { get; set; }

        public IDbSet<DbUser> DbUsers { get; set; }
    }
}
