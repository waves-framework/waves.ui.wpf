using Waves.UI.Base.Interfaces;

namespace Waves.UI.Windows.Controls.Modality.ViewModel
{
    /// <summary>
    /// Message modal window presentation view model.
    /// </summary>
    public class MessageModalWindowViewModel : ModalWindowPresentationViewModel
    {
        /// <summary>
        /// Creates new instance of message modal window view model.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="icon">Icon.</param>
        public MessageModalWindowViewModel(string message, IVectorImage icon)
        {
            Message = message;
            Icon = icon;
        }

        /// <summary>
        /// Gets or sets modal window message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets modal window icon.
        /// </summary>
        public IVectorImage Icon { get; set; }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}