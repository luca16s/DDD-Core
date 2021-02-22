namespace DeadFishStudio.CoreLibrary.UnitTest
{
    using DeadFishStudio.CoreLibrary.Utils.Extensions;

    using FluentAssertions;

    using Xunit;

    public class StringExtensionsTests
    {
        [Fact]
        public void ShouldReturnEnumValueFromText()
        {
            string texto = "TESTE 1";

            var result = texto.GetEnumValueFromDescription<EOKEnum>();

            _ = result.Should().Be(EOKEnum.TESTE_1);
        }
    }
}
