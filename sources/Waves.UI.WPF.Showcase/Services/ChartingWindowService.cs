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
    /// Charting window service.
    /// </summary>
    [Export(typeof(IWavesService))]
    public class ChartingWindowService : WavesService, IChartingWindowService
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("996567A8-EB59-4F84-BD24-8FAAD4D69945");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF Charting windows service";

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
        public IPresenterView GetEditChartWindow()
        {
            return new EditChartModalWindowContentView();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}