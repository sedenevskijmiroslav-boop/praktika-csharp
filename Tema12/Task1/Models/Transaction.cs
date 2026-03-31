using System;

namespace Task1.Models;

public class Transaction
{
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }
}

public enum TransactionType
{
    Income,
    Expense
}