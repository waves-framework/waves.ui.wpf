using System;
using System.Linq;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.UI.Showcase.Common.Presentation.Tabs;
using Waves.UI.WPF.Showcase.View.Control.Tabs;

namespace Waves.UI.WPF.Showcase.Presentation.Controllers
{
    /// <summary>
    /// Main tab presentation controller.
    /// </summary>
    public class MainTabPresentationController : Waves.UI.Showcase.Common.Presentation.Controllers.MainTabPresentationController
    {
        /// <inheritdoc />
        public MainTabPresentationController(UI.Core core) : base(core)
        {
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            try
            {
                var textTabPresentation = new TextTabPresentation(Core);
                textTabPresentation.SetView(new TextTabView());
                RegisterPresentation(textTabPresentation);

                var buttonsTabPresentation = new ButtonsTabPresentation(Core);
                buttonsTabPresentation.SetView(new ButtonsTabView());
                RegisterPresentation(buttonsTabPresentation);

                var comboBoxesTabPresentation = new ComboBoxesTabPresentation(Core);
                comboBoxesTabPresentation.SetView(new ComboBoxesTabView());
                RegisterPresentation(comboBoxesTabPresentation);

                var checkBoxesTabPresentation = new CheckBoxesTabPresentation(Core);
                checkBoxesTabPresentation.SetView(new CheckBoxesTabView());
                RegisterPresentation(checkBoxesTabPresentation);

                var radioButtonsTabPresentation = new RadioButtonsTabPresentation(Core);
                radioButtonsTabPresentation.SetView(new RadioButtonsTabView());
                RegisterPresentation(radioButtonsTabPresentation);

                var textBoxesTabPresentation = new TextBoxesTabPresentation(Core);
                textBoxesTabPresentation.SetView(new TextBoxesTabView());
                RegisterPresentation(textBoxesTabPresentation);

                var listBoxesTabPresentation = new ListBoxesTabPresentation(Core);
                listBoxesTabPresentation.SetView(new ListBoxesTabView());
                RegisterPresentation(listBoxesTabPresentation);

                var progressBarsTabPresentation = new ProgressBarsTabPresentation(Core);
                progressBarsTabPresentation.SetView(new ProgressBarsTabView());
                RegisterPresentation(progressBarsTabPresentation);

                var menusTabPresentation = new MenusTabPresentation(Core);
                menusTabPresentation.SetView(new MenusTabView());
                RegisterPresentation(menusTabPresentation);

                var chartingTabPresentation = new ChartingTabPresentation(Core);
                chartingTabPresentation.SetView(new ChartingTabView());
                RegisterPresentation(chartingTabPresentation);

                //var configurationTabPresentation = new ConfigurationTabPresentation(Core);
                //configurationTabPresentation.SetView(new ConfigurationTabView());
                //RegisterPresentation(configurationTabPresentation);

                var coreTabPresentation = new CoreTabPresentation(Core);
                coreTabPresentation.SetView(new CoreTabView());
                RegisterPresentation(coreTabPresentation);

                var themeTabPresentation = new ThemeTabPresentation(Core);
                themeTabPresentation.SetView(new ThemeTabView());
                RegisterPresentation(themeTabPresentation);

                var aboutTabPresentation = new AboutTabPresentation(Core);
                aboutTabPresentation.SetView(new AboutTabView());
                RegisterPresentation(aboutTabPresentation);

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