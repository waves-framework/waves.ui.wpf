using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.View.Interfaces;

namespace Waves.UI.WPF.Showcase.View.ModalWindow
{
    /// <summary>
    ///     Логика взаимодействия для ShowPropertyModalWindowContentView.xaml
    /// </summary>
    public partial class ShowPropertyModalWindowContentView : IModalWindowsPresentationView
    {
        /// <summary>
        ///     Creates new instance of show property content.
        /// </summary>
        public ShowPropertyModalWindowContentView()
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