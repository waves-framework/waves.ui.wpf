using System.Collections.Generic;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Presentation.ModalityWindows.Base;

namespace Fluid.UI.Windows.Showcase.ViewModel.ModalityWindows
{
    /// <summary>
    /// Add property modality window view model.
    /// </summary>
    public class AddPropertyModalityWindowViewModel : ModalityWindowPresentationViewModel
    {
        private IProperty _originalProperty;

        /// <summary>
        /// Creates new instance of <see cref="AddPropertyModalityWindowViewModel"/>.
        /// </summary>
        /// <param name="property">Property.</param>
        public AddPropertyModalityWindowViewModel(IProperty property)
        {
            _originalProperty = property;
        }

        /// <summary>
        /// Gets or sets editing property.
        /// </summary>
        public IProperty Property { get; set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            Property = (IProperty)_originalProperty.Clone();

            Property.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Notifies when property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }
    }
}