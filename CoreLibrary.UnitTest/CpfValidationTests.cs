namespace CoreLibrary.UnitTest
{

    using CoreLibrary.Brazil.Models.Documents;
    using CoreLibrary.Brazil.Validations.Documents;

    using Xunit;

    public class CpfValidationTests
    {
        [Fact]
        public void TESTA_RETORNANDO_FALSE_SE_STRING_FOR_NULA()
        {
            Cpf cpf = null;

            var cpfValidation = new CpfValidation(cpf);

            Assert.False(cpfValidation.IsValid());
        }

        [Fact]
        public void TESTA_RETORNANDO_FALSE_QUANDO_PRIMEIRO_DIGITO_DO_CPF_FOR_INVALIDO()
        {
            Cpf cpf = new(new int[3] { 1, 9, 2 },
                new int[3] { 1, 0, 3 },
                new int[3] { 6, 3, 6 },
                new int[2] { 1, 0 });

            var cpfValidation = new CpfValidation(cpf);

            Assert.False(cpfValidation.IsValid());
        }

        [Fact]
        public void TESTA_RETORNANDO_FALSE_QUANDO_SEGUNDO_DIGITO_DO_CPF_FOR_INVALIDO()
        {
            Cpf cpf = new(new int[3] { 1, 9, 2 },
                new int[3] { 1, 0, 3 },
                new int[3] { 6, 3, 6 },
                new int[2] { 2, 1 });

            var cpfValidation = new CpfValidation(cpf);

            Assert.False(cpfValidation.IsValid());
        }

        [Fact]
        public void TESTA_SE_RETORNA_VALIDO_QUANDO_CPF_VERDADEIRO()
        {
            Cpf cpf = new(new int[3] { 2, 3, 2 },
                new int[3] { 3, 2, 8 },
                new int[3] { 6, 3, 0 },
                new int[2] { 7, 8 });

            var cpfValidation = new CpfValidation(cpf);

            Assert.True(cpfValidation.IsValid());
        }

        [Fact]
        public void TESTA_SE_RETORNA_FALSO_QUANDO_CPF_FALSO()
        {
            Cpf cpf = new(new int[3] { 3, 1, 1 },
                new int[3] { 5, 1, 4 },
                new int[3] { 3, 4, 0 },
                new int[2] { 8, 9 });

            var cpfValidation = new CpfValidation(cpf);

            Assert.False(cpfValidation.IsValid());
        }

        [Fact]
        public void TESTA_RETORNO_CORRETO_DE_REGIOES()
        {
            Cpf cpf = new(new int[3] { 3, 1, 1 },
                new int[3] { 5, 1, 4 },
                new int[3] { 3, 4, 0 },
                new int[2] { 8, 9 });

            Assert.Equal("CE, MA e PI", cpf.GetCpfRegion());
        }
    }
}
