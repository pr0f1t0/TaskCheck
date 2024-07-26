using System.Configuration;
using System.Data;
using System.Windows;
using TaskCheck.Desktop.ViewModels;

namespace TaskCheck.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new LoginWindow()
            {
                DataContext = new LoginWindowViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
            
        }
    }

}
