using System;
using System.Composition;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;
using Waves.Presentation.Interfaces;
using Waves.UI.Showcase.Common.Services.Interfaces;
using Waves.UI.WPF.Showcase.View.ModalWindow;

namespace Waves.UI.WPF.Showcase.Services
{
    /// <summary>
    /// Configuration windows service.
    /// </summary>
    [Export(typeof(IWavesService))]
    public class ConfigurationWindowsService : WavesService, IConfigurationWindowsService
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("04B1C0AF-A858-4DBB-BEEF-FA9D1E363CA4");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF Configuration windows service";

        /// <inheritdoc />
        public override void Initialize(IWavesCore core)
        {
            if (IsInitialized) return;

            Core = core;

            OnMessageReceived(this,
                new WavesMessage("Initialization", "Service was initialized.", Name, WavesMessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration()
        {
        }

        /// <inheritdoc />
        public override void SaveConfiguration()
        {
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <inheritdoc />
        public IPresenterView GetAddPropertyPresentationView()
        {
            return new AddPropertyModalWindowContentView();
        }

        /// <inheritdoc />
        public IPresenterView GetShowPropertyPresentationView()
        {
            return new ShowPropertyModalWindowContentView();
        }

        /// <inheritdoc />
        public IPresenterView GetEditPropertyPresentationView()
        {
            return new EditPropertyModalWindowContentView();
        }
    }
}