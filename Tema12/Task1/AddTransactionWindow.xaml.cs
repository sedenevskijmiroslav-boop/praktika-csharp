using System;
using System.Windows;
using Task1.Models;

namespace Task1;

public partial class AddTransactionWindow : Window
{
    public DateTime TransactionDate { get; set; }
    public string Category { get; set; }
    public decimal Amount { get; set; }
    public TransactionType Type { get; set; }

    public AddTransactionWindow(TransactionType defaultType)
    {
        InitializeComponent();

        TransactionDate = DateTime.Now;
        DatePicker.SelectedDate = TransactionDate;

        if (defaultType == TransactionType.Income)
            TypeComboBox.SelectedIndex = 0;
        else
            TypeComboBox.SelectedIndex = 1;
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(CategoryTextBox.Text))
        {
            MessageBox.Show("Введите категорию", "Ошибка");
            return;
        }

        if (!decimal.TryParse(AmountTextBox.Text, out decimal amount) || amount <= 0)
        {
            MessageBox.Show("Введите корректную сумму", "Ошибка");
            return;
        }

        TransactionDate = DatePicker.SelectedDate ?? DateTime.Now;
        Category = CategoryTextBox.Text;
        Amount = amount;
        Type = TypeComboBox.SelectedIndex == 0 ? TransactionType.Income : TransactionType.Expense;

        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}