using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Waves.Core.Base;
using Waves.UI.Drawing.Base.Interfaces;
using Waves.UI.WPF.Extensions;

namespace Waves.UI.WPF.Controls.Drawing.Engines.System.View
{
    /// <summary>
    ///     Drawing element.
    /// </summary>
    public class SystemDrawingElement : WavesObject, IDrawingElement
    {
        /// <summary>
        ///     Gets or sets drawing canvas.
        /// </summary>
        public Canvas Canvas { get; set; }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; }

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
        public void DrawEllipse(WavesPoint location, float radius, IPaint paint)
        {
            var x = location.X - radius;
            var y = location.Y - radius;

            Canvas.Children.Add(new Ellipse
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(x, y, 0, 0),
                Width = radius * 2,
                Height = radius * 2,
                Fill = new SolidColorBrush(paint.Fill.ToSystemColor()),
                Stroke = new SolidColorBrush(paint.Stroke.ToSystemColor()),
                StrokeThickness = paint.StrokeThickness,
                Opacity = paint.Opacity
            });
        }

        /// <inheritdoc />
        public void DrawLine(WavesPoint point1, WavesPoint point2, IPaint paint)
        {
            var dashPattern = new DoubleCollection();

            if (paint.DashPattern != null && paint.DashPattern.Length == 4)
            {
                dashPattern = new DoubleCollection()
                {
                    paint.DashPattern[0],
                    paint.DashPattern[1],
                    paint.DashPattern[2],
                    paint.DashPattern[3],
                };
            }

            Canvas.Children.Add(new Line
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
                StrokeDashArray = dashPattern,
                Opacity = paint.Opacity
            });
        }

        /// <inheritdoc />
        public void DrawRectangle(WavesPoint location, WavesSize size, IPaint paint, float cornerRadius = 0)
        {
            if (size.Width < 0 || size.Height < 0) return;

            Canvas.Children.Add(new Border
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(location.X, location.Y, 0, 0),
                Width = size.Width,
                Height = size.Height,
                Background = new SolidColorBrush(paint.Fill.ToSystemColor()),
                BorderBrush = new SolidColorBrush(paint.Stroke.ToSystemColor()),
                BorderThickness = new Thickness(paint.StrokeThickness),
                CornerRadius = new CornerRadius(cornerRadius),
                Opacity = paint.Opacity
            });
        }

        /// <inheritdoc />
        public void DrawText(WavesPoint location, string text, ITextPaint paint)
        {
            var textBlock = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = text,
                Foreground = new SolidColorBrush(paint.Fill.ToSystemColor()),
                FontSize = paint.TextStyle.FontSize,
                FontFamily = new FontFamily(paint.TextStyle.FontFamily),
                Margin = new Thickness(location.X, location.Y, 0, 0),
                TextAlignment = paint.TextStyle.Alignment.ToSystemTextAlignment(),
                Opacity = paint.Opacity
            };

            textBlock.Measure(new global::System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            textBlock.Arrange(new Rect(0, 0, textBlock.DesiredSize.Width, textBlock.DesiredSize.Height));

            textBlock.Margin = new Thickness(location.X, location.Y - textBlock.ActualHeight, 0, 0);

            Canvas.Children.Add(textBlock);
        }

        /// <inheritdoc />
        public WavesSize MeasureText(string text, ITextPaint paint)
        {
            var textBlock = new TextBlock
            {
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                Text = text,
                Foreground = new SolidColorBrush(paint.Fill.ToSystemColor()),
                FontSize = paint.TextStyle.FontSize,
                FontFamily = new FontFamily(paint.TextStyle.FontFamily),
                TextAlignment = paint.TextStyle.Alignment.ToSystemTextAlignment(),
                Opacity = paint.Opacity
            };

            textBlock.Measure(new global::System.Windows.Size(double.PositiveInfinity, double.PositiveInfinity));
            textBlock.Arrange(new Rect(0, 0, textBlock.DesiredSize.Width, textBlock.DesiredSize.Height));

            return new WavesSize(Convert.ToSingle(textBlock.ActualWidth), Convert.ToSingle(textBlock.ActualHeight));
        }
        
        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}