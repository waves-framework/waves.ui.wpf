using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Enums;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Utils;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel
{
    /// <summary>
    ///     Data set chart view model.
    /// </summary>
    public class DataSetChartViewModel : ChartViewModel, IDataSetChartViewModel
    {
        private readonly object _dataSetLocker = new object();

        private readonly List<IDrawingObject> _drawingObjects = new List<IDrawingObject>();

        /// <inheritdoc />
        public DataSetChartViewModel(IDrawingElement drawingElement) : base(drawingElement)
        {
            InitializeCollectionSynchronization();
        }

        /// <inheritdoc />
        public ObservableCollection<IDataSet> DataSets { get; } = new ObservableCollection<IDataSet>();

        /// <inheritdoc />
        public void AddDataSet(IDataSet dataSet)
        {
            DataSets.Add(dataSet);
            Update();
        }

        /// <inheritdoc />
        public void UpdateDataSet(int index, Point[] points)
        {
            if (index >= DataSets.Count) return;
            DataSets[index].UpdateDataSet(points);
            Update();
        }

        /// <inheritdoc />
        public void RemoveDataSet(int index)
        {
            if (index >= DataSets.Count) return;
            DataSets.RemoveAt(index);
            Update();
        }

        /// <inheritdoc />
        public override void Draw(object element)
        {
            if (Math.Abs(Width) < float.Epsilon || Math.Abs(Height) < float.Epsilon) return;

            foreach (var obj in _drawingObjects)
                DrawingObjects.Remove(obj);

            foreach (var dataSet in DataSets)
                switch (dataSet.Type)
                {
                    case DataSetType.Line:
                        GenerateLinesForDataSet(dataSet);
                        break;
                    case DataSetType.Bar:
                        //GenerateBarsForDataSet(dataSet);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            base.Draw(element);
        }

        /// <summary>
        /// Generates lines for data set.
        /// </summary>
        /// <param name="dataSet">Data set.</param>
        private void GenerateLinesForDataSet(IDataSet dataSet)
        {
            if (dataSet.Data == null) return;
            if (dataSet.Data.Length == 0) return;

            var objects = new List<IDrawingObject>();

            var visiblePoints = new List<Point> {new Point()};
            foreach (var point in dataSet.Data)
            {
                if (point.X < CurrentXMin)
                {
                    visiblePoints[0] = point;
                    continue;
                }

                if (point.X >= CurrentXMin && point.X <= CurrentXMax)
                {
                    visiblePoints.Add(point);
                }
                else if (point.X > CurrentXMax)
                {
                    visiblePoints.Add(point);
                    break;
                }
            }

            var length = (int) Width;
            var points = visiblePoints.Count > length
                ? Resampling.LargestTriangleThreeBucketsDownsampling(visiblePoints.ToArray(), length)
                : Resampling.SplineUpsampling(visiblePoints.ToArray(), length);

            for (var i = 0; i < points.Length; i++)
                points[i] = Valuation.NormalizePoint(points[i], Width, Height, CurrentXMin,
                    CurrentYMin, CurrentXMax, CurrentYMax);

            for (var i = 1; i < points.Length; i++)
            {
                var line = new Line
                {
                    Stroke = dataSet.Color,
                    Fill = dataSet.Color,
                    IsAntialiased = true,
                    IsVisible = true,
                    StrokeThickness = 2,
                    Point1 = points[i - 1],
                    Point2 = points[i],
                    Opacity = dataSet.Opacity
                };

                if (visiblePoints.Count > length) line.IsAntialiased = false;

                DrawingObjects.Add(line);
                _drawingObjects.Add(line);
            }

            if (IsMouseOver)
            {
                var x = Valuation.DenormalizePointX2D(LastMousePosition.X, Width, CurrentXMin, CurrentXMax);
                var y = Valuation.DenormalizePointY2D(LastMousePosition.Y, Height, CurrentYMin, CurrentYMax);

                var ep = new Point();
                var ed = new Point();

                for (var i = 0; i < dataSet.Data.Length - 1; i++)
                    if (x > dataSet.Data[i].X && x < dataSet.Data[i + 1].X)
                    {
                        ep = new Point(dataSet.Data[i].X, dataSet.Data[i].Y);
                        ed = new Point(dataSet.Data[i].X, dataSet.Data[i].Y);
                    }

                ep = Valuation.NormalizePoint(ep, Width, Height, CurrentXMin, CurrentYMin,
                    CurrentXMax,
                    CurrentYMax);

                var ellipse = new Ellipse
                {
                    Radius = 4,
                    Fill = dataSet.Color,
                    Stroke = Background,
                    StrokeThickness = 1,
                    Location = ep,
                    IsVisible = true,
                    IsAntialiased = true
                };

                DrawingObjects.Add(ellipse);
                _drawingObjects.Add(ellipse);

                var paint = new TextPaint
                {
                    TextStyle = TextStyle,
                    Fill = Foreground,
                    IsAntialiased = true
                };

                var value = Math.Round(ed.Y, 2).ToString(CultureInfo.InvariantCulture) + " " + YAxisUnit;

                var text = new Text
                {
                    Location = new Point(ep.X, ep.Y),
                    Style = paint.TextStyle,
                    Value = value,
                    IsVisible = true,
                    IsAntialiased = paint.IsAntialiased,
                    Fill = paint.Fill
                };

                var size = DrawingElement.MeasureText(value, paint);

                text.Location = new Point(text.Location.X + 12, text.Location.Y + size.Height / 2);

                DrawingObjects.Add(text);
                _drawingObjects.Add(text);
            }
        }

        /// <summary>
        /// Generates bars for data set.
        /// </summary>
        /// <param name="dataSet">Data set.</param>
        private void GenerateBarsForDataSet(IDataSet dataSet)
        {
            if (dataSet.Data == null) return;
            if (dataSet.Data.Length == 0) return;

            var visiblePoints = new List<Point>();
            foreach (var point in dataSet.Data)
            {
                if (point.X < CurrentXMin)
                {
                    if (visiblePoints.Count == 0)
                        visiblePoints.Add(new Point());

                    visiblePoints[0] = point;
                    continue;
                }

                if (point.X >= CurrentXMin && point.X <= CurrentXMax)
                {
                    visiblePoints.Add(point);
                }
                else if (point.X > CurrentXMax)
                {
                    visiblePoints.Add(point);
                    break;
                }
            }

            // Применяем децимацию или интерполяцию
            var length = (int)Width;
            var points = visiblePoints.Count > length
                ? Resampling.LargestTriangleThreeBucketsDownsampling(visiblePoints.ToArray(), length)
                : Resampling.SplineUpsampling(visiblePoints.ToArray(), length);

            // Нормируем
            for (var i = 0; i < points.Length; i++)
                points[i] = Valuation.NormalizePoint(points[i], (float)Width, (float)Height, CurrentXMin,
                    CurrentYMin, CurrentXMax, CurrentYMax);

            // Преобразуем в линии
            for (var i = 0; i < points.Length - 1; i++)
            {
                var width = points[i + 1].X - points[i].X;
                var height = (float)Height - points[i].Y;

                var rectangle = new Rectangle
                {
                    Fill = dataSet.Color,
                    IsAntialiased = false,
                    IsVisible = true,
                    StrokeThickness = 1,
                    Stroke = Background,
                    Location = points[i],
                    Width = width,
                    Height = height
                };

                if (visiblePoints.Count > length / 4)
                {
                    rectangle.StrokeThickness = 0;
                    rectangle.IsAntialiased = false;
                }

                if (visiblePoints.Count <= length / 32)
                {
                    // Добавляем подписи на столбцы
                    var ep = new Point(points[i].X + (points[i + 1].X - points[i].X) / 2, points[i].Y);
                    var value = Valuation.DenormalizePointY2D(points[i].Y, (float)Height, CurrentYMin, CurrentYMax);

                    var paint = new TextPaint
                    {
                        TextStyle = TextStyle,
                        Fill = Foreground,
                        IsAntialiased = true
                    };

                    var text = new Text
                    {
                        Location = new Point(ep.X, ep.Y),
                        Style = TextStyle,
                        Value = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture),
                        IsVisible = true,
                        IsAntialiased = true
                    };

                    var size = DrawingElement.MeasureText(Math.Round(value, 2).ToString(CultureInfo.InvariantCulture), paint);

                    text.Location = new Point(text.Location.X - size.Width / 2, text.Location.Y - 6);

                    DrawingObjects.Add(text);
                }

                DrawingObjects.Add(rectangle);
            }

            if (points.Length == 0) return;

            var lastIndex = points.Length - 1;
            var lastWidth = (float)(Width - points[lastIndex].X);
            var lastHeight = (float)Height - points[lastIndex].Y;

            var lastRectangle = new Rectangle
            {
                Fill = dataSet.Color,
                IsAntialiased = false,
                IsVisible = true,
                StrokeThickness = 1,
                Stroke = Background,
                Location = points[lastIndex],
                Width = lastWidth,
                Height = lastHeight
            };


            if (visiblePoints.Count > length / 4)
            {
                lastRectangle.StrokeThickness = 0;
                lastRectangle.IsAntialiased = false;
            }

            if (visiblePoints.Count <= length / 32)
            {
                // Добавляем подписи на столбцы
                var ep = new Point(points[lastIndex].X + (points[lastIndex].X - points[lastIndex].X) / 2,
                    points[lastIndex].Y);
                var value = Valuation.DenormalizePointY2D(points[lastIndex].Y, (float)Height, CurrentYMin,
                    CurrentYMax);

                var text = new Text
                {
                    Location = new Point(ep.X, ep.Y),
                    Style = TextStyle,
                    Value = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture),
                    IsVisible = true,
                    IsAntialiased = true
                };

                var size = text.MeasureObject();
                text.Location = new Point2D(text.Location.X - size.Width / 2 + lastWidth / 2, text.Location.Y - 6);

                DrawingObjects.Add(text);
            }

            DrawingObjects.Add(lastRectangle);
        }

        /// <summary>
        ///     Initializes collection synchronization.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(DataSets, _dataSetLocker);
        }
    }
}