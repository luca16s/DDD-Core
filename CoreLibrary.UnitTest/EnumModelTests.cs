using Bogus;

using CoreLibrary.Models;

using FluentAssertions;

using Xunit;

namespace CoreLibrary.UnitTest
{
    public class EnumModelTests
    {
        [Fact]
        public void EnumDescriptionShouldNotReturnNull()
        {
            var enumModelo = new Faker<EnumModel>()
                .RuleFor(g => g.Description, f => f.Lorem.Word())
                .Generate();

            _ = enumModelo.Description.Should().NotBeNull();
        }

        [Fact]
        public void EnumModelShouldNotBeNull()
        {
            var enumModelo = new Faker<EnumModel>()
                .RuleFor(g => g.Description, f => f.Lorem.Word())
                .Generate();

            _ = enumModelo.Should().NotBeNull();
        }

        [Fact]
        public void EnumValueShouldNotReturnNull()
        {
            var enumModelo = new Faker<EnumModel>()
                .RuleFor(g => g.Value, f => EError.TESTE1)
                .Generate();

            _ = enumModelo.Value.Should().NotBeNull();
        }
    }
}