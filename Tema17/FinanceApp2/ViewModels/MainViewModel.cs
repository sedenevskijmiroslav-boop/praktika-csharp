using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using FinanceApp2.Models;
using FinanceApp2.Services;
using LiveCharts;
using LiveCharts.Wpf;

namespace FinanceApp2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FinanceService _financeService;
        private readonly DataService _dataService;
        private readonly AuthService _authService;
        private readonly ReminderService _reminderService;

        private ObservableCollection<Transaction> _allTransactions;
        private ObservableCollection<Transaction> _filteredTransactions;
        private DateTime? _filterDate;
        private Transaction _selectedTransaction;
        private decimal _balance;
        private bool _isLoading;
        private string _loadingMessage;
        private int _currentUserId;
        private DateTime _selectedMonth;
        private decimal _budgetLimit;
        private SolidColorBrush _backgroundBrush;

        private SeriesCollection _incomeChartSeries;
        private SeriesCollection _expenseChartSeries;
        private string[] _monthLabels;

        public ObservableCollection<Transaction> Transactions
        {
            get => _filteredTransactions;
            set
            {
                _filteredTransactions = value;
                OnPropertyChanged(nameof(Transactions));
            }
        }

        public Transaction SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                _selectedTransaction = value;
                OnPropertyChanged(nameof(SelectedTransaction));
                ((RelayCommand)EditTransactionCommand)?.RaiseCanExecuteChanged();
                ((RelayCommand)DeleteTransactionCommand)?.RaiseCanExecuteChanged();
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
                CheckBudgetLimit();
            }
        }

        public DateTime? FilterDate
        {
            get => _filterDate;
            set
            {
                _filterDate = value;
                OnPropertyChanged(nameof(FilterDate));
                ApplyFilter();
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public string LoadingMessage
        {
            get => _loadingMessage;
            set
            {
                _loadingMessage = value;
                OnPropertyChanged(nameof(LoadingMessage));
            }
        }

        public DateTime SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = value;
                OnPropertyChanged(nameof(SelectedMonth));
                UpdateCharts();
            }
        }

        public decimal BudgetLimit
        {
            get => _budgetLimit;
            set
            {
                _budgetLimit = value;
                OnPropertyChanged(nameof(BudgetLimit));
                CheckBudgetLimit();
            }
        }

        public SolidColorBrush BackgroundBrush
        {
            get => _backgroundBrush;
            set
            {
                _backgroundBrush = value;
                OnPropertyChanged(nameof(BackgroundBrush));
            }
        }

        public SeriesCollection IncomeChartSeries
        {
            get => _incomeChartSeries;
            set
            {
                _incomeChartSeries = value;
                OnPropertyChanged(nameof(IncomeChartSeries));
            }
        }

        public SeriesCollection ExpenseChartSeries
        {
            get => _expenseChartSeries;
            set
            {
                _expenseChartSeries = value;
                OnPropertyChanged(nameof(ExpenseChartSeries));
            }
        }

        public string[] MonthLabels
        {
            get => _monthLabels;
            set
            {
                _monthLabels = value;
                OnPropertyChanged(nameof(MonthLabels));
            }
        }

        public ICommand AddTransactionCommand { get; }
        public ICommand EditTransactionCommand { get; }
        public ICommand DeleteTransactionCommand { get; }
        public ICommand ClearFilterCommand { get; }
        public ICommand LoadDataCommand { get; }
        public ICommand PreviousMonthCommand { get; }
        public ICommand NextMonthCommand { get; }

        private int _nextId = 3;

        public MainViewModel(DataService dataService, AuthService authService, ReminderService reminderService)
        {
            _financeService = new FinanceService();
            _dataService = dataService;
            _authService = authService;
            _reminderService = reminderService;

            _allTransactions = new ObservableCollection<Transaction>();
            _filteredTransactions = new ObservableCollection<Transaction>();

            _selectedMonth = DateTime.Now;
            _budgetLimit = 50000;
            _backgroundBrush = new SolidColorBrush(Colors.White);

            IncomeChartSeries = new SeriesCollection();
            ExpenseChartSeries = new SeriesCollection();
            MonthLabels = new string[] { "Янв", "Фев", "Мар", "Апр", "Май", "Июн", "Июл", "Авг", "Сен", "Окт", "Ноя", "Дек" };

            AddTransactionCommand = new RelayCommand(ExecuteAdd);
            EditTransactionCommand = new RelayCommand(ExecuteEdit, CanExecuteEditDelete);
            DeleteTransactionCommand = new RelayCommand(ExecuteDelete, CanExecuteEditDelete);
            ClearFilterCommand = new RelayCommand(ExecuteClearFilter);
            LoadDataCommand = new RelayCommand(async _ => await LoadDataAsync());
            PreviousMonthCommand = new RelayCommand(_ => PreviousMonth());
            NextMonthCommand = new RelayCommand(_ => NextMonth());
        }

        private void PreviousMonth()
        {
            SelectedMonth = SelectedMonth.AddMonths(-1);
        }

        private void NextMonth()
        {
            SelectedMonth = SelectedMonth.AddMonths(1);
        }

        private void UpdateCharts()
        {
            var startDate = new DateTime(SelectedMonth.Year, SelectedMonth.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var monthTransactions = _allTransactions.Where(t => t.Date >= startDate && t.Date <= endDate).ToList();

            var dailyIncome = new ChartValues<decimal>();
            var dailyExpense = new ChartValues<decimal>();

            for (int day = 1; day <= DateTime.DaysInMonth(SelectedMonth.Year, SelectedMonth.Month); day++)
            {
                var dayDate = new DateTime(SelectedMonth.Year, SelectedMonth.Month, day);
                var dayIncome = monthTransactions.Where(t => t.Type == "Доход" && t.Date.Date == dayDate).Sum(t => t.Amount);
                var dayExpense = monthTransactions.Where(t => t.Type == "Расход" && t.Date.Date == dayDate).Sum(t => t.Amount);

                dailyIncome.Add(dayIncome);
                dailyExpense.Add(dayExpense);
            }

            IncomeChartSeries.Clear();
            ExpenseChartSeries.Clear();

            IncomeChartSeries.Add(new ColumnSeries
            {
                Title = "Доходы",
                Values = dailyIncome,
                Fill = System.Windows.Media.Brushes.Green,
                DataLabels = true
            });

            ExpenseChartSeries.Add(new ColumnSeries
            {
                Title = "Расходы",
                Values = dailyExpense,
                Fill = System.Windows.Media.Brushes.Red,
                DataLabels = true
            });
        }

        private void CheckBudgetLimit()
        {
            var startDate = new DateTime(SelectedMonth.Year, SelectedMonth.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            var monthExpenses = _allTransactions
                .Where(t => t.Type == "Расход" && t.Date >= startDate && t.Date <= endDate)
                .Sum(t => t.Amount);

            if (monthExpenses > BudgetLimit)
            {
                var animation = new System.Windows.Media.Animation.ColorAnimation
                {
                    From = Colors.White,
                    To = Colors.Red,
                    Duration = TimeSpan.FromSeconds(0.5),
                    AutoReverse = true,
                    RepeatBehavior = new System.Windows.Media.Animation.RepeatBehavior(3)
                };

                if (Application.Current.MainWindow != null)
                {
                    var brush = new SolidColorBrush(Colors.White);
                    brush.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                    BackgroundBrush = brush;
                }
            }
            else
            {
                BackgroundBrush = new SolidColorBrush(Colors.White);
            }
        }

        public void LoadUserData(int userId)
        {
            _currentUserId = userId;
            var savedTransactions = _dataService.LoadTransactions(userId);

            if (savedTransactions.Any())
            {
                _allTransactions.Clear();
                foreach (var t in savedTransactions)
                {
                    _allTransactions.Add(t);
                    if (t.Id >= _nextId) _nextId = t.Id + 1;
                }
                ApplyFilter();
                UpdateBalance();
                UpdateCharts();
            }
            else
            {
                LoadDataCommand.Execute(null);
            }
        }

        public void SaveData()
        {
            _dataService.SaveTransactions(_allTransactions.ToList(), _currentUserId);
        }

        public System.Collections.Generic.List<Transaction> GetAllTransactions()
        {
            return _allTransactions.ToList();
        }

        private async Task LoadDataAsync()
        {
            IsLoading = true;
            LoadingMessage = "Загрузка данных из API...";

            var transactions = await _financeService.LoadTransactionsAsync();

            _allTransactions.Clear();
            foreach (var t in transactions)
            {
                _allTransactions.Add(t);
                if (t.Id >= _nextId) _nextId = t.Id + 1;
            }

            ApplyFilter();
            UpdateBalance();
            UpdateCharts();

            LoadingMessage = "Данные загружены!";
            await Task.Delay(500);
            IsLoading = false;

            SaveData();
        }

        private bool CanExecuteEditDelete(object parameter)
        {
            return SelectedTransaction != null;
        }

        private void ExecuteAdd(object parameter)
        {
            var dialog = new TransactionDialog();
            dialog.Owner = Application.Current.MainWindow;

            if (dialog.ShowDialog() == true)
            {
                var transaction = new Transaction
                {
                    Id = _nextId++,
                    Amount = dialog.Amount,
                    Type = dialog.Type,
                    Date = dialog.Date,
                    Description = dialog.Description
                };

                _allTransactions.Add(transaction);
                ApplyFilter();
                UpdateBalance();
                UpdateCharts();
                SaveData();
            }
        }

        private void ExecuteEdit(object parameter)
        {
            if (SelectedTransaction == null) return;

            var dialog = new TransactionDialog(SelectedTransaction);
            dialog.Owner = Application.Current.MainWindow;

            if (dialog.ShowDialog() == true)
            {
                SelectedTransaction.Amount = dialog.Amount;
                SelectedTransaction.Type = dialog.Type;
                SelectedTransaction.Date = dialog.Date;
                SelectedTransaction.Description = dialog.Description;

                int index = _allTransactions.IndexOf(SelectedTransaction);
                if (index >= 0)
                {
                    _allTransactions[index] = SelectedTransaction;
                }

                ApplyFilter();
                UpdateBalance();
                UpdateCharts();
                SaveData();
            }
        }

        private void ExecuteDelete(object parameter)
        {
            if (SelectedTransaction == null) return;

            var result = MessageBox.Show(
                $"Удалить транзакцию?\n\n{SelectedTransaction.Date:dd.MM.yyyy} - {SelectedTransaction.Type} - {SelectedTransaction.Amount:C}",
                "Подтверждение",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                _allTransactions.Remove(SelectedTransaction);
                ApplyFilter();
                UpdateBalance();
                UpdateCharts();
                SaveData();
            }
        }

        private void ExecuteClearFilter(object parameter)
        {
            FilterDate = null;
        }

        private void ApplyFilter()
        {
            Transactions.Clear();

            var filtered = _financeService.FilterByDate(_allTransactions.ToList(), FilterDate);

            foreach (var transaction in filtered)
            {
                Transactions.Add(transaction);
            }
        }

        private void UpdateBalance()
        {
            Balance = _financeService.CalculateBalance(_allTransactions.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}