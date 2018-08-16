namespace Sibr.Entities
{
    using System;

    public abstract class Entity
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool IsSynchronized { get; set; }
    }
}