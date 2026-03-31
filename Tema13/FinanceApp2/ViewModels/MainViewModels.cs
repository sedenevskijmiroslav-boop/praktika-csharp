using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using FinanceApp2.Models;

namespace FinanceApp2.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<Transaction> Transactions { get; set; }
        public Transaction SelectedTransaction { get; set; }

        public ICommand AddTransactionCommand { get; set; }
        public ICommand EditTransactionCommand { get; set; }
        public ICommand DeleteTransactionCommand { get; set; }

        private int _nextId = 1;

        public MainViewModel()
        {
            Transactions = new ObservableCollection<Transaction>();

            AddTransactionCommand = new RelayCommand(ExecuteAdd);
            EditTransactionCommand = new RelayCommand(ExecuteEdit, CanExecuteEditDelete);
            DeleteTransactionCommand = new RelayCommand(ExecuteDelete, CanExecuteEditDelete);

            Transactions.Add(new Transaction
            {
                Id = _nextId++,
                Amount = 50000,
                Type = "Доход",
                Date = DateTime.Now,
                Description = "Зарплата"
            });

            Transactions.Add(new Transaction
            {
                Id = _nextId++,
                Amount = 3000,
                Type = "Расход",
                Date = DateTime.Now,
                Description = "Продукты"
            });
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
                var newTransaction = new Transaction
                {
                    Id = _nextId++,
                    Amount = dialog.Amount,
                    Type = dialog.Type,
                    Date = dialog.Date,
                    Description = dialog.Description
                };

                Transactions.Add(newTransaction);
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

                int index = Transactions.IndexOf(SelectedTransaction);
                Transactions[index] = SelectedTransaction;
            }
        }

        private void ExecuteDelete(object parameter)
        {
            if (SelectedTransaction == null) return;

            var result = MessageBox.Show(
                $"Удалить транзакцию?\n\nДата: {SelectedTransaction.Date:dd.MM.yyyy}\nТип: {SelectedTransaction.Type}\nСумма: {SelectedTransaction.Amount:C}",
                "Подтверждение удаления",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Transactions.Remove(SelectedTransaction);
            }
        }
    }
}