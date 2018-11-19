using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.DataLayer.DbEntities
{
    public class DbSiberiaBranch
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Enviroment { get; set; }
    }
}
