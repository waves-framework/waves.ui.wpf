using System.Collections.ObjectModel;
using Waves.Presentation.Base;
using Waves.UI.Windows.Showcase.Model;
using Waves.UI.Windows.Showcase.Services.Interfaces;

namespace Waves.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Listboxes tab view model.
    /// </summary>
    public class ListBoxesTabViewModel : PresentationViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <summary>
        /// Gets or sets selected item.
        /// </summary>
        public Item SelectedItem { get; set; }

        /// <summary>
        /// Gets items.
        /// </summary>
        public ObservableCollection<Item> Items { get; private set; } = new ObservableCollection<Item>();

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
            Items.Clear();

            for (var i = 0; i < 12; i++)
            {
                Items.Add(new Item(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText()));
            }
        }
    }
}