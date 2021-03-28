namespace CoreLibrary.UnitTest
{
    using CoreLibrary;
    using CoreLibrary.Exceptions;
    using CoreLibrary.Extensions;

    using FluentAssertions;

    using System;
    using System.Collections.Generic;

    using Xunit;

    public class EnumItemNotFoundException_Tests
    {
        [Fact]
        public void ShouldShowDefaultMessage()
        {
            _ = this.Invoking(g => throw new EnumItemNotFoundException())
                .Should()
                .Throw<EnumItemNotFoundException>()
                .WithMessage("Item não encontrado no enumerador.");
        }

        [Fact]
        public void ShouldShowCustomizedMessage()
        {
            _ = this.Invoking(g => throw new EnumItemNotFoundException("Teste"))
                .Should()
                .Throw<EnumItemNotFoundException>()
                .WithMessage("Item não encontrado no enumerador.\n - Teste");
        }

        [Fact]
        public void ShouldShowSecondMessageWithInnerException()
        {
            _ = this.Invoking(g => throw new EnumItemNotFoundException("Teste", new ArgumentException()))
                .Should()
                .Throw<EnumItemNotFoundException>()
                .WithMessage("Item não encontrado no enumerador.\n - Teste");
        }
    }
}
