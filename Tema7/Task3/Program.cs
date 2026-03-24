using System;

namespace PasswordValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordManager manager = new PasswordManager();

            Console.WriteLine("Проверка: 'pass'");
            try
            {
                manager.ValidatePassword("pass");
            }
            catch (WeakPasswordException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }

            Console.WriteLine("Проверка: 'password123'");
            try
            {
                manager.ValidatePassword("password");
            }
            catch (WeakPasswordException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}\n");
            }

            Console.WriteLine("Проверка: 'strong123'");
            try
            {
                manager.ValidatePassword("strong123");
            }
            catch (WeakPasswordException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}