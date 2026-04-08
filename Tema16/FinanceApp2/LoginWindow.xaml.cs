using System.Windows;
using FinanceApp2.Services;

namespace FinanceApp2
{
    public partial class LoginWindow : Window
    {
        private AuthService _authService;

        public LoginWindow(AuthService authService)
        {
            InitializeComponent();
            _authService = authService;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "Введите логин и пароль";
                return;
            }

            if (_authService.Login(username, password))
            {
                var mainWindow = new MainWindow(_authService);
                mainWindow.Show();
                Close();
            }
            else
            {
                txtError.Text = "Неверный логин или пароль";
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_authService);
            registerWindow.ShowDialog();
        }
    }
}