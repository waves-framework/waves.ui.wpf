using System.Linq;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Showcase.Presentation.Tabs;

namespace Fluid.UI.Windows.Showcase.Presentation.Controllers
{
    /// <summary>
    /// Main Tabs presentation controller.
    /// </summary>
    public class MainTabPresentationController : PresentationController
    {
        /// <inheritdoc />
        public override void Initialize()
        {
            Presentations.Add(new TextTabPresentation());
            Presentations.Add(new ButtonsTabPresentation());
            Presentations.Add(new ComboBoxesTabPresentation());
            Presentations.Add(new CheckBoxesTabPresentation());
            Presentations.Add(new TextBoxesTabPresentation());
            Presentations.Add(new ThemeTabPresentation());
            Presentations.Add(new AboutTabPresentation());

            foreach (var presentation in Presentations)
            {
                presentation.Initialize();
            }

            if (Presentations.Count > 0)
                SelectedPresentation = Presentations.First();
        }
    }
}