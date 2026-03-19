using System;
using System.Collections.Generic;

namespace ClientsOfBank;
class Bank
{
    public BankClient[] Clients { get; set; }

    public Bank(BankClient[] clients)
    {
        Clients = clients;
    }

    public BankClient[] GetClientsWithLowBalance(decimal minBalance)
    {
        List<BankClient> result = new List<BankClient>();

        foreach (BankClient client in Clients)
        {
            if (client.AccountBalance < minBalance)
            {
                result.Add(client);
            }
        }

        return result.ToArray();
    }

    public BankClient GetRichestClient()
    {
        BankClient richest = Clients[0];

        foreach (BankClient client in Clients)
        {
            if (client.AccountBalance > richest.AccountBalance)
            {
                richest = client;
            }
        }

        return richest;
    }
}