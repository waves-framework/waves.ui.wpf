using System;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.View.Interfaces;

namespace Waves.UI.WPF.Showcase.View.ModalWindow
{
    /// <summary>
    ///     Логика взаимодействия для AddPropertyModalityWindowContentView.xaml
    /// </summary>
    public partial class AddPropertyModalWindowContentView : IModalWindowsPresenterView
    {
        /// <summary>
        ///     Creates new instance of add property modality window content view.
        /// </summary>
        public AddPropertyModalWindowContentView()
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
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IWavesMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }
    }
}