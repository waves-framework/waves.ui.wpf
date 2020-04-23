using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Commands;
using Fluid.UI.Windows.Showcase.Presentation.ModalityWindows;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Configuration tab view model.
    /// </summary>
    public class ConfigurationTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets core configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets "Add new property" command.
        /// </summary>
        public ICommand AddPropertyCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            Configuration = App.Core.Configuration;

            InitializeCommands();
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            AddPropertyCommand = new Command(OnAddProperty);
        }

        /// <summary>
        /// Actions for "Add property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnAddProperty(object obj)
        {
            var presentation = new AddPropertyModalityWindowPresentation(new Property<object>("New property", null, false));
            App.Core.ShowModalityWindow(presentation);
        }
    }
}
