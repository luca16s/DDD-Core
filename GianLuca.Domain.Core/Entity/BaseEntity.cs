namespace GianLuca.Domain.Core.Entity
{
    using System;

    public class BaseEntity
    {
        public BaseEntity() => this.Id = Guid.NewGuid();

        public BaseEntity(Guid idGuid)
        {
            if (idGuid != Guid.Empty)
            {
                this.Id = idGuid;
            }
        }

        public Guid Id { get; private set; }
    }
}
