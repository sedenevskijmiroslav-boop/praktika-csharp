using System;
using System.Linq;
using System.Windows;
using FinanceApp2.ViewModels;

namespace FinanceApp2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Exit_Click(object sender, RoutedEventArgs e) => Close();

    private void Report_Click(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as MainViewModel;
        if (vm != null)
        {
            decimal income = vm.Transactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
            decimal expense = vm.Transactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);
            decimal total = income - expense;

            MessageBox.Show($"Общий отчет\n\nДоходы: {income:C}\nРасходы: {expense:C}\nБаланс: {total:C}",
                "Отчет", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }

    private void About_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Учет финансов\nВерсия 2.0\n\nПрограмма для учета доходов и расходов\n\nГорячие клавиши:\nCtrl+N - Добавить\nCtrl+E - Редактировать\nDel - Удалить",
            "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}