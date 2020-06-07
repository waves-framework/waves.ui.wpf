using Waves.Presentation.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Modality.Presentation.Enums;
using Waves.UI.Modality.ViewModel;
using Waves.UI.WPF.Base;
using Waves.UI.WPF.Controls.Modality.View;

namespace Waves.UI.WPF.Controls.Modality.Presentation
{
    /// <summary>
    ///     Message modal window presentation.
    /// </summary>
    public class MessageModalWindowPresentation : UI.Modality.Presentation.MessageModalWindowPresentation
    {
        private IVectorImage _icon;

        private IPresentationViewModel _dataContext;

        /// <summary>
        ///     Creates new instance of <see cref="MessageModalWindowPresentation" />.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="icon">Icon type.</param>
        public MessageModalWindowPresentation(string title, string message, MessageIcon icon) : base(title, message)
        {
            Title = title;
            Message = message;

            InitializeIcon(icon);
        }

        /// <inheritdoc />
        public override IVectorImage Icon => _icon;

        /// <inheritdoc />
        public override string Title { get; }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public override IPresentationView View { get; } = new MessageModalWindowView();

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new MessageModalWindowViewModel(Message, Icon);

            base.Initialize();
        }

        /// <summary>
        ///     Initializes icon.
        /// </summary>
        /// <param name="icon">Icon type.</param>
        protected sealed override void InitializeIcon(MessageIcon icon)
        {
            switch (icon)
            {
                case MessageIcon.Information:
                    _icon = new ResourcesVectorIcon("Icon-Information");
                    break;
                case MessageIcon.Warning:
                    _icon = new ResourcesVectorIcon("Icon-Warning");
                    break;
                case MessageIcon.Error:
                    _icon = new ResourcesVectorIcon("Icon-Error");
                    break;
                case MessageIcon.Question:
                    _icon = new ResourcesVectorIcon("Icon-Help");
                    break;
            }
        }
    }
}