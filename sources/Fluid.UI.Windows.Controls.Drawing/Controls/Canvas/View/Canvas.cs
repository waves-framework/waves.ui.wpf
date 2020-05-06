using System;
using System.ComponentModel;
using System.Windows.Data;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Behaviors;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.WPF;

namespace Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.View
{
    /// <summary>
    /// Drawing canvas.
    /// </summary>
    [Category("Fluid - Drawing")]
    public class Canvas : SKElement, IPresentationView, IDisposable
    {
        private readonly Point _lastTouchPosition = new Point();

        /// <summary>
        /// Creates new instance of <see cref="Canvas"/>.
        /// </summary>
        public Canvas()
        {
            InitializeBehaviors();
            SubscribeEvents();
        }

        /// <summary>
        /// Finalizes instance.
        /// </summary>
        ~Canvas()
        {
            Dispose();
        }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Initializes behaviors.
        /// </summary>
        private void InitializeBehaviors()
        {
            Interaction.GetBehaviors(this).Add(new PaintBehavior());
        }

        /// <summary>
        /// Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
        }

        /// <summary>
        /// Unsubscribe events.
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