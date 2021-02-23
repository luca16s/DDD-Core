using System;

namespace DeadFishStudio.CoreLibrary.Exceptions
{
    public class EnumItemNotFoundException : Exception
    {
        private const string DefaultMessage = "Item não encontrado no enumerador.";

        public EnumItemNotFoundException()
            : base(DefaultMessage) { }

        public EnumItemNotFoundException(string message)
            : base($"{DefaultMessage}{Environment.NewLine} - {message}") { }

        public EnumItemNotFoundException(string message, Exception inner)
            : base(message, inner) { }
    }
}
