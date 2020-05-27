using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Waves.Core.Base;
using Waves.UI.Windows.Showcase.Presentation.Controllers;
using Waves.UI.Windows.Showcase.Services;
using Waves.UI.Windows.Showcase.Services.Interfaces;
using Waves.UI.Windows.Showcase.View.Window;
using Waves.UI.Windows.Showcase.ViewModel;

namespace Waves.UI.Windows.Showcase
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

                var controller = new MainTabPresentationController();
                controller.MessageReceived += OnControllerMessageReceived;
                controller.Initialize();

                var view = new MainWindowView { DataContext = controller };
                view.Show();

                Core.AttachMainWindow(view);

                view.Closing += OnViewClosing;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// Actions when controller's message received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Message.</param>
        private void OnControllerMessageReceived(object sender, Waves.Core.Base.Interfaces.IMessage e)
        {
            Core.WriteLogMessage(e);
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