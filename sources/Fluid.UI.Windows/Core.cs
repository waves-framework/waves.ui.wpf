using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;
using Application = System.Windows.Application;
using ModalityWindowsPresentationControllerView = Fluid.UI.Windows.View.ModalityWindow.ModalityWindowsPresentationControllerView;

namespace Fluid.UI.Windows
{
    /// <summary>
    ///     UI Core.
    /// </summary>
    public class Core : Fluid.Core.Core
    {
        private IModalityWindowsPresentationController _modalityWindowController;

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

                Initialize();

                IsInitialized = true;

                WriteLogMessage(
                    new Message("UI Core", "UI Core launched successfully.", "UI Core", MessageType.Success));
            }
            catch (Exception ex)
            {
                WriteLogException(ex, "UI.Core", true);
            }
        }

        /// <summary>
        ///     Starts UI core.
        /// </summary>
        /// <param name="application">Application instance.</param>
        public void Start(Application application)
        {
            Application = application;

            Start();
        }

        /// <summary>
        /// Attaches main window.
        /// </summary>
        public void AttachMainWindow(Window window)
        {
            Application.MainWindow = window;

            if (!(Application.MainWindow?.Content is Grid grid)) return;

            _modalityWindowController = new ModalityWindowsPresentationController();
            var controllerView = new ModalityWindowsPresentationControllerView() { DataContext = _modalityWindowController };

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
        public void ShowModalityWindow(IModalityWindowPresentation presentation)
        {
            _modalityWindowController?.ShowWindow(presentation);
        }

        /// <summary>
        /// Hides modality window.
        /// </summary>
        /// <param name="presentation">Presentation.</param>
        public void HideModalityWindow(IModalityWindowPresentation presentation)
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
            RegisterService(ServiceManager.GetService<IThemeService>().First());

            InitializeThemeService();
        }

        private void InitializeThemeService()
        {
            var service = GetService<IThemeService>();

            if (service == null)
                WriteLogMessage(
                    new Message("Service", "Theme Service is not initialized", "UI Core", MessageType.Fatal));
            else
                service.AttachApplication(Application);
        }
    }
}