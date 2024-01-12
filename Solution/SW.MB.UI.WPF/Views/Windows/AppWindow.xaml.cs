using System.Windows;
using SW.MB.UI.WPF.ViewModels;

namespace SW.MB.UI.WPF.Views.Windows
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// </summary>
    public partial class AppWindow : Window
    {
        public AppViewModel ViewModel => (AppViewModel)DataContext;

        public AppWindow(AppViewModel viewModel)
        {
            InitializeComponent();

            DataContext = viewModel;
        }
    }
}
