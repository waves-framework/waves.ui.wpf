using System;
using System.Composition;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Showcase.Common.Services.Interfaces;
using Waves.UI.WPF.Showcase.View.ModalWindow;

namespace Waves.UI.WPF.Showcase.Services
{
    /// <summary>
    /// Configuration windows service.
    /// </summary>
    [Export(typeof(IService))]
    public class ConfigurationWindowsService : Service, IConfigurationWindowsService
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("04B1C0AF-A858-4DBB-BEEF-FA9D1E363CA4");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF Configuration windows service";

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            OnMessageReceived(this,
                new Message("Initialization", "Service was initialized.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <inheritdoc />
        public IPresentationView GetAddPropertyPresentationView()
        {
            return new AddPropertyModalWindowContentView();
        }

        /// <inheritdoc />
        public IPresentationView GetShowPropertyPresentationView()
        {
            return new ShowPropertyModalWindowContentView();
        }

        /// <inheritdoc />
        public IPresentationView GetEditPropertyPresentationView()
        {
            return new EditPropertyModalWindowContentView();
        }
    }
}