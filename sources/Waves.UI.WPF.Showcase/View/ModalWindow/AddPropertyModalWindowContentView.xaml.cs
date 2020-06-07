using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.View.Interfaces;

namespace Waves.UI.WPF.Showcase.View.ModalWindow
{
    /// <summary>
    ///     Логика взаимодействия для AddPropertyModalityWindowContentView.xaml
    /// </summary>
    public partial class AddPropertyModalWindowContentView : IModalWindowsPresentationView
    {
        /// <summary>
        ///     Creates new instance of add property modality window content view.
        /// </summary>
        public AddPropertyModalWindowContentView()
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