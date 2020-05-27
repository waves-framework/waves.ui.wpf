using Waves.Core.Base.Interfaces;
using Waves.Core.Services.Interfaces;

namespace Waves.UI.Windows.Showcase.Services.Interfaces
{
    /// <summary>
    /// Interface for text generator.
    /// </summary>
    public interface ITextGeneratorService : IService
    {
        /// <summary>
        /// Generates text.
        /// </summary>
        /// <returns>Generated text.</returns>
        string GenerateText();

        /// <summary>
        /// Generates word.
        /// </summary>
        /// <returns>Generated word.</returns>
        string GenerateWord();
    }
}