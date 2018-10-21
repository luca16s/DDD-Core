using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GianLuca.Domain.Core.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GianLuca.Domain.Core.UnitTest
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
