using System;

namespace ClientsOfBank;
partial class BankClient
{
    public BankClient(string name, decimal accountBalance)
    {
        Name = name;
        AccountBalance = accountBalance;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Клиент: {Name}, Баланс: {AccountBalance} рублей");
    }
}