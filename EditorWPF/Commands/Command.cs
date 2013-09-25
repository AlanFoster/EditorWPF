using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EditorWPF.Commands
{
    // TODO Add common base class
    public abstract class Command : ICommand
    {
        public Command()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object paramter)
        {
            Execute();
        }

        public abstract void Execute();

        public event EventHandler CanExecuteChanged = delegate { };
    }

    public abstract class Command<T> : ICommand where T : class
    {
        private readonly DelegateCommand<T> _command;

        public Command()
        {
            _command = new DelegateCommand<T>(CanExecute, Execute);
        }

        public abstract void Execute(T parameter);

        public bool CanExecute(T parameter)
        {
            return true;
        }

        public bool CanExecute(object parameter)
        {
            return _command.CanExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _command.Execute(parameter);
        }

        public event EventHandler CanExecuteChanged = delegate { };
    }

}
