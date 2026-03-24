using System;
using System.Linq;

namespace PasswordValidation
{
    public class PasswordManager
    {
        public void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new WeakPasswordException("Пароль не может быть пустым");
            }

            if (password.Length < 8)
            {
                throw new WeakPasswordException($"Пароль слишком короткий. Длина: {password.Length}. Требуется минимум 8 символов");
            }

            if (!password.Any(char.IsDigit))
            {
                throw new WeakPasswordException("Пароль должен содержать хотя бы одну цифру");
            }

            Console.WriteLine("Пароль надежный");
        }
    }
}