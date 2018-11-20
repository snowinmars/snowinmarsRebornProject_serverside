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
        public void Delete(Guid id)
        {
            if (id == default)
            {
                throw new ArgumentException("It's impossible to delete item without id");
            }

            SiberiaDataLayer.Delete(id);
        }
        private ISiberiaDataLayer SiberiaDataLayer { get; }

        public SiberiaEnvironment[] Filter()
        {
            return SiberiaDataLayer.Filter();
        }

        public SiberiaEnvironment Get(Guid id)
        {
            return SiberiaDataLayer.Get(id);
        }

        public void Update(SiberiaEnvironment item)
        {
            if (item.Id == default)
            {
                throw new ArgumentException("It's impossible to update item without id");
            }

            SiberiaDataLayer.ShallowUpdate(item);
        }

        public void Add(SiberiaEnvironment item)
        {
            item.Id = default;

            SiberiaDataLayer.Add(item);
        }

        public void Upsert(SiberiaEnvironment item)
        {
            SiberiaDataLayer.ShallowUpsert(item);
        }
    }
}
