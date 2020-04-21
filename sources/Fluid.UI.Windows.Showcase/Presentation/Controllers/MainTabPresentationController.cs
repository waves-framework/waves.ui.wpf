using System;
using System.Linq;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
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
            try
            {
                RegisterPresentation(new TextTabPresentation());
                RegisterPresentation(new ButtonsTabPresentation());
                RegisterPresentation(new ComboBoxesTabPresentation());
                RegisterPresentation(new CheckBoxesTabPresentation());
                RegisterPresentation(new TextBoxesTabPresentation());
                RegisterPresentation(new ListBoxesTabPresentation());
                RegisterPresentation(new ProgressBarsTabPresentation());
                RegisterPresentation(new MenusTabPresentation());
                RegisterPresentation(new CoreTabPresentation());
                RegisterPresentation(new ThemeTabPresentation());
                RegisterPresentation(new AboutTabPresentation());

                OnMessageReceived(new Message("Initialization", "Main tab controller initialized.", "Main tab controller", MessageType.Success));

                if (Presentations.Count > 0)
                    SelectedPresentation = Presentations.First();
            }
            catch (Exception e)
            {
                OnMessageReceived(new Message("Initialization", "Error initialization main tab controller:\r\n" + e, "Main tab controller", MessageType.Error));
            }
        }
    }
}