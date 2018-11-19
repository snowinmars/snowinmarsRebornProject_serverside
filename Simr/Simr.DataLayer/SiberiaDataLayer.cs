using Simr.Common;
using Simr.Entities;
using Simr.IDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.DataLayer
{
    public class SiberiaDataLayer : ISiberiaDataLayer
    {
        public SiberiaEnvironment[] Filter()
        {
            using (var context = new EntityContext())
            {
                var branches = context.DbSiberiaEnvironments.Fetch();

                return branches.Select(x => x.ToSiberiaEnvironment()).ToArray();
            }
        }

        public SiberiaEnvironment Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbSiberiaBranch = context.DbSiberiaEnvironments.FirstOrDefault(x => x.Id == id);

                if (dbSiberiaBranch == null)
                {
                    throw new NotFoundException($"Can't find siberia branch with id {id}");
                }

                return dbSiberiaBranch.ToSiberiaEnvironment();
            }
        }
    }
}
