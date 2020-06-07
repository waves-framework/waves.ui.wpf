using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Waves.Presentation.Interfaces;
using Waves.UI.WPF.Showcase.View.Control.Tabs;
using Waves.UI.WPF.Showcase.ViewModel.Tabs;

namespace Waves.UI.WPF.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Configuration tab presentation.
    /// </summary>
    public class ConfigurationTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Configuration";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M6 2C4.9 2 4 2.9 4 4L4 20C4 21.1 4.9 22 6 22L12.039062 22C12.128063 21.357 12.411906 20.759969 12.878906 20.292969L14.099609 19.072266C14.033609 18.719266 14 18.361 14 18C14 14.691 16.691 12 20 12L20 8L14 2L6 2 z M 13 3.5L18.5 9L13 9L13 3.5 z M 20 14C17.791 14 16 15.791 16 18C16 18.586 16.132375 19.139625 16.359375 19.640625L14.292969 21.707031C13.901969 22.098031 13.901969 22.731094 14.292969 23.121094L14.878906 23.707031C15.268906 24.098031 15.901969 24.098031 16.292969 23.707031L18.359375 21.640625C18.860375 21.867625 19.414 22 20 22C22.209 22 24 20.209 24 18C24 17.414 23.867625 16.860375 23.640625 16.359375L21 19L19 17L21.640625 14.359375C21.139625 14.132375 20.586 14 20 14 z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, -2, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ConfigurationTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ConfigurationTabViewModel();
    }
}
