using System;
using System.ComponentModel;
using System.Windows;
using Fluid.UI.Windows.Showcase.Presentation.Controllers;
using Fluid.UI.Windows.Showcase.Services;
using Fluid.UI.Windows.Showcase.Services.Interfaces;
using Fluid.UI.Windows.Showcase.View.Window;
using Fluid.UI.Windows.Showcase.ViewModel;

namespace Fluid.UI.Windows.Showcase
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        ///     Gets UI Core.
        /// </summary>
        public static Core Core { get; } = new Core();

        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Core.Start(Current);
                Core.RegisterService<ITextGeneratorService>(new TextGeneratorService());

                var presentation = new MainTabPresentationController();
                presentation.Initialize();

                var view = new MainWindowView {DataContext = presentation};
                view.Show();

                view.Closing += OnViewClosing;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        ///     Actions when main view closing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnViewClosing(object sender, CancelEventArgs e)
        {
            Core.Stop();
        }
    }
}