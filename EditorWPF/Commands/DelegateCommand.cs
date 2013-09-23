using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditorWPF.Commands
{
    class DelegateCommand<T> : ICommand where T : class
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
            return _canExecute(parameter as T);
        }

        public void Execute(object parameter)
        {
            _execute(parameter as T);
        }

        public event EventHandler CanExecuteChanged;
    }
}
