using System;

namespace ClientsOfBank;
class Program
{
    static void Main()
    {
        BankClient[] clients = new BankClient[]
        {
            new BankClient("Швед Руслан", 15000),
            new BankClient("Мосевич Артур", 5000),
            new BankClient("Петров Егор", 25000),
            new BankClient("Августинович Александр", 8000),
            new BankClient("Багдюн Олег", 12000)
        };

        Bank bank = new Bank(clients);

        Console.WriteLine("Все клиенты банка:");
        foreach (BankClient client in clients)
        {
            client.ShowInfo();
        }

        Console.WriteLine("\nКлиенты с балансом ниже 10000 рублей");
        BankClient[] lowBalanceClients = bank.GetClientsWithLowBalance(10000);

        if (lowBalanceClients.Length > 0)
        {
            foreach (BankClient client in lowBalanceClients)
            {
                Console.WriteLine($"{client.Name} - {client.AccountBalance} рублей");
            }
        }
        else
        {
            Console.WriteLine("Таких клиентов нет");
        }

        Console.WriteLine("\nСамый богатый клиент");
        BankClient richest = bank.GetRichestClient();
        Console.WriteLine($"{richest.Name} - {richest.AccountBalance} рублей");
    }
}