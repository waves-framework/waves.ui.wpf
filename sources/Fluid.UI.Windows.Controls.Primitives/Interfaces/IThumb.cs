using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Fluid.UI.Windows.Controls.Primitives.Interfaces
{
    /// <inheritdoc />
    public interface IThumb : IInputElement
    {
        /// <summary>
        ///     Событие начала перемещение.
        /// </summary>
        event DragStartedEventHandler DragStarted;

        /// <summary>
        ///     Событие получение разницы перемещения.
        /// </summary>
        event DragDeltaEventHandler DragDelta;

        /// <summary>
        ///     Событие завершения перемещения.
        /// </summary>
        event DragCompletedEventHandler DragCompleted;

        /// <summary>
        ///     Событие двойного клика.
        /// </summary>
        event MouseButtonEventHandler MouseDoubleClick;
    }
}