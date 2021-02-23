namespace DeadFishStudio.CoreLibrary.UnitTest
{
    using DeadFishStudio.CoreLibrary.Exceptions;

    using FluentAssertions;

    using System;

    using Xunit;

    public class EnumDescriptionNotFoundException_Tests
    {
        [Fact]
        public void ShouldShowDefaultMessage()
        {
            _ = this.Invoking(g => throw new EnumDescriptionNotFoundException())
                .Should()
                .Throw<EnumDescriptionNotFoundException>()
                .WithMessage("Enum informado não contém descrição.");
        }

        [Fact]
        public void ShouldShowCustomizedMessage()
        {
            _ = this.Invoking(g => throw new EnumDescriptionNotFoundException("Teste"))
                .Should()
                .Throw<EnumDescriptionNotFoundException>()
                .WithMessage("Enum informado não contém descrição.\n - Teste");
        }

        [Fact]
        public void ShouldShowSecondMessageWithInnerException()
        {
            _ = this.Invoking(g => throw new EnumDescriptionNotFoundException("Teste", new ArgumentException()))
                .Should()
                .Throw<EnumDescriptionNotFoundException>()
                .WithMessage("Enum informado não contém descrição.\n - Teste");
        }
    }
}
