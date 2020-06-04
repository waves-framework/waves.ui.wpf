using System.Collections.ObjectModel;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Windows.Base;
using Waves.UI.Windows.Controls.Modality.Base;
using Waves.UI.Windows.Controls.Modality.Presentation;
using Waves.UI.Windows.Extensions;
using Waves.UI.Windows.Showcase.View.ModalWindow;
using Waves.UI.Windows.Showcase.ViewModel.ModalWindow;

namespace Waves.UI.Windows.Showcase.Presentation.ModalWindow
{
    /// <summary>
    /// Edit property presentation.
    /// </summary>
    public class EditPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private IPresentationViewModel _dataContext;

        private readonly IProperty _property;

        private readonly IConfiguration _configuration;

        /// <summary>
        /// Creates new instance of add property modality window action.
        /// </summary>
        public EditPropertyModalWindowPresentation(IProperty property, IConfiguration configuration)
        {
            InitializeView();
            InitializeActions();

            _property = property;
            _configuration = configuration;
        }

        /// <inheritdoc />
        public override IVectorImage Icon { get; } = new ResourcesVectorIcon("Icon-File");

        /// <inheritdoc />
        public override string Title => "Edit property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public override IPresentationView View { get; } = new EditPropertyModalWindowContentView();

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new EditPropertyModalWindowViewModel(_property);

            base.Initialize();
        }

        /// <summary>
        /// Initializes view.
        /// </summary>
        private void InitializeView()
        {
            MaxWidth = 640;
            MaxHeight = 480;
        }

        /// <summary>
        /// Initializes actions.
        /// </summary>
        private void InitializeActions()
        {
            this.AddAction(ModalWindowAction.Close(delegate { App.Core.HideModalityWindow(this); }));
            this.AddAction(ModalWindowAction.Save(delegate
            {
                var context = _dataContext as EditPropertyModalWindowViewModel;
                if (context == null) return;

                var property = context.GetResultProperty();

                _property.SetValue(property.GetValue());

                App.Core.HideModalityWindow(this);
            }));
        }
    }
}