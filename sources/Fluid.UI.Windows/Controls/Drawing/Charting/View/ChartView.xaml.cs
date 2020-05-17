using System;
using System.Windows;
using System.Windows.Controls;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.View.Interface;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.View
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
                typeof(FrameworkElement),
                typeof(ChartView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
            );

        /// <summary>
        /// Gets drawing element view.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Returns Drawing element view.</returns>
        public static FrameworkElement GetDrawingElementView(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(DrawingElementViewProperty);
        }

        /// <summary>
        /// Sets drawing element view.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Drawing element view.</param>
        public static void SetDrawingElementView(DependencyObject obj, FrameworkElement value)
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
        public FrameworkElement DrawingElementView
        {
            get => (FrameworkElement)GetValue(DrawingElementViewProperty);
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