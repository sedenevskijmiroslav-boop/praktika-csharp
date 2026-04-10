using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinanceApp2.Models;
using FinanceApp2.Data;

namespace FinanceApp2.Services
{
    public class ReminderService
    {
        private const string MemoryMappedName = "FinanceReminders";
        private const int BufferSize = 4096;

        private readonly ApplicationDbContext _context;
        private List<Reminder> _reminders;
        private int _currentUserId;

        public ReminderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void LoadReminders(int userId)
        {
            _currentUserId = userId;
            _reminders = _context.Reminders.Where(r => r.UserId == userId).ToList();
        }

        public async Task SaveRemindersAsync()
        {
            foreach (var reminder in _reminders)
            {
                if (reminder.Id == 0)
                    _context.Reminders.Add(reminder);
                else
                    _context.Reminders.Update(reminder);
            }
            await _context.SaveChangesAsync();
        }

        public List<Reminder> GetReminders()
        {
            return _reminders ?? new List<Reminder>();
        }

        public void AddReminder(Reminder reminder, int userId)
        {
            reminder.Id = _reminders.Count > 0 ? _reminders.Max(r => r.Id) + 1 : 1;
            reminder.UserId = userId;
            _reminders.Add(reminder);
            _context.Reminders.Add(reminder);
            _context.SaveChanges();
            SendReminderNotification(reminder);
        }

        public void DeleteReminder(int id, int userId)
        {
            var reminder = _reminders.FirstOrDefault(r => r.Id == id);
            if (reminder != null)
            {
                _reminders.Remove(reminder);
                _context.Reminders.Remove(reminder);
                _context.SaveChanges();
            }
        }

        public void MarkAsPaid(int id, int userId)
        {
            var reminder = _reminders.FirstOrDefault(r => r.Id == id);
            if (reminder != null)
            {
                reminder.IsPaid = true;
                _context.Reminders.Update(reminder);
                _context.SaveChanges();
            }
        }

        public List<Reminder> GetUpcomingReminders(int days = 7)
        {
            var today = DateTime.Today;
            var limit = today.AddDays(days);
            return _reminders.Where(r => !r.IsPaid && r.DueDate >= today && r.DueDate <= limit).ToList();
        }

        public void SendReminderNotification(Reminder reminder)
        {
            try
            {
                using (var mmf = MemoryMappedFile.CreateOrOpen(MemoryMappedName, BufferSize))
                {
                    using (var stream = mmf.CreateViewStream())
                    {
                        var message = $"[REMINDER] {reminder.Title} - {reminder.Amount:C} до {reminder.DueDate:dd.MM.yyyy}";
                        var bytes = Encoding.UTF8.GetBytes(message);
                        stream.Write(bytes, 0, Math.Min(bytes.Length, BufferSize));
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"MMF Error: {ex.Message}");
            }
        }

        public string ReadNotification()
        {
            try
            {
                using (var mmf = MemoryMappedFile.OpenExisting(MemoryMappedName))
                {
                    using (var stream = mmf.CreateViewStream())
                    {
                        var bytes = new byte[BufferSize];
                        var count = stream.Read(bytes, 0, BufferSize);
                        return Encoding.UTF8.GetString(bytes, 0, count);
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}