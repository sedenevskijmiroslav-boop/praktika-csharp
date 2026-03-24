using System;

namespace PasswordValidation
{
    public class WeakPasswordException : Exception
    {
        public WeakPasswordException() : base("Пароль слишком слабый")
        {
        }

        public WeakPasswordException(string message) : base(message)
        {
        }
    }
}