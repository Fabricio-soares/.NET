using System;

namespace ContextPayment.Shared.Entidades
{
    public abstract class Entity{
        protected Entity(Guid id)
        {
            this.id = Guid.NewGuid();   
        }

        public Guid id { get; private set; }
    }
}