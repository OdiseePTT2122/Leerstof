using System;
using System.Windows.Input;

namespace TDD
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action action;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}