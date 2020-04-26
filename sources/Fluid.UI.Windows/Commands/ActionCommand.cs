using System;
using System.Windows.Input;

namespace Fluid.UI.Windows.Commands
{
    /// <summary>
    ///     Action command.
    /// </summary>
    /// <typeparam name="T">Type.</typeparam>
    public class ActionCommand<T> : ICommand
    {
        private readonly Action<T> _action;

        /// <summary>
        ///     Creates new instance of action command.
        /// </summary>
        /// <param name="action">Action.</param>
        public ActionCommand(Action<T> action)
        {
            _action = action;
        }

        /// <inheritdoc />
        public event EventHandler CanExecuteChanged;

        /// <inheritdoc />
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <inheritdoc />
        public void Execute(object parameter)
        {
            if (_action == null) return;
            var castParameter = (T) Convert.ChangeType(parameter, typeof(T));
            _action(castParameter);
        }
    }
}