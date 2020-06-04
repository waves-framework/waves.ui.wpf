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
    /// Show property presentation.
    /// </summary>
    public class ShowPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private IPresentationViewModel _dataContext;

        /// <summary>
        /// Creates new instance of show property presentation.
        /// </summary>
        public ShowPropertyModalWindowPresentation(IProperty property)
        {
            Property = property;

            InitializeView();
            InitializeActions();
        }

        /// <inheritdoc />
        public override IVectorImage Icon { get; } = new ResourcesVectorIcon("Icon-File");

        /// <inheritdoc />
        public override string Title { get; } = "Show property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ShowPropertyModalWindowContentView();

        /// <summary>
        /// Gets property.
        /// </summary>
        public IProperty Property { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new ShowPropertyModalWindowViewModel(Property);

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
        }
    }
}