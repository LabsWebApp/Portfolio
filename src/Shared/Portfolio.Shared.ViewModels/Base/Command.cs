using System;
using System.Windows.Input;

namespace Portfolio.Shared.ViewModels.Base
{
    public class Command : ICommand
    {
        private readonly Action<object> _execute;

        public Command(Action<object> execute)
            => _execute = execute;
#nullable enable
        public bool CanExecute(object? parameter) => true;
#nullable disable
#nullable enable
        public void Execute(object? parameter)
        {
            if (CanExecute(parameter))
                _execute?.Invoke(parameter);
        }
#nullable disable
        public event EventHandler CanExecuteChanged;
    }
}
