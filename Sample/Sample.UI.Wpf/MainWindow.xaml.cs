using System.Windows;

namespace Sample.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;

            this.Loaded += (s, e) =>
            {
                viewModel.SearchImages();
            };
        }
    }
}
