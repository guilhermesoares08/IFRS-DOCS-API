using System;

namespace IfrsDocs.Domain.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"O e-mail '{email}' é inválido.")
        {
        }
    }

}
