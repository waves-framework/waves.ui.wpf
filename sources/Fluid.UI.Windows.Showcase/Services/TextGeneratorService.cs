using System;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.Interfaces;
using Fluid.Core.Services;
using Fluid.UI.Windows.Showcase.Services.Interfaces;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Fluid.UI.Windows.Showcase.Services
{
    public class TextGeneratorService : Service, ITextGeneratorService
    {
        private IRandomizerString _randomizer;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("7698A027-EE52-48A9-A6F9-2917A9FA6142");

        /// <inheritdoc />
        public override string Name { get; set; } = "Text generator service";

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            _randomizer = new RandomizerTextLipsum(new FieldOptionsTextLipsum());

            OnMessageReceived(this,
                new Message("Initialization", "Service was initialized.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            //
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            //
        }

        /// <inheritdoc />
        public string GenerateText()
        {
            return _randomizer.Generate();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            _randomizer = null;
        }
    }
}