﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ICommand
using System.Windows.Input;

namespace MovieExplorer.ViewModels.Base
{
    public class DelegateCommand<T> : ICommand
    {
        public Action<T> execute;
        public Func<T, bool> canExecute;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public DelegateCommand(Action<T> exec, Func<T, bool> canExec)
        {
            this.execute = exec;
            this.canExecute = canExec;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute == null)
                return true;

            return canExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (execute != null)
            {
                execute((T)parameter);
            }
        }

        public void RaiseCanExecuteChanged(object sender)
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(sender, new EventArgs());
        }
    }
}
