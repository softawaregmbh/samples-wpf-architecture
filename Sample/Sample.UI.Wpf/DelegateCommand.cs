using System;
using System.Windows.Input;

namespace Sample.UI.Wpf
{
    public class DelegateCommand : ICommand
    {
        private readonly Action execute;

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public DelegateCommand(Action execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter) => this.execute();
    }
}
