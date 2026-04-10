using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using FinanceApp2.Models;

namespace FinanceApp2.Services
{
    public class DataService
    {
        private readonly string _dataPath;
        private readonly string _usersPath;
        private readonly string _remindersPath;
        private readonly string _messagesPath;

        public DataService()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var appFolder = Path.Combine(appData, "FinanceApp2");

            if (!Directory.Exists(appFolder))
                Directory.CreateDirectory(appFolder);

            _dataPath = Path.Combine(appFolder, "finance.json");
            _usersPath = Path.Combine(appFolder, "users.json");
            _remindersPath = Path.Combine(appFolder, "reminders.json");
            _messagesPath = Path.Combine(appFolder, "messages.json");
        }

        public void SaveTransactions(List<Transaction> transactions, int userId)
        {
            var allData = LoadAllTransactions();
            allData[userId] = transactions;
            var json = JsonConvert.SerializeObject(allData, Formatting.Indented);
            File.WriteAllText(_dataPath, json);
        }

        public List<Transaction> LoadTransactions(int userId)
        {
            var allData = LoadAllTransactions();
            return allData.ContainsKey(userId) ? allData[userId] : new List<Transaction>();
        }

        private Dictionary<int, List<Transaction>> LoadAllTransactions()
        {
            if (!File.Exists(_dataPath))
                return new Dictionary<int, List<Transaction>>();

            var json = File.ReadAllText(_dataPath);
            return JsonConvert.DeserializeObject<Dictionary<int, List<Transaction>>>(json) ?? new Dictionary<int, List<Transaction>>();
        }

        public void SaveUsers(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_usersPath, json);
        }

        public List<User> LoadUsers()
        {
            if (!File.Exists(_usersPath))
                return new List<User>();

            var json = File.ReadAllText(_usersPath);
            return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
        }

        public void SaveReminders(List<Reminder> reminders, int userId)
        {
            var allReminders = LoadAllReminders();
            allReminders[userId] = reminders;
            var json = JsonConvert.SerializeObject(allReminders, Formatting.Indented);
            File.WriteAllText(_remindersPath, json);
        }

        public List<Reminder> LoadReminders(int userId)
        {
            var allReminders = LoadAllReminders();
            return allReminders.ContainsKey(userId) ? allReminders[userId] : new List<Reminder>();
        }

        private Dictionary<int, List<Reminder>> LoadAllReminders()
        {
            if (!File.Exists(_remindersPath))
                return new Dictionary<int, List<Reminder>>();

            var json = File.ReadAllText(_remindersPath);
            return JsonConvert.DeserializeObject<Dictionary<int, List<Reminder>>>(json) ?? new Dictionary<int, List<Reminder>>();
        }

        public void SaveMessages(List<Message> messages)
        {
            var json = JsonConvert.SerializeObject(messages, Formatting.Indented);
            File.WriteAllText(_messagesPath, json);
        }

        public List<Message> LoadMessages()
        {
            if (!File.Exists(_messagesPath))
                return new List<Message>();

            var json = File.ReadAllText(_messagesPath);
            return JsonConvert.DeserializeObject<List<Message>>(json) ?? new List<Message>();
        }
    }
}