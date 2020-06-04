using System;
using System.Collections.Generic;
using Waves.Presentation.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Windows.Base;
using Waves.UI.Windows.Controls.Modality.Base.Interfaces;
using Waves.UI.Windows.Controls.Modality.Presentation.Enums;
using Waves.UI.Windows.Controls.Modality.View;
using Waves.UI.Windows.Controls.Modality.ViewModel;
using Waves.UI.Windows.Extensions;

namespace Waves.UI.Windows.Controls.Modality.Presentation
{
    /// <summary>
    /// Message modal window presentation.
    /// </summary>
    public class MessageModalWindowPresentation : ModalWindowPresentation
    {
        private IVectorImage _icon;

        private IPresentationViewModel _dataContext;

        /// <summary>
        /// Creates new instance of <see cref="MessageModalWindowPresentation"/>.
        /// </summary>
        /// <param name="title">Title.</param>
        /// <param name="message">Message.</param>
        /// <param name="icon">Icon type.</param>
        public MessageModalWindowPresentation(string title, string message, MessageIcon icon)
        {
            Title = title;
            Message = message;

            InitializeIcon(icon);
        }

        /// <inheritdoc />
        public override IVectorImage Icon => _icon;

        /// <inheritdoc />
        public override string Title { get; }

        /// <summary>
        /// Gets or sets message.
        /// </summary>
        public string Message { get; set; }

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
        /// Initializes icon.
        /// </summary>
        /// <param name="icon">Icon type.</param>
        private void InitializeIcon(MessageIcon icon)
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

        /// <summary>
        /// Initializes actions.
        /// </summary>
        /// <param name="actions"></param>
        public void InitializeActions(ICollection<IModalWindowAction> actions)
        {
            foreach (var action in actions)
            {
                this.AddAction(action);
            }
        }
    }
}