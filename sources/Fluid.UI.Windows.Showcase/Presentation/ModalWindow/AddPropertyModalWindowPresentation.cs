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
    /// Add property modality window presentation.
    /// </summary>
    public class AddPropertyModalWindowPresentation : ModalWindowPresentation
    {
        private IPresentationViewModel _dataContext;

        /// <summary>
        /// Creates new instance of add property modality window action.
        /// </summary>
        public AddPropertyModalWindowPresentation(IConfiguration configuration)
        {
            Configuration = configuration;

            InitializeView();
            InitializeActions();
        }

        /// <summary>
        /// Gets configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <inheritdoc />
        public override IVectorIcon Icon { get; } = new ResourcesVectorIcon("Icon-File-New");

        /// <inheritdoc />
        public override string Title => "Add property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public override IPresentationView View { get; } = new AddPropertyModalWindowContentView();

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new AddPropertyModalWindowViewModel();

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
                var context = _dataContext as AddPropertyModalWindowViewModel;
                if (context == null) return;

                var property = context.GetResultProperty();

                Configuration.Properties.Add(property);

                App.Core.HideModalityWindow(this);
            }));
        }
    }
}