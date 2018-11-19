using Simr.Entities;
using Simr.IDataLayer;
using Simr.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simr.Services
{
    public class SiberiaService : ISiberiaService
    {
        public SiberiaService(ISiberiaDataLayer siberiaDataLayer)
        {
            SiberiaDataLayer = siberiaDataLayer;
        }

        private ISiberiaDataLayer SiberiaDataLayer { get; }

        public SiberiaBranch[] Filter()
        {
            return SiberiaDataLayer.Filter();
        }

        public SiberiaBranch Get(Guid id)
        {
            return SiberiaDataLayer.Get(id);
        }
    }
}
