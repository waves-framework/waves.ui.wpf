using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.UI.WPF.Controls.Drawing.Engines.System.Behavior;
using Microsoft.Xaml.Behaviors;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Drawing.View.Interfaces;

namespace Waves.UI.WPF.Controls.Drawing.Engines.System.View
{
    /// <summary>
    ///     Drawing canvas.
    /// </summary>
    [Category("Waves - Drawing")]
    public class SystemDrawingElementView : Canvas, IDrawingElementPresenterView
    {
        /// <summary>
        ///     Creates new instance of <see cref="SystemDrawingElementView" />.
        /// </summary>
        public SystemDrawingElementView(IInputService inputService)
        {
            InitializeBehaviors(inputService);
            SubscribeEvents();

            Background = Brushes.Transparent;
        }

        /// <summary>
        ///     Finalizes instance.
        /// </summary>
        ~SystemDrawingElementView()
        {
            Dispose();
        }
        
        /// <inheritdoc />
        public event EventHandler<IWavesMessage> MessageReceived;

        /// <inheritdoc />
        public IWavesCore Core { get; private set; }

        /// <inheritdoc />
        public Guid Id { get; } = Guid.NewGuid();
        
        /// <inheritdoc />
        public void AttachCore(IWavesCore core)
        {
            Core = core;
        }
        
        /// <summary>
        ///     Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IWavesMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        ///     Initializes behaviors.
        /// </summary>
        private void InitializeBehaviors(IInputService inputService)
        {
            Interaction.GetBehaviors(this).Add(new SystemPaintBehavior(inputService));
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