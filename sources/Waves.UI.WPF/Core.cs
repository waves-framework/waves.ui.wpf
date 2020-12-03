using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.UI.Modality.Presentation.Controllers.Interfaces;
using Waves.UI.Modality.Presentation.Interfaces;
using Waves.UI.Services.Interfaces;
using Waves.UI.WPF.Controls.Modality.Presentation.Controllers;
using Waves.UI.WPF.Controls.Modality.View;
using Waves.UI.WPF.Services;
using Application = System.Windows.Application;

namespace Waves.UI.WPF
{
    /// <summary>
    ///     UI Core.
    /// </summary>
    public class Core : UI.Core
    {
        /// <summary>
        ///     Gets instance of attached application.
        /// </summary>
        public Application Application { get; private set; }

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
        ///     Attaches main window.
        /// </summary>
        public void AttachMainWindow(Window window)
        {
            Application.MainWindow = window;

            if (!(Application.MainWindow?.Content is Grid grid)) return;

            ModalWindowController = new ModalWindowsPresentationController(this);
            var controllerView = new ModalWindowPresentationControllerView {DataContext = ModalWindowController };

            ModalWindowController.PropertyChanged += delegate(object sender, PropertyChangedEventArgs args)
            {
                if (args.PropertyName == "IsVisible") grid.Children[0].IsEnabled = !ModalWindowController.IsVisible;
            };

            ModalWindowController.Initialize();

            grid.Children.Add(controllerView);
        }

        /// <summary>
        ///     Initializes UI Core.
        /// </summary>
        protected override void Initialize()
        {
            InitializeServices();
        }

        /// <summary>
        ///     Initializes UI core base services.
        /// </summary>
        private void InitializeServices()
        {
            InitializeThemeService();
        }

        /// <summary>
        ///     Initializes theme service.
        /// </summary>
        private void InitializeThemeService()
        {
            var service = GetInstance<IThemeService>() as ThemeService;

            if (service == null)
                WriteLog(
                    new WavesMessage("Service", "Theme service is not initialized.", "UI Core", WavesMessageType.Fatal));
            else
                service.AttachApplication(Application);
        }

        /// <summary>
        ///     Notifies when unhandled exception received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            WriteLog(new WavesMessage(e.Exception, true));
        }

        /// <summary>
        ///     Notifies when unhandled exception received.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnTaskSchedulerUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            WriteLog(new WavesMessage(e.Exception, true));
        }
    }
}