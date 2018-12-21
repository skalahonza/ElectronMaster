using System;
using System.Windows.Input;

namespace ElectronMaster.ViewModel
{
    public class GenericRelayCommand<T> : ICommand where T : class
    {
        readonly Action<T> _execute;
        readonly Predicate<T> _canExecute;

        public GenericRelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }


        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        public GenericRelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke((T)parameter) ?? true;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}
