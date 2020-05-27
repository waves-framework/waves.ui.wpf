using System;
using System.Windows;
using System.Windows.Media;
using Waves.Core.Base;
using Waves.UI.Windows.Base.Interfaces;

namespace Waves.UI.Windows.Base
{
    /// <summary>
    /// Vector icon from resources.
    /// </summary>
    public class ResourcesVectorIcon : ObservableObject, IVectorIcon
    {
        private const string DefaultResourceUriSource = "pack://application:,,,/Waves.UI.Windows;component/Resources/Icons.xaml";

        /// <summary>
        /// Creates new instance of <see cref="ResourcesVectorIcon"/> from default icons resource. 
        /// </summary>
        /// <param name="key">Key</param>
        public ResourcesVectorIcon(string key)
        {
            Name = key;
            InitializeGeometryFromDefaultResourceDictionary(key);
        }

        /// <summary>
        /// Creates new instance of <see cref="ResourcesVectorIcon"/> from default icons resource. 
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
        /// Creates new instance of <see cref="ResourcesVectorIcon"/> from default icons resource. 
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
            Padding = padding;

            InitializeGeometryFromDefaultResourceDictionary(key);
        }

        /// <inheritdoc />
        public string Name { get; private set; }

        /// <inheritdoc />
        public Geometry PathData { get; private set; }

        /// <inheritdoc />
        public double Width { get; private set; } = 14;

        /// <inheritdoc />
        public double Height { get; private set; } = 14;

        /// <inheritdoc />
        public Thickness Padding { get; } = new Thickness();

        /// <summary>
        /// Initializes geometry from default resource dictionary.
        /// </summary>
        private void InitializeGeometryFromDefaultResourceDictionary(string key)
        {
            var resourceDictionary = new ResourceDictionary() { Source = new Uri(DefaultResourceUriSource) };
            PathData = (Geometry)resourceDictionary[key];
        }
    }
}