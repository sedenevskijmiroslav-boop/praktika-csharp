using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using FinanceApp2.Models;

namespace FinanceApp2.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Transaction> _allTransactions;
    private ObservableCollection<Transaction> _filteredTransactions;
    private DateTime? _filterDate;
    private Transaction _selectedTransaction;
    private decimal _balance;

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

    public ICommand AddTransactionCommand { get; }
    public ICommand EditTransactionCommand { get; }
    public ICommand DeleteTransactionCommand { get; }
    public ICommand ClearFilterCommand { get; }

    private int _nextId = 3;

    public MainViewModel()
    {
        _allTransactions = new ObservableCollection<Transaction>();
        _filteredTransactions = new ObservableCollection<Transaction>();

        _allTransactions.Add(new Transaction { Id = 1, Amount = 50000, Type = "Доход", Date = DateTime.Now, Description = "Зарплата" });
        _allTransactions.Add(new Transaction { Id = 2, Amount = 3000, Type = "Расход", Date = DateTime.Now, Description = "Продукты" });

        ApplyFilter();
        UpdateBalance();

        AddTransactionCommand = new RelayCommand(ExecuteAdd);
        EditTransactionCommand = new RelayCommand(ExecuteEdit, CanExecuteEditDelete);
        DeleteTransactionCommand = new RelayCommand(ExecuteDelete, CanExecuteEditDelete);
        ClearFilterCommand = new RelayCommand(ExecuteClearFilter);
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
        }
    }

    private void ExecuteClearFilter(object parameter)
    {
        FilterDate = null;
    }

    private void ApplyFilter()
    {
        Transactions.Clear();

        var filtered = _allTransactions.Where(t => !FilterDate.HasValue || t.Date.Date == FilterDate.Value.Date);

        foreach (var transaction in filtered)
        {
            Transactions.Add(transaction);
        }
    }

    private void UpdateBalance()
    {
        decimal income = _allTransactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
        decimal expense = _allTransactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);
        Balance = income - expense;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}