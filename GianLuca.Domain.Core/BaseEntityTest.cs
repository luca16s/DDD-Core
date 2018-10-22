using GianLuca.Domain.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GianLuca.Domain.Core
{
    [TestClass]
    public class BaseEntityTest
    {
        [TestMethod]
        public void GenerateGuid()
        {
            var entity = new BaseEntity();

            Assert.IsNotNull(entity);
        }
    }
}
