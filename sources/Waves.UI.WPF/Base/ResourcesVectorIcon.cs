using System;
using System.Windows;
using Waves.Core.Base;
using Waves.UI.Base;

namespace Waves.UI.WPF.Base
{
    /// <summary>
    ///     Vector icon from resources.
    /// </summary>
    public class ResourcesVectorIcon : VectorImage
    {
        private const string DefaultResourceUriSource =
            "pack://application:,,,/Waves.UI.WPF;component/Resources/Icons.xaml";

        /// <summary>
        ///     Creates new instance of <see cref="ResourcesVectorIcon" /> from default icons resource.
        /// </summary>
        /// <param name="key">Key</param>
        public ResourcesVectorIcon(string key)
        {
            Name = key;
            InitializeGeometryFromDefaultResourceDictionary(key);
        }

        /// <summary>
        ///     Creates new instance of <see cref="ResourcesVectorIcon" /> from default icons resource.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="width">Width of icon.</param>
        /// <param name="height">Height of icon.</param>
        public ResourcesVectorIcon(string key, double width, double height)
        {
            Name = key;
            Width = width;
            Height = height;

            InitializeGeometryFromDefaultResourceDictionary(key);
        }

        /// <summary>
        ///     Creates new instance of <see cref="ResourcesVectorIcon" /> from default icons resource.
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="width">Width of icon.</param>
        /// <param name="height">Height of icon.</param>
        /// <param name="padding">Padding for icon.</param>
        public ResourcesVectorIcon(string key, double width, double height, Thickness padding)
        {
            Name = key;
            Width = width;
            Height = height;
            Padding = new[] {padding.Left, padding.Top, padding.Right, padding.Right};

            InitializeGeometryFromDefaultResourceDictionary(key);
        }

        /// <inheritdoc />
        public sealed override string Name { get; set; }

        /// <summary>
        ///     Initializes geometry from default resource dictionary.
        /// </summary>
        private void InitializeGeometryFromDefaultResourceDictionary(string key)
        {
            var resourceDictionary = new ResourceDictionary {Source = new Uri(DefaultResourceUriSource)};

            Paths.Clear();

            Paths.Add(new VectorPath(resourceDictionary[key].ToString(), WavesColor.Black));
        }
    }
}