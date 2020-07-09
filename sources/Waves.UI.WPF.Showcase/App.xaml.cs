using System;
using System.ComponentModel;
using System.Windows;
using Waves.Core.Base.Interfaces;
using Waves.UI.Showcase.Common.Services;
using Waves.UI.Showcase.Common.Services.Interfaces;
using Waves.UI.WPF.Showcase.Presentation.Controllers;
using Waves.UI.WPF.Showcase.View.Window;

namespace Waves.UI.WPF.Showcase
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

                var controller = new MainTabPresentationController(Core);

                controller.MessageReceived += OnControllerMessageReceived;
                controller.Initialize();

                var view = new MainWindowView {DataContext = controller};

                view.Show();

                Core.AttachMainWindow(view);

                view.Closing += OnViewClosing;

                Core.AddMessageSeparator();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        ///     Actions when controller's message received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Message.</param>
        private void OnControllerMessageReceived(object sender, IMessage e)
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