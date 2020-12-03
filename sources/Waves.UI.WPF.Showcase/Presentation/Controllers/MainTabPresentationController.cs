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
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Main Tab Presenter Controller";

        /// <inheritdoc />
        public override void Initialize()
        {
            try
            {
                var textTabPresentation = new TextTabPresentation(Core);
                textTabPresentation.SetView(new TextTabView());
                RegisterPresenter(textTabPresentation);

                var buttonsTabPresentation = new ButtonsTabPresentation(Core);
                buttonsTabPresentation.SetView(new ButtonsTabView());
                RegisterPresenter(buttonsTabPresentation);

                var comboBoxesTabPresentation = new ComboBoxesTabPresentation(Core);
                comboBoxesTabPresentation.SetView(new ComboBoxesTabView());
                RegisterPresenter(comboBoxesTabPresentation);

                var checkBoxesTabPresentation = new CheckBoxesTabPresentation(Core);
                checkBoxesTabPresentation.SetView(new CheckBoxesTabView());
                RegisterPresenter(checkBoxesTabPresentation);

                var radioButtonsTabPresentation = new RadioButtonsTabPresentation(Core);
                radioButtonsTabPresentation.SetView(new RadioButtonsTabView());
                RegisterPresenter(radioButtonsTabPresentation);

                var textBoxesTabPresentation = new TextBoxesTabPresentation(Core);
                textBoxesTabPresentation.SetView(new TextBoxesTabView());
                RegisterPresenter(textBoxesTabPresentation);

                var listBoxesTabPresentation = new ListBoxesTabPresentation(Core);
                listBoxesTabPresentation.SetView(new ListBoxesTabView());
                RegisterPresenter(listBoxesTabPresentation);

                var progressBarsTabPresentation = new ProgressBarsTabPresentation(Core);
                progressBarsTabPresentation.SetView(new ProgressBarsTabView());
                RegisterPresenter(progressBarsTabPresentation);

                var menusTabPresentation = new MenusTabPresentation(Core);
                menusTabPresentation.SetView(new MenusTabView());
                RegisterPresenter(menusTabPresentation);

                var chartingTabPresentation = new ChartingTabPresentation(Core);
                chartingTabPresentation.SetView(new ChartingTabView());
                RegisterPresenter(chartingTabPresentation);

                //var configurationTabPresentation = new ConfigurationTabPresentation(Core);
                //configurationTabPresentation.SetView(new ConfigurationTabView());
                //RegisterPresentation(configurationTabPresentation);

                var coreTabPresentation = new CoreTabPresentation(Core);
                coreTabPresentation.SetView(new CoreTabView());
                RegisterPresenter(coreTabPresentation);

                var themeTabPresentation = new ThemeTabPresentation(Core);
                themeTabPresentation.SetView(new ThemeTabView());
                RegisterPresenter(themeTabPresentation);

                var aboutTabPresentation = new AboutTabPresentation(Core);
                aboutTabPresentation.SetView(new AboutTabView());
                RegisterPresenter(aboutTabPresentation);

                OnMessageReceived(this,new WavesMessage("Initialization", "Main tab controller initialized.", "Main tab controller", WavesMessageType.Success));

                if (Presenters.Count > 0)
                    SelectedPresenter = Presenters.First();
            }
            catch (Exception e)
            {
                OnMessageReceived(this,new WavesMessage("Initialization", "Error initialization main tab controller:\r\n" + e, "Main tab controller", WavesMessageType.Error));
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}