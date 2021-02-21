namespace DeadFishStudio.CoreLibrary.UnitTest
{
    using DeadFishStudio.CoreLibrary.Validations;

    using FluentAssertions;

    using FluentValidation.TestHelper;

    using System;

    using Xunit;

    public class BaseEntityTest
    {
        [Fact]
        public void ShouldNotHaveErrorsIfGuidIsNotEmpty()
        {
            //Arrange
            var entity = new BaseEntity();

            //Act
            var result = new BaseEntityValidations().TestValidate(entity);

            //Verify
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void ShouldNotHaveErrorsIfGuidIsPassedOnConstructor()
        {
            //Arrange
            var generatedGuid = Guid.NewGuid();
            var entity = new BaseEntity(generatedGuid);

            //Act
            var result = new BaseEntityValidations().TestValidate(entity);

            //Verify
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
            _ = generatedGuid.Should().Be(entity.Id);
        }

        [Fact]
        public void CheckIfGuidPassedIsEqual()
        {
            //Arrange
            var generatedGuid = Guid.NewGuid();

            //Act
            var entity = new BaseEntity(generatedGuid);

            //Verify
            _ = generatedGuid.Should().Be(entity.Id);
        }
    }
}