using System;
using System.Windows.Input;

namespace Fluid.Presentation.Windows.Commands
{
    /// <summary>
    /// Command.
    /// </summary>
    public class Command : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Creates new instance of command.
        /// </summary>
        /// <param name="execute">Execute action.</param>
        /// <param name="canExecute">Can execute delegate.</param>
        public Command(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <inheritdoc />
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}