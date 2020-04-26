using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Commands;
using Fluid.UI.Windows.Controls.Modality.Base;
using Fluid.UI.Windows.Controls.Modality.Presentation;
using Fluid.UI.Windows.Controls.Modality.Presentation.Enums;
using Fluid.UI.Windows.Showcase.Presentation.ModalWindow;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Configuration tab view model.
    /// </summary>
    public class ConfigurationTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets or sets selected property.
        /// </summary>
        public IProperty SelectedProperty { get; set; }

        /// <summary>
        /// Gets core configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets "Add new property" command.
        /// </summary>
        public ICommand AddPropertyCommand { get; private set; }

        /// <summary>
        /// Gets "Remove property" command.
        /// </summary>
        public ICommand RemovePropertyCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            Configuration = (IConfiguration)App.Core.Configuration.Clone();

            InitializeCommands();
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            AddPropertyCommand = new Command(OnAddProperty);
            RemovePropertyCommand = new Command(OnRemoveProperty);
        }

        /// <summary>
        /// Actions for "Add property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnAddProperty(object obj)
        {
            var presentation = new AddPropertyModalWindowPresentation(Configuration);
            App.Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        /// Actions for "Remove property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnRemoveProperty(object obj)
        {
            var presentation = new MessageModalWindowPresentation(
                "Remove property",
                "Do you want to remove property \"" + SelectedProperty.Name + "\"?",
                MessageIcon.Question);

            var actions = ModalWindowAction.YesNo(
                new Action(() =>
                {
                    Configuration.RemoveProperty(SelectedProperty.Name);

                    App.Core.HideModalityWindow(presentation);
                }), new Action(() =>
                {
                    App.Core.HideModalityWindow(presentation);
                }));

            presentation.InitializeActions(actions);

            App.Core.ShowModalityWindow(presentation);

        } 
    }
}
