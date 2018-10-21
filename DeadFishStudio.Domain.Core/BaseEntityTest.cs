using DeadFishStudio.Domain.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeadFishStudio.Domain.Core.UnitTest
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
