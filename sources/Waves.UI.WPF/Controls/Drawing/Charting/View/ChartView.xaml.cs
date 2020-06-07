using System;
using System.Windows;
using System.Windows.Controls;
using Waves.Core.Base.Interfaces;
using Waves.UI.Drawing.Charting.View.Interface;
using Waves.UI.Drawing.View.Interfaces;

namespace Waves.UI.WPF.Controls.Drawing.Charting.View
{
    /// <summary>
    ///     Chart view.
    /// </summary>
    public partial class ChartView : IChartView
    {
        /// <summary>
        /// Gets or sets "DrawingElementView".
        /// </summary>
        public static readonly DependencyProperty DrawingElementViewProperty =
            DependencyProperty.Register
            (
                "DrawingElementView",
                typeof(IDrawingElementView),
                typeof(ChartView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        /// <summary>
        /// Gets drawing element view.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Returns Drawing element view.</returns>
        public static IDrawingElementView GetDrawingElementView(DependencyObject obj)
        {
            return (IDrawingElementView)obj.GetValue(DrawingElementViewProperty);
        }

        /// <summary>
        /// Sets drawing element view.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Drawing element view.</param>
        public static void SetDrawingElementView(DependencyObject obj, IDrawingElementView value)
        {
            obj.SetValue(DrawingElementViewProperty, value);
        }

        /// <summary>
        /// Creates new instance of <see cref="ChartView"/>.
        /// </summary>
        public ChartView()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        /// Gets or sets Drawing element view.
        /// </summary>
        public IDrawingElementView DrawingElementView
        {
            get => (IDrawingElementView)GetValue(DrawingElementViewProperty);
            set
            {
                if (value.Equals(DrawingElementView)) return;

                SetValue(DrawingElementViewProperty, value);
            }
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <summary>
        /// Notifies when system message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }
    }
}