using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanceApp2.Models;

namespace FinanceApp2.Data
{
    public class TransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetTransactionsAsync(int userId)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.Date)
                .ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int id, int userId)
        {
            return await _context.Transactions
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetBalanceAsync(int userId)
        {
            var transactions = await GetTransactionsAsync(userId);
            decimal income = transactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
            decimal expense = transactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);
            return income - expense;
        }
    }
}