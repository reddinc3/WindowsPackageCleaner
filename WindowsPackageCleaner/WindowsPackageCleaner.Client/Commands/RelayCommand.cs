using System;
using System.Windows.Input;

namespace WindowsPackageCleaner.Client.Commands
{
    /// <summary>
    /// Implement a standard relay command to be used to bind any necessary commands to our window.
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        /// <summary>
        /// Initialize an instance of the <see cref="RelayCommand{T}"/> with a specified action.
        /// </summary>
        /// <param name="execute">The action to be bound to this command.</param>
        public RelayCommand(Action<T> execute) : this(null, execute) {}

        /// <summary>
        /// Initialize an instance of the <see cref="RelayCommand{T}"/> with a specified predicate and action.
        /// </summary>
        /// <param name="canExecute">The predicate to be bound to this command.</param>
        /// <param name="execute">The action to be bound to this command.</param>
        public RelayCommand(Predicate<T> canExecute, Action<T> execute)
        {
            _canExecute = canExecute;
            _execute = execute ?? throw new ArgumentNullException("execute");
        }

        /// <summary>
        /// Run the "canExecute" predicate to determine whether or not this command's action can be run.
        /// </summary>
        /// <param name="parameter">Data potentially used by the predicate.</param>
        /// <returns>Whether or not this command's action can run.</returns>
        public bool CanExecute(object parameter) => _canExecute is null || _canExecute((T)parameter);

        /// <summary>
        /// Add an implementation of the "CanExecuteChanged" event handler.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Run the "execute" action for this command.
        /// </summary>
        /// <param name="parameter">Data potentially used by the action.</param>
        public void Execute(object parameter) => _execute((T)parameter);
    }
}