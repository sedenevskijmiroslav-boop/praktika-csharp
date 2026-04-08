using System;

namespace FinanceApp2.Models
{
    public class Reminder
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsPaid { get; set; }
        public int UserId { get; set; }
    }
}