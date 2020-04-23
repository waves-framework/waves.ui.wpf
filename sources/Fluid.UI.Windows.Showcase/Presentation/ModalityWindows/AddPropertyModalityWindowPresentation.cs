using System;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Presentation.ModalityWindows.Base;
using Fluid.UI.Windows.Presentation.ModalityWindows.Extensions;
using Fluid.UI.Windows.Showcase.View.ModalityWindow;
using Fluid.UI.Windows.Showcase.ViewModel.ModalityWindows;

namespace Fluid.UI.Windows.Showcase.Presentation.ModalityWindows
{
    /// <summary>
    /// Add property modality window presentation.
    /// </summary>
    public class AddPropertyModalityWindowPresentation : ModalityWindowPresentation
    {
        private IPresentationViewModel _dataContext;

        /// <summary>
        /// Creates new instance of add property modality window action.
        /// </summary>
        public AddPropertyModalityWindowPresentation(IProperty property)
        {
            Property = property;

            InitializeView();
            InitializeActions();
        }

        /// <summary>
        /// Gets editing property.
        /// </summary>
        public IProperty Property { get; private set; }

        /// <inheritdoc />
        public override IVectorIcon Icon { get; }

        /// <inheritdoc />
        public override string Title => "Add property";

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public override IPresentationView View { get; } = new AddPropertyModalityWindowContentView();

        /// <inheritdoc />
        public override void Initialize()
        {
            _dataContext = new AddPropertyModalityWindowViewModel(Property);

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
        /// Initializaes actions.
        /// </summary>
        private void InitializeActions()
        {
            this.AddAction(ModalityWindowAction.CloseModalityWindowAction(delegate { App.Core.HideModalityWindow(this); }));
            this.AddAction(ModalityWindowAction.SaveModalityWindowAction(delegate { App.Core.HideModalityWindow(this); }));
        }
    }
}