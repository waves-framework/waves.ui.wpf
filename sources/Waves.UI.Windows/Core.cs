using System;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Windows.Base;
using Waves.UI.Windows.Base.Interfaces;
using Waves.UI.Windows.Controls.Modality.Presentation.Controllers;
using Waves.UI.Windows.Controls.Modality.Presentation.Controllers.Interfaces;
using Waves.UI.Windows.Controls.Modality.Presentation.Interfaces;
using Waves.UI.Windows.Controls.Modality.View;
using Waves.UI.Windows.Services.Interfaces;
using Application = System.Windows.Application;

namespace Waves.UI.Windows
{
    /// <summary>
    ///     UI Core.
    /// </summary>
    public class Core : Waves.Core.Core
    {
        private IModalWindowsPresentationController _modalityWindowController;

        /// <summary>
        ///     Gets whether UI Core is initialized.
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        ///     Gets instance of attached application.
        /// </summary>
        public Application Application { get; private set; }

        /// <inheritdoc />
        public override void Start()
        {
            try
            {
                base.Start();

                WriteLogMessage(
                    new Message("UI Core launch", "UI Core is launching...", "UI Core", MessageType.Information));

                Initialize();

                IsInitialized = true;

                WriteLogMessage(
                    new Message("UI Core launch", "UI Core launched successfully.", "UI Core", MessageType.Success));

                AddMessageSeparator();
            }
            catch (Exception ex)
            {
                WriteLogException(ex, "UI Core launch", true);
            }
        }

        /// <summary>
        ///     Starts UI core.
        /// </summary>
        /// <param name="application">Application instance.</param>
        public void Start(Application application)
        {
            Application = application;

            Application.DispatcherUnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnTaskSchedulerUnobservedTaskException;

            Start();
        }

        /// <summary>
        /// Attaches main window.
        /// </summary>
        public void AttachMainWindow(Window window)
        {
            Application.MainWindow = window;

            if (!(Application.MainWindow?.Content is Grid grid)) return;

            _modalityWindowController = new ModalWindowsPresentationController();
            var controllerView = new ModalWindowPresentationControllerView() { DataContext = _modalityWindowController };

            _modalityWindowController.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
            {
                if (args.PropertyName == "IsVisible")
                {
                    grid.Children[0].IsEnabled = !_modalityWindowController.IsVisible;
                }
            };

            _modalityWindowController.Initialize();

            grid.Children.Add(controllerView);
        }

        /// <summary>
        /// Shows modality window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        public void ShowModalityWindow(IModalWindowPresentation presentation)
        {
            _modalityWindowController?.ShowWindow(presentation);
        }

        /// <summary>
        /// Hides modality window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        public void HideModalityWindow(IModalWindowPresentation presentation)
        {
            _modalityWindowController?.HideWindow(presentation);
        }

        /// <inheritdoc />
        public override void WriteLogMessage(IMessage message)
        {
            if (message.Type == MessageType.Fatal)
            {
                // TODO: fatal error handling.
            }

            base.WriteLogMessage(message);
        }

        /// <inheritdoc />
        public override void WriteLogException(Exception ex, string sender, bool isFatal)
        {
            if (isFatal)
            {
                // TODO: fatal error handling.
            }

            base.WriteLogException(ex, sender, isFatal);
        }

        /// <summary>
        ///     Initializes UI Core.
        /// </summary>
        private void Initialize()
        {
            InitializeServices();
        }

        /// <summary>
        ///     Initializes UI core base services.
        /// </summary>
        private void InitializeServices()
        {
            try
            {
                var service = ServiceManager.GetService<IThemeService>().First();
                RegisterService(service);
                InitializeThemeService();
            }
            catch (Exception e)
            {
                WriteLogMessage(new Message("Registering logging service", "Error registering theme service.", "UI Core", e, true));
            }

            try
            {
                var service = ServiceManager.GetService<IDrawingService>().First();
                RegisterService(service);
            }
            catch (Exception e)
            {
                WriteLogMessage(new Message("Registering drawing service", "Error registering drawing service service.", "UI Core", e, true));
            }
        }

        /// <summary>
        /// Initializes theme service.
        /// </summary>
        private void InitializeThemeService()
        {
            var service = GetService<IThemeService>();

            if (service == null)
                WriteLogMessage(
                    new Message("Service", "Theme service is not initialized.", "UI Core", MessageType.Fatal));
            else
                service.AttachApplication(Application);
        }

        /// <summary>
        /// Notifies when unhandled exception received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            WriteLogMessage(new Message(e.Exception, true));
        }

        /// <summary>
        /// Notifies when unhandled exception received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            WriteLogMessage(new Message(e.Exception, true));
        }
    }
}