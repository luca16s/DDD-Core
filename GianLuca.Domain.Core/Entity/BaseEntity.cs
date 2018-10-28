using System;

namespace GianLuca.Domain.Core.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public BaseEntity(Guid guid)
        {
            if (guid != Guid.Empty)
                Id = guid;
        }

        public virtual Guid Id { get; }
    }
}
