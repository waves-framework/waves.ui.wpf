using System.Collections.ObjectModel;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Showcase.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Comboboxes tab view model.
    /// </summary>
    public class ComboBoxesTabViewModel : PresentationViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <summary>
        /// Gets words collection.
        /// </summary>
        public ObservableCollection<string> Words { get; set; } = new ObservableCollection<string>();

        /// <inheritdoc />
        public override void Initialize()
        {
            _textGeneratorService = App.Core.GetService<ITextGeneratorService>();

            GenerateData();
        }

        /// <summary>
        /// Generates data.
        /// </summary>
        private void GenerateData()
        {
            for (var i = 0; i < 10; i++)
            {
                Words.Add(_textGeneratorService.GenerateWord());
            }
        }
    }
}