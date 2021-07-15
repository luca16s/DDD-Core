namespace CoreLibrary.UnitTest
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
            BaseEntity<string> entity = new(generatedGuid.ToString());

            //Verify
            _ = generatedGuid.Should().Be(entity.Id);
        }

        [Fact]
        public void ShouldNotHaveErrorsIfGuidIsPassedOnConstructor()
        {
            //Arrange
            Guid generatedGuid = Guid.NewGuid();
            BaseEntity<string> entity = new(generatedGuid.ToString());

            //Act
            TestValidationResult<BaseEntity<string>> result = new BaseEntityValidations<string>().TestValidate(entity);

            //Verify
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
            _ = generatedGuid.Should().Be(entity.Id);
        }
    }
}