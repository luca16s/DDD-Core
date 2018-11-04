using System;

namespace GianLuca.Domain.Core.Entity
{
    public class BaseEntity
    {
        public BaseEntity() => Id = Guid.NewGuid();

        public BaseEntity(Guid idGuid)
        {
            if (idGuid != Guid.Empty)
                Id = idGuid;
        }

        public virtual Guid Id { get; }
    }
}
