using System;
using System.Collections;
using System.Composition;
using System.Windows.Data;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Core.Base.Interfaces.Services;
using Waves.UI.Services.Interfaces;

namespace Waves.UI.WPF.Services
{
    /// <summary>
    /// WPF Collection Synchronization Service.
    /// </summary>
    [Export(typeof(IWavesService))]
    public class CollectionSynchronizationService : WavesService, ICollectionSynchronizationService
    {
        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("9BD5E3AD-28BE-42A4-8FF3-5EEF35DACBAF");

        /// <inheritdoc />
        public override string Name { get; set; } = "WPF Collection Synchronization Service";

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
        public void EnableCollectionSynchronization(IEnumerable collection, object locker)
        {
            BindingOperations.EnableCollectionSynchronization(collection, locker);
        }

        /// <inheritdoc />
        public void DisableCollectionSynchronization(IEnumerable collection)
        {
            BindingOperations.DisableCollectionSynchronization(collection);
        }
    }
}