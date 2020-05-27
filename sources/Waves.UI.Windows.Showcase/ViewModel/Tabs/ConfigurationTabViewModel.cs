using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Data;
using System.Windows.Input;
using Waves.Core.Base;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Base;
using Waves.UI.Windows.Commands;
using Waves.UI.Windows.Controls.Modality.Base;
using Waves.UI.Windows.Controls.Modality.Presentation;
using Waves.UI.Windows.Controls.Modality.Presentation.Enums;
using Waves.UI.Windows.Showcase.Presentation.ModalWindow;

namespace Waves.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Configuration tab view model.
    /// </summary>
    public class ConfigurationTabViewModel : PresentationViewModel
    {
        private readonly object _locker = new object();

        /// <summary>
        /// Gets whether configuration is changed.
        /// </summary>
        public bool IsConfigurationChanged { get; private set; }

        /// <summary>
        /// Gets or sets selected property.
        /// </summary>
        public IProperty SelectedProperty { get; set; }

        /// <summary>
        /// Gets collection of propeties.
        /// </summary>
        public ObservableCollection<IProperty> Properties { get; private set; } = new ObservableCollection<IProperty>();

        /// <summary>
        /// Gets core configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Gets "Add new property" command.
        /// </summary>
        public ICommand AddPropertyCommand { get; private set; }

        /// <summary>
        /// Gets "Show property" command.
        /// </summary>
        public ICommand ShowPropertyCommand { get; private set; }

        /// <summary>
        /// Gets "Edit property" command.
        /// </summary>
        public ICommand EditPropertyCommand { get; private set; }

        /// <summary>
        /// Gets "Save All" command.
        /// </summary>
        public ICommand SaveAllCommand { get; private set; }

        /// <summary>
        /// Gets "Remove property" command.
        /// </summary>
        public ICommand RemovePropertyCommand { get; private set; }

        /// <summary>
        /// Gets "Double click" command.
        /// </summary>
        public ICommand PropertiesDoubleClickCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            Configuration = (IConfiguration)App.Core.Configuration.Clone();

            InitializeCollection();
            SubscribeEvents();
            InitializeCommands();
        }

        /// <summary>
        /// Initializes collection synchronization.
        /// </summary>
        private void InitializeCollection()
        {
            BindingOperations.EnableCollectionSynchronization(Properties, _locker);

            Properties.Clear();

            foreach (var property in Configuration.GetProperties())
            {
                Properties.Add(property);
            }
        }

        /// <summary>
        /// Subscribe events.
        /// </summary>
        private void SubscribeEvents()
        {
            Configuration.PropertyChanged += OnConfigurationPropertyChanged;

            foreach (var property in Configuration.GetProperties())
            {
                property.PropertyChanged += OnConfigurationPropertyChanged;
            }

            Properties.CollectionChanged += OnPropertyCollectionCollectionChanged;
        }

        /// <summary>
        /// Notifies when property collection changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPropertyCollectionCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            IsConfigurationChanged = !Configuration.Equals(App.Core.Configuration);
        }

        /// <summary>
        /// Notifies when configuration property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnConfigurationPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            IsConfigurationChanged = !Configuration.Equals(App.Core.Configuration);
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            AddPropertyCommand = new Command(OnAddProperty);
            ShowPropertyCommand = new Command(OnShowProperty);
            EditPropertyCommand = new Command(OnEditProperty);
            RemovePropertyCommand = new Command(OnRemoveProperty);
            SaveAllCommand = new Command(OnSaveAll);
            PropertiesDoubleClickCommand = new Command(OnPropertiesDoubleClick);
        }

        /// <summary>
        /// Actions for "Add property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnAddProperty(object obj)
        {
            var presentation = new AddPropertyModalWindowPresentation(Properties, Configuration);
            App.Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        /// Actions for "Show property".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnShowProperty(object obj)
        {
            var presentation = new ShowPropertyModalWindowPresentation(SelectedProperty);
            App.Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        /// Actions for "Edit property".
        /// </summary>
        /// <param name="obj"></param>
        private void OnEditProperty(object obj)
        {
            var presentation = new EditPropertyModalWindowPresentation(SelectedProperty, Configuration);

            // Hack for next exception:
            // System.Private.CoreLib: An exception was received:
            // An item with the same key has already been added. Key: System.Windows.Controls.ItemsControl+ItemInfo.
            SelectedProperty = null;       

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

                    Properties.Remove(SelectedProperty);

                    App.Core.HideModalityWindow(presentation);
                }), new Action(() =>
                {
                    App.Core.HideModalityWindow(presentation);
                }));

            presentation.InitializeActions(actions);

            App.Core.ShowModalityWindow(presentation);

        }

        /// <summary>
        /// Actions for "Save all".
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnSaveAll(object obj)
        {
            var presentation = new MessageModalWindowPresentation(
                "Save configuration",
                "Do you really want to save configuration?",
                MessageIcon.Warning);

            var actions = ModalWindowAction.YesNo(
                new Action(() =>
                {
                    Configuration.RewriteConfiguration(Configuration);

                    App.Core.HideModalityWindow(presentation);
                }), new Action(() =>
                {
                    App.Core.HideModalityWindow(presentation);
                }));

            presentation.InitializeActions(actions);

            App.Core.ShowModalityWindow(presentation);
        }

        /// <summary>
        /// Actions for double click.
        /// </summary>
        /// <param name="obj"></param>
        private void OnPropertiesDoubleClick(object obj)
        {
            OnShowProperty(null);
        }
    }
}
