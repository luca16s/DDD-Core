namespace CoreLibrary.UnitTest
{
    using CoreLibrary.Exceptions;
    using CoreLibrary.Utils.Extensions;

    using FluentAssertions;

    using Xunit;

    public class StringExtensions_Tests
    {
        [Fact]
        public void ShouldReturnEnumValueFromText()
        {
            string texto = "TESTE 1";

            EOKEnum result = texto.GetEnumValueFromDescription<EOKEnum>();

            _ = result.Should().Be(EOKEnum.TESTE_1);
        }

        [Fact]
        public void ShouldThrowExceptionWhenItemNotEncoutered()
        {
            string texto = "ABC 1";

            _ = this.Invoking(_ => texto.GetEnumValueFromDescription<EOKEnum>())
                .Should()
                .Throw<EnumItemNotFoundException>()
                .WithMessage($"Item não encontrado no enumerador.\n - {texto}");
        }
    }
}