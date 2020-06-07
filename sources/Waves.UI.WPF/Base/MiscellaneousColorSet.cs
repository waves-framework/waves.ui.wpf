using System;
using System.Windows;

namespace Waves.UI.WPF.Base
{
    /// <summary>
    /// Miscellaneous color set.
    /// </summary>
    public class MiscellaneousColorSet : UI.Services.MiscellaneousColorSet
    {
        /// <summary>
        /// Creates new instance of <see cref="MiscellaneousColorSet"/>.
        /// </summary>
        /// <param name="id">Color set's id.</param>
        /// <param name="name">Color set's name.</param>
        /// <param name="resourceDictionary">Resource dictionary.</param>
        public MiscellaneousColorSet(Guid id, string name, ResourceDictionary resourceDictionary) : base(id, name)
        {
            ResourceDictionary = resourceDictionary;

            InitializeColors();
        }

        /// <summary>
        /// Gets color resource dictionary.
        /// </summary>
        public ResourceDictionary ResourceDictionary { get; private set; }

        /// <summary>
        /// Initializes colors.
        /// </summary>
        private void InitializeColors()
        {
            ColorDictionary.Clear();
            ForegroundColorDictionary.Clear();

            var colorDictionary = Extensions.ResourceDictionary.GetColorsDictionary(ResourceDictionary);
            var foregroundColorDictionary = Extensions.ResourceDictionary.GetForegroundColorsDictionary(ResourceDictionary);

            foreach (var pair in colorDictionary)
                ColorDictionary.Add(pair.Key, pair.Value);

            foreach (var pair in foregroundColorDictionary)
                ForegroundColorDictionary.Add(pair.Key, pair.Value);
        }
    }
}