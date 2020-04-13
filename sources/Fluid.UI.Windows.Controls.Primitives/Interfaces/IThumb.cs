using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Fluid.UI.Windows.Controls.Primitives.Interfaces
{
    /// <inheritdoc />
    public interface IThumb : IInputElement
    {
        /// <summary>
        ///     Event for drag started handling.
        /// </summary>
        event DragStartedEventHandler DragStarted;

        /// <summary>
        ///     Event for drag delta handling.
        /// </summary>
        event DragDeltaEventHandler DragDelta;

        /// <summary>
        ///     Event for drag completed handling.
        /// </summary>
        event DragCompletedEventHandler DragCompleted;

        /// <summary>
        ///     Event for mouse double click handling.
        /// </summary>
        event MouseButtonEventHandler MouseDoubleClick;
    }
}