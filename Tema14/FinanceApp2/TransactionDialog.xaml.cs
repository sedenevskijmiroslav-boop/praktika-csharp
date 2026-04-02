using System;
using System.Windows;
using System.Windows.Controls;
using FinanceApp2.Models;

namespace FinanceApp2
{
    public partial class TransactionDialog : Window
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public TransactionDialog(Transaction transaction = null)
        {
            InitializeComponent();

            if (transaction != null)
            {
                txtAmount.Text = transaction.Amount.ToString();

                if (transaction.Type == "Доход")
                    cmbType.SelectedIndex = 0;
                else
                    cmbType.SelectedIndex = 1;

                dpDate.SelectedDate = transaction.Date;
                txtDescription.Text = transaction.Description;
            }
            else
            {
                dpDate.SelectedDate = DateTime.Now;
                cmbType.SelectedIndex = 0;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(txtAmount.Text, out decimal amount) && amount > 0)
            {
                Amount = amount;
                Type = (cmbType.SelectedItem as ComboBoxItem)?.Content.ToString();
                Date = dpDate.SelectedDate ?? DateTime.Now;
                Description = txtDescription.Text;

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректную сумму", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}