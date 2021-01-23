using System.Windows;
using Portfolio.Shared.ViewModels;

namespace Portfolio.WPF.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
