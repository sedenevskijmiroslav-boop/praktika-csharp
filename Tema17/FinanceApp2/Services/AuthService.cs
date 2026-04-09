using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using FinanceApp2.Models;

namespace FinanceApp2.Services
{
    public class AuthService
    {
        private readonly DataService _dataService;
        private List<User> _users;
        private User _currentUser;

        public User CurrentUser => _currentUser;

        public AuthService(DataService dataService)
        {
            _dataService = dataService;
            _users = _dataService.LoadUsers();

            if (!_users.Any())
            {
                CreateDefaultAdmin();
            }
        }

        private void CreateDefaultAdmin()
        {
            _users.Add(new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = HashPassword("admin123"),
                Role = "Admin",
                CreatedAt = DateTime.Now
            });

            _users.Add(new User
            {
                Id = 2,
                Username = "user",
                PasswordHash = HashPassword("user123"),
                Role = "User",
                CreatedAt = DateTime.Now
            });

            _dataService.SaveUsers(_users);
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        public bool Register(string username, string password, string role = "User")
        {
            if (_users.Any(u => u.Username == username))
                return false;

            var newId = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;

            _users.Add(new User
            {
                Id = newId,
                Username = username,
                PasswordHash = HashPassword(password),
                Role = role,
                CreatedAt = DateTime.Now
            });

            _dataService.SaveUsers(_users);
            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);

            if (user == null)
                return false;

            if (user.PasswordHash == HashPassword(password))
            {
                _currentUser = user;
                return true;
            }

            return false;
        }

        public void Logout()
        {
            _currentUser = null;
        }

        public bool IsAdmin()
        {
            return _currentUser != null && _currentUser.Role == "Admin";
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
    }
}