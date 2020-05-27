using System;
using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Base.Interfaces;
using Waves.Core.Services;
using Waves.UI.Windows.Showcase.Services.Interfaces;
using RandomDataGenerator.FieldOptions;
using RandomDataGenerator.Randomizers;

namespace Waves.UI.Windows.Showcase.Services
{
    public class TextGeneratorService : Service, ITextGeneratorService
    {
        private IRandomizerString _loremIpsumRandomizer;
        private IRandomizerString _wordRandomizer;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("7698A027-EE52-48A9-A6F9-2917A9FA6142");

        /// <inheritdoc />
        public override string Name { get; set; } = "Text generator service";

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            _loremIpsumRandomizer = new RandomizerTextLipsum(new FieldOptionsTextLipsum());
            _wordRandomizer = new RandomizerTextWords(new FieldOptionsTextWords() {Max = 1});

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
            return _loremIpsumRandomizer.Generate();
        }

        /// <inheritdoc />
        public string GenerateWord()
        {
            return _wordRandomizer.Generate();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            _loremIpsumRandomizer = null;
        }
    }
}