namespace DeadFishStudio.CoreLibrary.UnitTest
{
    using DeadFishStudio.CoreLibrary;
    using DeadFishStudio.CoreLibrary.Exceptions;
    using DeadFishStudio.CoreLibrary.Extensions;

    using FluentAssertions;

    using System.Collections.Generic;

    using Xunit;

    public class EnumExtensionsTests
    {
        [Fact]
        public void DescriptionShouldReturnValueOfDescriptionAnnotation()
        {
            string description = EOKEnum.TESTE_1.Description();

            _ = description.Should().Be("TESTE 1");
        }

        [Fact]
        public void DescriptionShouldReturnEnumWithUnderscoreReplaced()
        {
            _ = this.Invoking(g => EErroEnum.TESTE_3.Description())
                .Should()
                .Throw<EnumDescriptionNotFoundException>()
                .WithMessage("Enum informado não contém descrição.");
        }

        [Fact]
        public void GetAllValuesAndDescriptionsShouldReturnListOfItems()
        {
            var listaModelo = new EnumModel[]
            {
                new EnumModel { Value = EOKEnum.TESTE_1, Description ="TESTE 1" },
                new EnumModel { Value = EOKEnum.TESTE_2, Description ="TESTE 2" },
                new EnumModel { Value = EOKEnum.TESTE_3, Description ="TESTE 3" },
            };

            IEnumerable<EnumModel> retorno = EOKEnum.TESTE_1.GetAllValuesAndDescriptions();

            _ = retorno.Should().NotBeEmpty()
                .And.HaveCount(3)
                .And.OnlyHaveUniqueItems()
                .And.BeEquivalentTo(listaModelo);
        }
    }
}