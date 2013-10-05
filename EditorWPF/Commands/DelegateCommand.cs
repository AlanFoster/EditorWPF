using System;
using System.Windows.Input;

namespace EditorWPF.Commands
{
    internal class DelegateCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public DelegateCommand(Predicate<T> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute;
        }

        public DelegateCommand(Action<T> action)
            : this(_ => true, action)
        {
        }

        public bool CanExecute(object parameter)
        {
            // Note, we cannot use `parameter as T`, as if we provide `where T : class`, we can no longer use int as a parameter
            return _canExecute(parameter is T ? (T) parameter : default(T));
        }

        public void Execute(object parameter)
        {
            // Note, we cannot use `parameter as T`, as if we provide `where T : class`, we can no longer use int as a parameter
            _execute(parameter is T ? (T) parameter : default(T));
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }
}