namespace CoreLibrary.Brazil.Validations.Documents
{
    using System.Globalization;
    using System.Linq;

    using CoreLibrary.Brazil.Models.Documents;

    /// <summary>
    /// Classe para realização da validação de CPF.
    /// </summary>
    public class CpfValidation
    {
        private readonly Cpf Cpf;
        public CpfValidation(Cpf cpf)
        {
            Cpf = cpf;
        }

        /// <summary>
        /// Valida CPF passado.
        /// </summary>
        /// <returns>Retorna se CPF é válido.</returns>
        public bool IsValid()
        {
            return Cpf is not null
                && HasFalseSequences(Cpf)
                && CheckCpfVerifyingDigit(Cpf);
        }

        /// <summary>
        /// Valida se todos os os dígitos são idênticos.
        /// </summary>
        /// <param name="cpf">Texto contendo o CPF.</param>
        /// <returns>Retorna falso se cpf contém todos os dígitos iguais.</returns>
        private static bool HasFalseSequences(Cpf cpf)
        {
            return cpf.CpfArray
                .GroupBy(x => x.ToString(CultureInfo.InvariantCulture)).Count() != 11;
        }

        /// <summary>
        /// Método que checa o dígito Verificador do CPF.
        /// </summary>
        /// <param name="cpf">Texto contendo o CPF.</param>
        /// <returns>Verdadeiro se ambos os dígitos forem verdadeiros.</returns>
        private static bool CheckCpfVerifyingDigit(Cpf cpf)
        {
            return CheckFirstDigitIsValid(cpf)
                && CheckSecondDigitIsValid(cpf);
        }

        private static bool CheckFirstDigitIsValid(Cpf cpf)
        {
            var result = CalculateBaseDigits(cpf, 0, 9) * 10 % 11;

            return result == cpf.GetFirstCheckupDigit();
        }

        private static bool CheckSecondDigitIsValid(Cpf cpf)
        {
            var result = CalculateBaseDigits(cpf, 1, 10) * 10 % 11;

            return result == cpf.GetSecondCheckupDigit()
                || result == 10;
        }

        private static double CalculateBaseDigits(Cpf cpf, int startPosition, int size)
        {
            var count = 10;

            double cpfValidationCalc = default;

            for (int i = startPosition; i < size; i++)
            {
                cpfValidationCalc += cpf.CpfArray[i] * count--;
            }

            return cpfValidationCalc;
        }
    }
}
