using System;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;

namespace Fluid.UI.Windows.Showcase.View.Control.Tabs
{
    /// <summary>
    ///     Логика взаимодействия для ThemeTabView.xaml
    /// </summary>
    public partial class ThemeTabView : IPresentationView
    {
        /// <summary>
        ///     Creates new instance of theme tab view.
        /// </summary>
        public ThemeTabView()
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