using System.Windows;
using System.Threading.Tasks;
using FinanceApp2.Services;
using FinanceApp2.Data;

namespace FinanceApp2
{
    public partial class LoginWindow : Window
    {
        private AuthService _authService;
        private ApplicationDbContext _context;

        public LoginWindow()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            _authService = new AuthService(_context);
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            var username = txtUsername.Text;
            var password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                txtError.Text = "Введите логин и пароль";
                return;
            }

            if (await _authService.LoginAsync(username, password))
            {
                var mainWindow = new MainWindow(_context, _authService);
                mainWindow.Show();
                Close();
            }
            else
            {
                txtError.Text = "Неверный логин или пароль";
            }
        }

        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            var registerWindow = new RegisterWindow(_authService);
            registerWindow.ShowDialog();
        }
    }
}