using System;
using System.Collections.Generic;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Presentation.Interfaces;

namespace Fluid.UI.Windows.Drawing.Services.Interfaces
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
        /// Creates presentation.
        /// </summary>
        /// <returns>Drawing element presentation.</returns>
        IDrawingElementPresentation CreatePresentation();

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