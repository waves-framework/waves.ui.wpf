using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Fluid.Core.Base;
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
                SubscribeEvents();

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
        /// Subscribe events.
        /// </summary>
        private void SubscribeEvents()
        {
            DispatcherUnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;
        }

        /// <summary>
        /// Notifies when unhandled exception received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Core.WriteLogMessage(new Message(e.Exception, true));
        }

        /// <summary>
        /// Notifies when unhandled exception received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Core.WriteLogMessage(new Message(e.Exception, true));
        }

        /// <summary>
        /// Actions when controller's message received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Message.</param>
        private void OnControllerMessageReceived(object sender, Fluid.Core.Base.Interfaces.IMessage e)
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