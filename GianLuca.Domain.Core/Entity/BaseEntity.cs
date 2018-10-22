using System;

namespace GianLuca.Domain.Core.Entity
{
    public class BaseEntity
    {
        private readonly Guid _value;

        public BaseEntity()
        {
            _value = Guid.NewGuid();
        }

        public virtual Guid Id => _value;
    }
}
