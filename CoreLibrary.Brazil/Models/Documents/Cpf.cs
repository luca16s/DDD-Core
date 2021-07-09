namespace CoreLibrary.Brazil.Models.Documents
{
    using System.Linq;

    using CoreLibrary.Brazil.Enums;
    using CoreLibrary.Utils.Extensions;

    public class Cpf
    {
        private readonly int[] FirstDigits;
        private readonly int[] IntermediateDigits;
        private readonly int[] LastDigits;
        private readonly int[] CheckupDigits;

        public readonly int[] CpfArray;

        public Cpf(int[] mainDigits, int[] intermediateDigits, int[] lastDigits, int[] checkupDigits)
        {
            FirstDigits = mainDigits;
            IntermediateDigits = intermediateDigits;
            LastDigits = lastDigits;
            CheckupDigits = checkupDigits;

            CpfArray = GetCpfArray();
        }

        private int[] GetCpfArray()
        {
            return FirstDigits.Concat(IntermediateDigits).Concat(LastDigits).Concat(CheckupDigits).ToArray();
        }

        public int GetFirstCheckupDigit()
        {
            return CheckupDigits[0];
        }

        public int GetSecondCheckupDigit()
        {
            return CheckupDigits[1];
        }

        public string GetCpfRegion()
        {
            return ((ERegions)LastDigits[0]).Description();
        }

        public override string ToString()
        {
            return $"{FirstDigits}.{IntermediateDigits}.{LastDigits}-{CheckupDigits}";
        }
    }
}
