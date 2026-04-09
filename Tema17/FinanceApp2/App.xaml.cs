using System.Windows;
using FinanceApp2.Services;

namespace FinanceApp2
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dataService = new DataService();
            var authService = new AuthService(dataService);

            var loginWindow = new LoginWindow(authService);
            loginWindow.Show();
        }
    }
}