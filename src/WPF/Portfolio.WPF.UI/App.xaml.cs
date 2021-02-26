using System.Windows;
using Portfolio.WPF.UI.Views;

namespace Portfolio.WPF.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            new MainWindow ().Show();
            base.OnStartup(e);
        }
    }
}
