using System.Windows;
using Waves.Presentation.Interfaces;
using Waves.UI.WPF.Showcase.View.Control.Tabs;
using Waves.UI.WPF.Showcase.ViewModel.Tabs;

namespace Waves.UI.WPF.Showcase.Presentation.Tabs
{
    /// <summary>
    /// Theme tab presentation.
    /// </summary>
    public class ThemeTabPresentation : TabBasePresentation
    {
        /// <inheritdoc />
        public override string Name { get; } = "Theme";

        /// <inheritdoc />
        public override string VectorIconPathData { get; } =
            "M12.714,2.025C6.629,1.603,1.603,6.628,2.025,12.713C2.392,18.002,7.006,22,12.307,22H13c1.105,0,2-0.895,2-2v-3 c0-1.105,0.895-2,2-2h3c1.105,0,2-0.895,2-2v-0.693C22,7.006,18.002,2.392,12.714,2.025z M10.5,4C11.328,4,12,4.672,12,5.5 S11.328,7,10.5,7S9,6.328,9,5.5S9.672,4,10.5,4z M5.5,15C4.672,15,4,14.328,4,13.5S4.672,12,5.5,12S7,12.672,7,13.5 S6.328,15,5.5,15z M6.5,10C5.672,10,5,9.328,5,8.5S5.672,7,6.5,7S8,7.672,8,8.5S7.328,10,6.5,10z M11,20c-1.105,0-2-0.895-2-2 c0-1.105,0.895-2,2-2s2,0.895,2,2C13,19.105,12.105,20,11,20z M15.5,8C14.672,8,14,7.328,14,6.5S14.672,5,15.5,5S17,5.672,17,6.5 S16.328,8,15.5,8z M18.5,13c-0.828,0-1.5-0.672-1.5-1.5s0.672-1.5,1.5-1.5s1.5,0.672,1.5,1.5S19.328,13,18.5,13z";

        /// <inheritdoc />
        public override Thickness VectorIconThickness { get; } = new Thickness(0, -2, 0, 0);

        /// <inheritdoc />
        public override IPresentationView View { get; } = new ThemeTabView();

        /// <inheritdoc />
        public override IPresentationViewModel DataContext { get; } = new ThemeTabViewModel();
    }
}