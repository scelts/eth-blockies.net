using System;
using System.Windows.Input;

namespace ExampleApp.WPF.Infra
{
    internal class DelegateCommand : ICommand
    {
        private readonly Action _action;
#pragma warning disable 0067
        public event EventHandler CanExecuteChanged;
#pragma warning restore 0067

        public DelegateCommand(Action action)
        {
            _action = action;
        }

        public void Execute(object parameter)
            => _action();

        public bool CanExecute(object parameter) 
            => true;
    }
}
