using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EF_DB_Text.Commands
{
    public class ActionRelayCommand : ICommand
    {
        private readonly Action? _execute;
        
        private readonly Predicate<object?>? _canExecute;

        public ActionRelayCommand(Action execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }


        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute();
        }


        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        
    }
}
