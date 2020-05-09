using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Extensions;
using Point = Fluid.Core.Base.Point;
using Size = Fluid.Core.Base.Size;

namespace Fluid.UI.Windows.Controls.Drawing.Engines.System.View
{
    /// <summary>
    /// Drawing element.
    /// </summary>
    public class SystemDrawingElement : IDrawingElement
    {
        /// <summary>
        /// Gets or sets SKSurface.
        /// </summary>
        public Canvas Canvas { get; set; }

        /// <inheritdoc />
        public void Dispose()
        {
        }

        /// <inheritdoc />
        public void Draw(object element, ICollection<IDrawingObject> drawingObjects)
        {
            var canvas = element as Canvas;
            if (canvas == null) return;

            if (Canvas == null)
                Canvas = canvas;

            Canvas.Children.Clear();

            foreach (var obj in drawingObjects)
                obj.Draw(this);
        }

        /// <inheritdoc />
        public void DrawEllipse(Point location, float radius, IPaint paint)
        {
            var x = location.X - radius;
            var y = location.Y - radius;

            Canvas.Children.Add(new Ellipse()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(x,y,0,0),
                Width = radius * 2,
                Height = radius * 2,
                Fill = new SolidColorBrush(paint.Fill.ToSystemColor()),
                Stroke = new SolidColorBrush(paint.Stroke.ToSystemColor()),
                StrokeThickness = paint.StrokeThickness,
            });
        }

        /// <inheritdoc />
        public void DrawLine(Point point1, Point point2, IPaint paint)
        {
            Canvas.Children.Add(new Line()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                X1 = point1.X,
                X2 = point2.X,
                Y1 = point1.Y,
                Y2 = point2.Y,
                Fill = new SolidColorBrush(paint.Fill.ToSystemColor()),
                Stroke = new SolidColorBrush(paint.Stroke.ToSystemColor()),
                StrokeThickness = paint.StrokeThickness,
            });
        }

        /// <inheritdoc />
        public void DrawRectangle(Point location, Size size, IPaint paint, float cornerRadius = 0)
        {
            Canvas.Children.Add(new Border()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(location.X, location.Y, 0, 0),
                Width = size.Width,
                Height = size.Height,
                Background = new SolidColorBrush(paint.Fill.ToSystemColor()),
                BorderBrush = new SolidColorBrush(paint.Stroke.ToSystemColor()),
                BorderThickness = new Thickness(paint.StrokeThickness),
                CornerRadius = new CornerRadius(cornerRadius)
            });
        }

        /// <inheritdoc />
        public void DrawText(Point location, string text, ITextPaint paint)
        {
            var textBlock = new TextBlock()
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = text,
                Foreground = new SolidColorBrush(paint.Fill.ToSystemColor()),
                FontSize = paint.TextStyle.FontSize,
                FontFamily = new FontFamily(paint.TextStyle.FontFamily),
                Margin = new Thickness(location.X, location.Y, 0, 0),
                TextAlignment = paint.TextStyle.Alignment.ToSystemTextAlignment()
            };

            textBlock.Measure(new global::System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            textBlock.Arrange(new Rect(0, 0, textBlock.DesiredSize.Width, textBlock.DesiredSize.Height));

            textBlock.Margin = new Thickness(location.X, location.Y - textBlock.ActualHeight,0,0);

            Canvas.Children.Add(textBlock);
        }
    }
}