using System.Collections.ObjectModel;
using Fluid.Core.Base;
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
        public override IVectorIcon Icon { get; } = new ResourcesVectorIcon("Icon-File");

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