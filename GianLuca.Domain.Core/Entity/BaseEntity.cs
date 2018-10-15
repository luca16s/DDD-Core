using System;

namespace GianLuca.Domain.Core.Entity
{
    public class BaseEntity
    {
        private Guid _value = Guid.Empty;

        public virtual Guid Id
        {
            get => _value;
            set
            {
                _value = value;

                if (_value == Guid.Empty)
                {
                    _value = Guid.NewGuid();
                }
            }
        }
    }
}
