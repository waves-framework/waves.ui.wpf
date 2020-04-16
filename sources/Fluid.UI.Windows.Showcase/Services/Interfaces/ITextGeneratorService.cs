using Fluid.Core.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.Services.Interfaces
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