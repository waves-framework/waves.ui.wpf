using System;
using System.Composition;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Drawing.Charting.Base.Interfaces;
using Waves.UI.Drawing.Charting.Services.Interfaces;
using Waves.UI.WPF.Controls.Drawing.Factories;

namespace Waves.UI.WPF.Services
{
    /// <summary>
    /// Charting service.
    /// </summary>
    [Export(typeof(IWavesService))]
    public class ChartingService : WavesService, IChartingService
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("3C41CD51-3645-47A8-AE90-A9E785CC3901");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF Charting Service";

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
        public IChartViewFactory GetChartViewFactory()
        {
            return new ChartViewFactory();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}