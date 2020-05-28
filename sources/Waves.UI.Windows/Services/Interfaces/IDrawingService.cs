using System;
using System.Collections.Generic;
using Waves.Core.Base.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Base.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Presentation.Interfaces;

namespace Waves.UI.Windows.Services.Interfaces
{
    /// <summary>
    /// Interface for drawing service.
    /// </summary>
    public interface IDrawingService : IService
    {
        /// <summary>
        /// Event for engine changed handing.
        /// </summary>
        event EventHandler EngineChanged;

        /// <summary>
        /// Gets collection of engines paths.
        /// </summary>
        List<string> EnginePaths { get; set; }

        /// <summary>
        /// Gets or sets current drawing engine.
        /// </summary>
        IDrawingEngine CurrentEngine { get; set; }

        /// <summary>
        /// Gets collection of available drawing engines.
        /// </summary>
        ICollection<IDrawingEngine> Engines { get; }

        /// <summary>
        ///     Adds path of engines.
        /// </summary>
        /// <param name="path">Path.</param>
        void AddPath(string path);

        /// <summary>
        ///     Removes engines path.
        /// </summary>
        /// <param name="path">Path.</param>
        void RemovePath(string path);

        /// <summary>
        ///     Updates engines collection.
        /// </summary>
        void UpdateEnginesCollection();
    }
}