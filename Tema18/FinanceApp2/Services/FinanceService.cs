using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinanceApp2.Models;

namespace FinanceApp2.Services
{
    public class FinanceService
    {
        public async Task<List<Transaction>> LoadTransactionsAsync()
        {
            await Task.Delay(3000);

            return new List<Transaction>
            {
                new Transaction { Id = 1, Amount = 50000, Type = "Доход", Date = DateTime.Now.AddDays(-10), Description = "Зарплата" },
                new Transaction { Id = 2, Amount = 3000, Type = "Расход", Date = DateTime.Now.AddDays(-8), Description = "Продукты" },
                new Transaction { Id = 3, Amount = 1500, Type = "Расход", Date = DateTime.Now.AddDays(-5), Description = "Кафе" },
                new Transaction { Id = 4, Amount = 20000, Type = "Доход", Date = DateTime.Now.AddDays(-3), Description = "Фриланс" },
                new Transaction { Id = 5, Amount = 800, Type = "Расход", Date = DateTime.Now.AddDays(-2), Description = "Такси" },
                new Transaction { Id = 6, Amount = 2000, Type = "Расход", Date = DateTime.Now.AddDays(-1), Description = "Ресторан" }
            };
        }

        public decimal CalculateBalance(List<Transaction> transactions)
        {
            decimal income = transactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
            decimal expense = transactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);
            return income - expense;
        }

        public List<Transaction> FilterByDate(List<Transaction> transactions, DateTime? date)
        {
            if (!date.HasValue) return transactions;
            return transactions.Where(t => t.Date.Date == date.Value.Date).ToList();
        }

        public List<CategoryModel> GetExpensesByCategory(List<Transaction> transactions)
        {
            var expenses = transactions.Where(t => t.Type == "Расход").ToList();

            var categoryMapping = new Dictionary<string, decimal>();

            foreach (var t in expenses)
            {
                string category = GetCategoryFromDescription(t.Description);
                if (categoryMapping.ContainsKey(category))
                    categoryMapping[category] += t.Amount;
                else
                    categoryMapping[category] = t.Amount;
            }

            return categoryMapping.Select(kv => new CategoryModel { Name = kv.Key, TotalAmount = kv.Value }).ToList();
        }

        private string GetCategoryFromDescription(string description)
        {
            if (description.Contains("Продукты") || description.Contains("Кафе") || description.Contains("Ресторан"))
                return "Еда";
            if (description.Contains("Такси"))
                return "Транспорт";
            return "Другое";
        }
    }
}