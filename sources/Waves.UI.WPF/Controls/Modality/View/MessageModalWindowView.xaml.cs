using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.View.Interfaces;

namespace Waves.UI.WPF.Controls.Modality.View
{
    /// <summary>
    ///     Логика взаимодействия для MessageModalityWindowView.xaml
    /// </summary>
    public partial class MessageModalWindowView : IModalWindowsPresenterView
    {
        /// <summary>
        ///     Creates new instance of <see cref="MessageModalWindowView" />.
        /// </summary>
        public MessageModalWindowView()
        {
            InitializeComponent();
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
    }
}