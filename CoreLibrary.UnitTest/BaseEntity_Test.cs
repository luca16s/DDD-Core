using CoreLibrary.Models;
using CoreLibrary.Validations;

using FluentAssertions;

using FluentValidation.TestHelper;

using System;

using Xunit;

namespace CoreLibrary.UnitTest
{
    public class BaseEntity_Test
    {
        [Fact]
        public void CheckIfGuidPassedIsEqual()
        {
            //Arrange
            Guid generatedGuid = Guid.NewGuid();

            //Act
            BaseEntity entity = new BaseEntity(generatedGuid);

            //Verify
            _ = generatedGuid.Should().Be(entity.Id);
        }

        [Fact]
        public void ShouldNotHaveErrorsIfGuidIsNotEmpty()
        {
            //Arrange
            BaseEntity entity = new BaseEntity();

            //Act
            TestValidationResult<BaseEntity> result = new BaseEntityValidations().TestValidate(entity);

            //Verify
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void ShouldNotHaveErrorsIfGuidIsPassedOnConstructor()
        {
            //Arrange
            Guid generatedGuid = Guid.NewGuid();
            BaseEntity entity = new BaseEntity(generatedGuid);

            //Act
            TestValidationResult<BaseEntity> result = new BaseEntityValidations().TestValidate(entity);

            //Verify
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
            _ = generatedGuid.Should().Be(entity.Id);
        }
    }
}