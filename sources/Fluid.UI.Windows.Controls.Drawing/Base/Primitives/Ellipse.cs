using System.ComponentModel;
using Fluid.Core.Base;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Base.Primitives
{
    /// <summary>
    /// Ellipse.
    /// </summary>
    public class Ellipse : PrimitiveDrawingObject
    { 
        /// <summary>
        /// Gets or sets ellipse radius.
        /// </summary>
        public float Radius { get; set; }

        /// <inheritdoc />
        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override string Name { get; set; } = "Ellipse";

        /// <inheritdoc />
        public override Size Size { get; }

        /// <inheritdoc />
        public override void Draw(SKCanvas canvas)
        {
                
        }
    }
}