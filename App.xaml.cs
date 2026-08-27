using System.Configuration;
using System.Data;
using System.Windows;

using WpfApp1.Views;

namespace WpfApp1
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            LoginWindow login = new LoginWindow();

            MainWindow = login;

            login.Show();
        }
    }
}
