using System.Windows;

namespace Sample.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            var viewModel = new MainViewModel(
                new ImageLogic(
                    new FileSystemImageManager("Images")),
                new WpfDialogService());

            this.DataContext = viewModel;

            this.Loaded += (s, e) =>
            {
                viewModel.SearchImages();
            };
        }
    }
}
