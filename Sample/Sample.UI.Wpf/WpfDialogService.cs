using System.Windows;

namespace Sample.UI.Wpf
{
    public class WpfDialogService : IDialogService
    {
        public bool Confirm(string message, string title)
        {
            return MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes;
        }
    }
}