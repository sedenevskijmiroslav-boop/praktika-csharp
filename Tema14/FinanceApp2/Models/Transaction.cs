namespace FinanceApp2.Models;

public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}