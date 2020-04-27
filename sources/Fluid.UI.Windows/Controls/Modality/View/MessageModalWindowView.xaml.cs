using System;
using System.Windows.Controls;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Controls.Modality.View.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.View
{
    /// <summary>
    /// Логика взаимодействия для MessageModalityWindowView.xaml
    /// </summary>
    public partial class MessageModalWindowView : IModalWindowsPresentationView
    {
        /// <summary>
        /// Creates new instance of <see cref="MessageModalWindowView"/>.
        /// </summary>
        public MessageModalWindowView()
        {
            InitializeComponent();
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
    }
}
