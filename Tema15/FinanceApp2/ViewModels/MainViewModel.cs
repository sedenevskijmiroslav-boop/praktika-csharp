using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using FinanceApp2.Models;
using FinanceApp2.Services;
using LiveCharts;
using LiveCharts.Wpf;

namespace FinanceApp2.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FinanceService _financeService;
        private ObservableCollection<Transaction> _allTransactions;
        private ObservableCollection<Transaction> _filteredTransactions;
        private DateTime? _filterDate;
        private Transaction _selectedTransaction;
        private decimal _balance;
        private bool _isLoading;
        private string _loadingMessage;
        private SeriesCollection _chartSeries;

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
                ((RelayCommand)EditTransactionCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DeleteTransactionCommand).RaiseCanExecuteChanged();
            }
        }

        public decimal Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
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

        public SeriesCollection ChartSeries
        {
            get => _chartSeries;
            set
            {
                _chartSeries = value;
                OnPropertyChanged(nameof(ChartSeries));
            }
        }

        public ICommand AddTransactionCommand { get; }
        public ICommand EditTransactionCommand { get; }
        public ICommand DeleteTransactionCommand { get; }
        public ICommand ClearFilterCommand { get; }
        public ICommand LoadDataCommand { get; }

        private int _nextId = 3;

        public MainViewModel()
        {
            _financeService = new FinanceService();
            _allTransactions = new ObservableCollection<Transaction>();
            _filteredTransactions = new ObservableCollection<Transaction>();
            ChartSeries = new SeriesCollection();

            AddTransactionCommand = new RelayCommand(ExecuteAdd);
            EditTransactionCommand = new RelayCommand(ExecuteEdit, CanExecuteEditDelete);
            DeleteTransactionCommand = new RelayCommand(ExecuteDelete, CanExecuteEditDelete);
            ClearFilterCommand = new RelayCommand(ExecuteClearFilter);
            LoadDataCommand = new RelayCommand(async _ => await LoadDataAsync());

            LoadDataCommand.Execute(null);
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
            UpdateChart();

            LoadingMessage = "Данные загружены!";
            await Task.Delay(500);
            IsLoading = false;
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
                UpdateChart();
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
                UpdateChart();
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
                UpdateChart();
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

            UpdateChart();
        }

        private void UpdateBalance()
        {
            Balance = _financeService.CalculateBalance(_allTransactions.ToList());
        }

        private void UpdateChart()
        {
            var expensesByCategory = _financeService.GetExpensesByCategory(Transactions.ToList());

            ChartSeries.Clear();

            if (expensesByCategory.Count > 0)
            {
                var columnSeries = new ColumnSeries
                {
                    Title = "Расходы по категориям",
                    Values = new ChartValues<decimal>()
                };

                foreach (var cat in expensesByCategory)
                {
                    columnSeries.Values.Add(cat.TotalAmount);
                }

                ChartSeries.Add(columnSeries);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}