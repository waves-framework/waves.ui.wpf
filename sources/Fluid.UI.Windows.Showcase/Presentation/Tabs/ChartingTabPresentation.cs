using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Showcase.View.Control.Tabs;
using Fluid.UI.Windows.Showcase.ViewModel.Tabs;

namespace Fluid.UI.Windows.Showcase.Presentation.Tabs
{
    /// <summary>
    /// About tab presentation.
    /// </summary>
    public class ChartingTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Charts";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M5 3C4.476563 3 3.941406 3.183594 3.5625 3.5625C3.183594 3.941406 3 4.476563 3 5L3 19C3 19.523438 3.183594 20.058594 3.5625 20.4375C3.941406 20.816406 4.476563 21 5 21L19 21C19.523438 21 20.058594 20.816406 20.4375 20.4375C20.816406 20.058594 21 19.523438 21 19L21 5C21 4.476563 20.816406 3.941406 20.4375 3.5625C20.058594 3.183594 19.523438 3 19 3 Z M 5 5L19 5L19 15L16.6875 15L15.4375 11.65625C15.292969 11.265625 14.917969 11.003906 14.5 11.003906C14.082031 11.003906 13.707031 11.265625 13.5625 11.65625L12.3125 15L11.3125 15L9.96875 7.8125C9.875 7.296875 9.394531 6.941406 8.875 7C8.449219 7.0625 8.109375 7.386719 8.03125 7.8125L6.6875 15L5 15 Z M 9 13.34375L9.53125 16.1875C9.621094 16.652344 10.023438 16.992188 10.5 17L13 17C13.417969 17 13.792969 16.738281 13.9375 16.34375L14.5 14.84375L15.0625 16.34375C15.207031 16.738281 15.582031 17 16 17L19 17L19 19L5 19L5 17L7.5 17C7.976563 16.992188 8.378906 16.652344 8.46875 16.1875Z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, 0, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ChartingTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ChartingTabViewModel();
    }
}
