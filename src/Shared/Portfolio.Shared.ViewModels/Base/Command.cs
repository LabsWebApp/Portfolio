﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Portfolio.Shared.ViewModels.Base
{
    public class Command : ICommand
    {
        private readonly Action<object> _execute;

        public Command(Action<object> execute)
        {
            _execute = execute;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter);
        }

        public event EventHandler? CanExecuteChanged;
    }
}
