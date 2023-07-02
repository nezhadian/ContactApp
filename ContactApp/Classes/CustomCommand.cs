using System;
using System.Windows.Input;

namespace ContactApp
{
    public class CustomCommand : ICommand
    {
        public delegate bool CustomCommandCanExecuteEventHandler(object parameter);
        public event CustomCommandCanExecuteEventHandler CanExecuteAsked;

        public delegate void CustomCommandExecutedEventHandler(object parameter);
        public event CustomCommandExecutedEventHandler Executed;

        public CustomCommand(CustomCommandExecutedEventHandler executed,CustomCommandCanExecuteEventHandler canExecute)
        {
            Executed = executed;
            CanExecuteAsked = canExecute;
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return CanExecuteAsked?.Invoke(parameter) ?? false;
        }
        public void Execute(object parameter)
        {
            Executed?.Invoke(parameter);
        }
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
