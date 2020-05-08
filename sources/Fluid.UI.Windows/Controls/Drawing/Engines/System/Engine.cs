using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Engines.System.View;
using Fluid.UI.Windows.Controls.Drawing.Engines.System.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Engines.System
{
    /// <summary>
    /// Engine.
    /// </summary>
    [Export(typeof(IDrawingEngine))]
    public class Engine : IDrawingEngine
    {
        /// <inheritdoc />
        public string Name => "System";

        /// <inheritdoc />
        public IDrawingElementView GetView()
        {
            return new DrawingElementPresentationView();
        }

        /// <inheritdoc />
        public IDrawingElementViewModel GetViewModel()
        {
            return new DrawingElementPresentationViewModel();
        }
    }
}
