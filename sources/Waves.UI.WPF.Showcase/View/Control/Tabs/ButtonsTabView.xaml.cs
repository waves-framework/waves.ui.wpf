using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.UI.WPF.Showcase.View.Control.Tabs
{
    /// <summary>
    ///     Логика взаимодействия для ButtonsTabView.xaml
    /// </summary>
    public partial class ButtonsTabView : IPresentationView
    {
        /// <summary>
        /// Creates new instance of buttons tab view.
        /// </summary>
        public ButtonsTabView()
        {
            InitializeComponent();
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
    }
}