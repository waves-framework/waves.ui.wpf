using System;
using System.Linq;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Presentation.Base;
using Waves.UI.Windows.Showcase.Presentation.Tabs;

namespace Waves.UI.Windows.Showcase.Presentation.Controllers
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
                RegisterPresentation(new RadioButtonsTabPresentation());
                RegisterPresentation(new TextBoxesTabPresentation());
                RegisterPresentation(new ListBoxesTabPresentation());
                RegisterPresentation(new ProgressBarsTabPresentation());
                RegisterPresentation(new MenusTabPresentation());
                RegisterPresentation(new ChartingTabPresentation());
                RegisterPresentation(new ConfigurationTabPresentation());
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