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
        public SiberiaBranch[] Filter()
        {
            using (var context = new EntityContext())
            {
                var branches = context.DbSiberiaBranches.Fetch();

                return branches.Select(x => x.ToSiberiaBranch()).ToArray();
            }
        }

        public SiberiaBranch Get(Guid id)
        {
            using (var context = new EntityContext())
            {
                var dbSiberiaBranch = context.DbSiberiaBranches.FirstOrDefault(x => x.Id == id);

                if (dbSiberiaBranch == null)
                {
                    throw new NotFoundException($"Can't find siberia branch with id {id}");
                }

                return dbSiberiaBranch.ToSiberiaBranch();
            }
        }
    }
}
