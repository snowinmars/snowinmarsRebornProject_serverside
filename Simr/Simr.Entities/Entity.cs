using System;

namespace Simr.Entities
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool IsSynchronized { get; set; }
    }
}