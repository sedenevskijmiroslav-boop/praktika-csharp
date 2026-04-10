using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FinanceApp2.Models;
using FinanceApp2.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp2.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;
        private User _currentUser;

        public User CurrentUser => _currentUser;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
            InitializeAsync().Wait();
        }

        private async Task InitializeAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!await _context.Users.AnyAsync())
            {
                await CreateDefaultAdmin();
            }
        }

        private async Task CreateDefaultAdmin()
        {
            _context.Users.Add(new User
            {
                Id = 1,
                Username = "admin",
                PasswordHash = HashPassword("admin123"),
                Role = "Admin",
                CreatedAt = DateTime.Now
            });

            _context.Users.Add(new User
            {
                Id = 2,
                Username = "user",
                PasswordHash = HashPassword("user123"),
                Role = "User",
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync();
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

        public async Task<bool> RegisterAsync(string username, string password, string role = "User")
        {
            if (await _context.Users.AnyAsync(u => u.Username == username))
                return false;

            var newId = await _context.Users.MaxAsync(u => (int?)u.Id) ?? 0;
            newId++;

            _context.Users.Add(new User
            {
                Id = newId,
                Username = username,
                PasswordHash = HashPassword(password),
                Role = role,
                CreatedAt = DateTime.Now
            });

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

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

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}