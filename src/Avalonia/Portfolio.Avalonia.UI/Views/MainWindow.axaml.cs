using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Portfolio.Shared.ViewModels;

namespace Portfolio.Avalonia.UI.Views
{
    public class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
