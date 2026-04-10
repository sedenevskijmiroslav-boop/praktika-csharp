using System.Windows;
using System.Windows.Controls;
using System.Threading.Tasks;
using FinanceApp2.Services;

namespace FinanceApp2
{
    public partial class RegisterWindow : Window
    {
        private AuthService _authService;

        public RegisterWindow(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;
            var role = (cmbRole.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "Заполните все поля";
                return;
            }

            if (await _authService.RegisterAsync(username, password, role))
            {
                MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                txtError.Text = "Пользователь с таким логином уже существует";
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}