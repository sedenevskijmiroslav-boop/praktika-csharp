using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using FinanceApp2.Models;
using FinanceApp2.Services;
using FinanceApp2.ViewModels;

namespace FinanceApp2
{
    public partial class MainWindow : Window
    {
        private AuthService _authService;
        private DataService _dataService;
        private ReminderService _reminderService;
        private ChatService _chatService;
        private MainViewModel _viewModel;

        public MainWindow(AuthService authService)
        {
            InitializeComponent();

            _authService = authService;
            _dataService = new DataService();
            _reminderService = new ReminderService(_dataService);
            _chatService = new ChatService(_dataService);

            _viewModel = new MainViewModel(_dataService, _authService, _reminderService);
            DataContext = _viewModel;

            Title = $"Учет финансов - {_authService.CurrentUser?.Username} ({_authService.CurrentUser?.Role})";

            LoadUserData();
            StartChatServer();
            LoadReminders();
            LoadChatHistory();
        }

        private void LoadUserData()
        {
            var userId = _authService.CurrentUser.Id;
            _viewModel.LoadUserData(userId);
        }

        private async void StartChatServer()
        {
            _chatService.MessageReceived += OnMessageReceived;
            await _chatService.StartServerAsync();
        }

        private void OnMessageReceived(Message message)
        {
            Dispatcher.Invoke(() =>
            {
                ChatListBox.Items.Add(message);
                ChatListBox.ScrollIntoView(ChatListBox.Items[ChatListBox.Items.Count - 1]);
            });
        }

        private void LoadChatHistory()
        {
            var messages = _chatService.GetMessagesForUser(_authService.CurrentUser.Username);
            ChatListBox.Items.Clear();
            foreach (var msg in messages)
            {
                ChatListBox.Items.Add(msg);
            }
        }

        private void LoadReminders()
        {
            _reminderService.LoadReminders(_authService.CurrentUser.Id);
            ReminderListBox.ItemsSource = _reminderService.GetReminders();
        }

        private async void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            var text = ChatMessageBox.Text;
            if (string.IsNullOrEmpty(text)) return;

            var success = await _chatService.SendMessageAsync(
                _authService.CurrentUser.Username,
                "all",
                text
            );

            if (success)
            {
                ChatMessageBox.Clear();
            }
        }

        private void AddReminder_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ReminderTitleBox.Text) ||
                string.IsNullOrEmpty(ReminderAmountBox.Text))
            {
                MessageBox.Show("Заполните название и сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!decimal.TryParse(ReminderAmountBox.Text, out decimal amount))
            {
                MessageBox.Show("Введите корректную сумму", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var reminder = new Reminder
            {
                Title = ReminderTitleBox.Text,
                Amount = amount,
                DueDate = ReminderDatePicker.SelectedDate ?? DateTime.Now.AddDays(7),
                IsPaid = false
            };

            _reminderService.AddReminder(reminder, _authService.CurrentUser.Id);
            ReminderListBox.ItemsSource = null;
            ReminderListBox.ItemsSource = _reminderService.GetReminders();

            ReminderTitleBox.Clear();
            ReminderAmountBox.Clear();
            ReminderDatePicker.SelectedDate = null;
        }

        private void MarkReminderPaid_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var reminder = button?.Tag as Reminder;

            if (reminder != null)
            {
                _reminderService.MarkAsPaid(reminder.Id, _authService.CurrentUser.Id);
                ReminderListBox.ItemsSource = null;
                ReminderListBox.ItemsSource = _reminderService.GetReminders();
            }
        }

        private void DeleteReminder_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var reminder = button?.Tag as Reminder;

            if (reminder != null)
            {
                _reminderService.DeleteReminder(reminder.Id, _authService.CurrentUser.Id);
                ReminderListBox.ItemsSource = null;
                ReminderListBox.ItemsSource = _reminderService.GetReminders();
            }
        }

        private void ToggleChat_Click(object sender, RoutedEventArgs e)
        {
            if (ChatPanel.Visibility == Visibility.Visible)
            {
                ChatPanel.Visibility = Visibility.Collapsed;
                BtnShowChat.Background = System.Windows.Media.Brushes.LightGray;
                BtnShowChat.Foreground = System.Windows.Media.Brushes.Black;
            }
            else
            {
                ChatPanel.Visibility = Visibility.Visible;
                RemindersPanel.Visibility = Visibility.Collapsed;
                BtnShowChat.Background = System.Windows.Media.Brushes.Green;
                BtnShowChat.Foreground = System.Windows.Media.Brushes.White;
                BtnShowReminders.Background = System.Windows.Media.Brushes.LightGray;
                BtnShowReminders.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void ToggleReminders_Click(object sender, RoutedEventArgs e)
        {
            if (RemindersPanel.Visibility == Visibility.Visible)
            {
                RemindersPanel.Visibility = Visibility.Collapsed;
                BtnShowReminders.Background = System.Windows.Media.Brushes.LightGray;
                BtnShowReminders.Foreground = System.Windows.Media.Brushes.Black;
            }
            else
            {
                RemindersPanel.Visibility = Visibility.Visible;
                ChatPanel.Visibility = Visibility.Collapsed;
                BtnShowReminders.Background = System.Windows.Media.Brushes.Green;
                BtnShowReminders.Foreground = System.Windows.Media.Brushes.White;
                BtnShowChat.Background = System.Windows.Media.Brushes.LightGray;
                BtnShowChat.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e) => Close();

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            var transactions = _viewModel.GetAllTransactions();
            decimal income = transactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
            decimal expense = transactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);
            decimal total = income - expense;

            MessageBox.Show($"Общий отчет\n\nДоходы: {income:C}\nРасходы: {expense:C}\nБаланс: {total:C}",
                "Отчет", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Учет финансов\nВерсия 3.0\n\nПрограмма для учета доходов и расходов\n\nГорячие клавиши:\nCtrl+N - Добавить\nCtrl+E - Редактировать\nDel - Удалить\n\nРоли: Admin, User",
                "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            _viewModel.SaveData();
            base.OnClosing(e);
        }
    }
}