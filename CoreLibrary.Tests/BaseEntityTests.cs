namespace CoreLibrary.Tests
{
    using System;

    using CoreLibrary.Models;
    using CoreLibrary.Validations;

    using FluentAssertions;

    using FluentValidation.TestHelper;

    using Xunit;

    public class BaseEntityTest
    {
        [Fact]
        public void CheckIfGuidPassedIsEqual()
        {
            //Arrange
            Guid generatedGuid = Guid.NewGuid();

            //Act
            BaseEntity entity = new(generatedGuid);

            //Verify
            _ = generatedGuid.Should().Be(entity.Id);
        }

        [Fact]
        public void ShouldNotHaveErrorsIfGuidIsPassedOnConstructor()
        {
            //Arrange
            Guid generatedGuid = Guid.NewGuid();
            BaseEntity entity = new(generatedGuid);

            //Act
            TestValidationResult<BaseEntity> result = new BaseEntityValidations().TestValidate(entity);

            //Verify
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
            _ = generatedGuid.Should().Be(entity.Id);
        }
    }
}