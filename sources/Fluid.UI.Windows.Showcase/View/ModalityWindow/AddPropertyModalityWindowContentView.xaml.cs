using System;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;

namespace Fluid.UI.Windows.Showcase.View.ModalityWindow
{
    /// <summary>
    ///     Логика взаимодействия для AddPropertyModalityWindowContentView.xaml
    /// </summary>
    public partial class AddPropertyModalityWindowContentView : IModalityWindowsPresentationView
    {
        /// <summary>
        ///     Creates new instance of add property modality window content view.
        /// </summary>
        public AddPropertyModalityWindowContentView()
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