using System;
using System.ComponentModel;
using System.Windows.Controls;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Engines.System.Behavior;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Microsoft.Xaml.Behaviors;

namespace Fluid.UI.Windows.Controls.Drawing.Engines.System.View
{
    /// <summary>
    ///     Drawing canvas.
    /// </summary>
    [Category("Fluid - Drawing")]
    public class DrawingElementPresentationView : Canvas, IDrawingElementView
    {
        private readonly Point _lastTouchPosition = new Point();

        /// <summary>
        ///     Creates new instance of <see cref="DrawingElementPresentationView" />.
        /// </summary>
        public DrawingElementPresentationView()
        {
            InitializeBehaviors();
            SubscribeEvents();
        }

        /// <summary>
        ///     Finalizes instance.
        /// </summary>
        ~DrawingElementPresentationView()
        {
            Dispose();
        }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        ///     Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        ///     Initializes behaviors.
        /// </summary>
        private void InitializeBehaviors()
        {
            Interaction.GetBehaviors(this).Add(new PaintBehavior());
        }

        /// <summary>
        ///     Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
        }

        /// <summary>
        ///     Unsubscribe events.
        /// </summary>
        private void UnsubscribeEvents()
        {
        }

        /// <inheritdoc />
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            UnsubscribeEvents();
        }
    }
}