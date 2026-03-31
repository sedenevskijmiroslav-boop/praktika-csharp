using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Task1.Models;
using Task1;

namespace Task1.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Transaction> _incomes;
    private ObservableCollection<Transaction> _expenses;
    private decimal _balance;
    private SeriesCollection _expenseSeries;

    public MainViewModel()
    {
        _incomes = new ObservableCollection<Transaction>();
        _expenses = new ObservableCollection<Transaction>();

        AddIncomeCommand = new RelayCommand(AddIncome);
        AddExpenseCommand = new RelayCommand(AddExpense);

        LoadSampleData();
        UpdateBalance();
        UpdateExpenseChart();
    }

    public ObservableCollection<Transaction> Incomes
    {
        get => _incomes;
        set
        {
            _incomes = value;
            OnPropertyChanged(nameof(Incomes));
        }
    }

    public ObservableCollection<Transaction> Expenses
    {
        get => _expenses;
        set
        {
            _expenses = value;
            OnPropertyChanged(nameof(Expenses));
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

    public SeriesCollection ExpenseSeries
    {
        get => _expenseSeries;
        set
        {
            _expenseSeries = value;
            OnPropertyChanged(nameof(ExpenseSeries));
        }
    }

    public ICommand AddIncomeCommand { get; }
    public ICommand AddExpenseCommand { get; }

    private void AddIncome()
    {
        AddTransaction(TransactionType.Income);
    }

    private void AddExpense()
    {
        AddTransaction(TransactionType.Expense);
    }

    private void AddTransaction(TransactionType type)
    {
        var dialog = new AddTransactionWindow(type);
        if (dialog.ShowDialog() == true)
        {
            var transaction = new Transaction
            {
                Date = dialog.TransactionDate,
                Category = dialog.Category,
                Amount = dialog.Amount,
                Type = type
            };

            if (type == TransactionType.Income)
            {
                Incomes.Add(transaction);
            }
            else
            {
                Expenses.Add(transaction);
                UpdateExpenseChart();
            }

            UpdateBalance();
        }
    }

    private void UpdateBalance()
    {
        decimal totalIncome = 0;
        foreach (var inc in Incomes)
        {
            totalIncome += inc.Amount;
        }

        decimal totalExpense = 0;
        foreach (var exp in Expenses)
        {
            totalExpense += exp.Amount;
        }

        Balance = totalIncome - totalExpense;
    }

    private void UpdateExpenseChart()
    {
        var series = new SeriesCollection();

        var categories = Expenses.GroupBy(e => e.Category);

        foreach (var category in categories)
        {
            series.Add(new PieSeries
            {
                Title = category.Key,
                Values = new ChartValues<decimal> { category.Sum(x => x.Amount) },
                DataLabels = true
            });
        }

        ExpenseSeries = series;
    }

    private void LoadSampleData()
    {
        Incomes.Add(new Transaction { Date = DateTime.Now, Category = "Зарплата", Amount = 50000, Type = TransactionType.Income });
        Incomes.Add(new Transaction { Date = DateTime.Now.AddDays(-5), Category = "Фриланс", Amount = 10000, Type = TransactionType.Income });

        Expenses.Add(new Transaction { Date = DateTime.Now, Category = "Продукты", Amount = 5000, Type = TransactionType.Expense });
        Expenses.Add(new Transaction { Date = DateTime.Now.AddDays(-3), Category = "Транспорт", Amount = 1000, Type = TransactionType.Expense });
        Expenses.Add(new Transaction { Date = DateTime.Now.AddDays(-7), Category = "Кафе", Amount = 1500, Type = TransactionType.Expense });
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}