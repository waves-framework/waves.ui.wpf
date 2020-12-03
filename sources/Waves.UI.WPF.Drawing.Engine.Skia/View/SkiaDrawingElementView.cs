using System;
using System.ComponentModel;
using Waves.Core.Base.Interfaces;
using Waves.UI.WPF.Drawing.Engine.Skia.Behavior;
using Microsoft.Xaml.Behaviors;
using SkiaSharp.Views.WPF;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Drawing.View.Interfaces;

namespace Waves.UI.WPF.Drawing.Engine.Skia.View
{
    /// <summary>
    ///     Drawing canvas.
    /// </summary>
    [Category("Waves - Drawing")]
    public class SkiaDrawingElementView : SKElement, IDrawingElementPresenterView
    {
        /// <summary>
        /// Creates new instance of <see cref="SkiaDrawingElementView" />.
        /// </summary>
        /// <param name="inputService">Input service.</param>
        public SkiaDrawingElementView(IInputService inputService)
        {
            IgnorePixelScaling = true;

            InitializeBehaviors(inputService);
            SubscribeEvents();
        }
        
        /// <inheritdoc />
        public event EventHandler<IWavesMessage> MessageReceived;
        
        /// <inheritdoc />
        public IWavesCore Core { get; private set; }

        /// <inheritdoc />
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        ///     Finalizes instance.
        /// </summary>
        ~SkiaDrawingElementView()
        {
            Dispose();
        }

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
        /// Initializes behaviors.
        /// </summary>
        /// <param name="inputService">Input service.</param>
        private void InitializeBehaviors(IInputService inputService)
        {
            Interaction.GetBehaviors(this).Add(new SkiaPaintBehavior(inputService));
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