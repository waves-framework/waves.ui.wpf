using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Controls.Modality.Base;
using Fluid.UI.Windows.Controls.Modality.Presentation;
using Fluid.UI.Windows.Extensions;
using Fluid.UI.Windows.Showcase.View.ModalWindow;
using Fluid.UI.Windows.Showcase.ViewModel.ModalWindow;

namespace Fluid.UI.Windows.Showcase.Presentation.ModalWindow
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
        public override IVectorIcon Icon { get; } = new ResourcesVectorIcon("Icon-File");

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