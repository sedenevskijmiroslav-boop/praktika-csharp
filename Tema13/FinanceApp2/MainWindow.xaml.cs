using System;
using System.Linq;
using System.Windows;
using FinanceApp2.ViewModels;

namespace FinanceApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null && vm.Transactions.Count > 0)
            {
                decimal total = vm.Transactions.Sum(t => t.Type == "Доход" ? t.Amount : -t.Amount);
                decimal income = vm.Transactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
                decimal expense = vm.Transactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);

                MessageBox.Show($"Общий отчет\n\nДоходы: {income:C}\nРасходы: {expense:C}\nИтого: {total:C}",
                    "Отчет", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Нет данных для отчета", "Отчет", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ReportByType_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MainViewModel;
            if (vm != null)
            {
                var income = vm.Transactions.Where(t => t.Type == "Доход").Sum(t => t.Amount);
                var expense = vm.Transactions.Where(t => t.Type == "Расход").Sum(t => t.Amount);

                MessageBox.Show($"Отчет по типам\n\nДоходы: {income:C}\nРасходы: {expense:C}",
                    "Отчет", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Учет финансов\nВерсия 1.0\n\nПрограмма для учета доходов и расходов\n\nГорячие клавиши:\nCtrl+N - Добавить\nCtrl+E - Редактировать\nDel - Удалить",
                "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}