namespace GianLuca.Domain.Core.Interfaces.Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFactory<out T>
    {
        T Create();
    }
}
