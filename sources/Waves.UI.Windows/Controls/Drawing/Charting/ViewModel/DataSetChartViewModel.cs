using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using Waves.Core.Base;
using Waves.UI.Drawing.Base;
using Waves.UI.Drawing.Base.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Base;
using Waves.UI.Windows.Controls.Drawing.Charting.Base.Enums;
using Waves.UI.Windows.Controls.Drawing.Charting.Base.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Charting.Utils;
using Waves.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;

namespace Waves.UI.Windows.Controls.Drawing.Charting.ViewModel
{
    /// <summary>
    ///     Data set chart view model.
    /// </summary>
    public class DataSetChartViewModel : ChartViewModel, IDataSetChartViewModel
    {
        private readonly object _dataSetLocker = new object();

        private readonly List<IDrawingObject> _tempDrawingObjects = new List<IDrawingObject>();

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

            ClearTempObject();

            foreach (var dataSet in DataSets)
                switch (dataSet.Type)
                {
                    case DataSetType.Line:
                        GenerateLinesForDataSet(dataSet);
                        break;
                    case DataSetType.Bar:
                        GenerateBarsForDataSet(dataSet);
                        break;
                    case DataSetType.BarWithEnvelope:
                        GenerateBarsWithEnvelopeForDataSet(dataSet);
                        break;
                }

            base.Draw(element);
        }

        /// <summary>
        ///     Generates lines for data set.
        /// </summary>
        /// <param name="dataSet">Data set.</param>
        private void GenerateLinesForDataSet(IDataSet dataSet)
        {
            if (dataSet.Data == null) return;
            if (dataSet.Data.Length == 0) return;

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

                AddTempObject(line);
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

                AddTempObject(ellipse);

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
                    Stroke = Foreground,
                    Fill = Foreground,
                };

                var size = DrawingElement.MeasureText(value, paint);

                text.Location = new Point(text.Location.X + 12, text.Location.Y + size.Height / 2);

                AddTempObject(text);
            }
        }

        /// <summary>
        ///     Generates bars for data set.
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

            var length = (int) Width;
            var points = visiblePoints.Count > length
                ? Resampling.LargestTriangleThreeBucketsDownsampling(visiblePoints.ToArray(), length)
                : Resampling.SplineUpsampling(visiblePoints.ToArray(), length);

            for (var i = 0; i < points.Length; i++)
                points[i] = Valuation.NormalizePoint(points[i], Width, Height, CurrentXMin,
                    CurrentYMin, CurrentXMax, CurrentYMax);

            for (var i = 0; i < points.Length - 1; i++)
            {
                var width = points[i + 1].X - points[i].X;
                var height = Height - points[i].Y;

                var rectangle = new Rectangle
                {
                    Fill = dataSet.Color,
                    IsAntialiased = false,
                    IsVisible = true,
                    StrokeThickness = 2,
                    Stroke = Background,
                    Location = points[i],
                    Width = width,
                    Height = height,
                    Opacity = 0.8f
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
                    var value = Valuation.DenormalizePointY2D(points[i].Y, Height, CurrentYMin, CurrentYMax);

                    var paint = new TextPaint
                    {
                        TextStyle = TextStyle,
                        Fill = Foreground,
                        IsAntialiased = true
                    };

                    var v = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture);

                    var text = new Text
                    {
                        Stroke = Foreground,
                        Fill = Foreground,
                        Location = new Point(ep.X, ep.Y),
                        Style = TextStyle,
                        Value = v,
                        IsVisible = true,
                        IsAntialiased = true
                    };

                    var size = DrawingElement.MeasureText(v, paint);

                    text.Location = new Point(text.Location.X - size.Width / 2, text.Location.Y - 6);

                    AddTempObject(text);
                }

                AddTempObject(rectangle);
            }

            if (points.Length == 0) return;

            var lastIndex = points.Length - 1;
            var lastWidth = Width - points[lastIndex].X;
            var lastHeight = Height - points[lastIndex].Y;

            var lastRectangle = new Rectangle
            {
                Fill = dataSet.Color,
                IsAntialiased = false,
                IsVisible = true,
                StrokeThickness = 2,
                Stroke = Background,
                Location = points[lastIndex],
                Width = lastWidth,
                Height = lastHeight,
                Opacity = 0.8f
            };


            if (visiblePoints.Count > length / 4)
            {
                lastRectangle.StrokeThickness = 0;
                lastRectangle.IsAntialiased = false;
            }

            if (visiblePoints.Count <= length / 32)
            {
                var ep = new Point(points[lastIndex].X + (points[lastIndex].X - points[lastIndex].X) / 2,
                    points[lastIndex].Y);
                var value = Valuation.DenormalizePointY2D(points[lastIndex].Y, Height, CurrentYMin,
                    CurrentYMax);

                var paint = new TextPaint
                {
                    TextStyle = TextStyle,
                    Fill = Foreground,
                    IsAntialiased = true
                };

                var v = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture);

                var text = new Text
                {
                    Stroke = Foreground,
                    Fill = Foreground,
                    Location = new Point(ep.X, ep.Y),
                    Style = TextStyle,
                    Value = v,
                    IsVisible = true,
                    IsAntialiased = true
                };

                var size = DrawingElement.MeasureText(v, paint);

                text.Location = new Point(text.Location.X - size.Width / 2 + lastWidth / 2, text.Location.Y - 6);

                AddTempObject(text);
            }

            AddTempObject(lastRectangle);
        }

        /// <summary>
        ///     Generates bars with envelope line for data set.
        /// </summary>
        /// <param name="dataSet">Data set.</param>
        private void GenerateBarsWithEnvelopeForDataSet(IDataSet dataSet)
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

            var length = (int)Width;
            var points = visiblePoints.Count > length
                ? Resampling.LargestTriangleThreeBucketsDownsampling(visiblePoints.ToArray(), length)
                : Resampling.SplineUpsampling(visiblePoints.ToArray(), length);

            for (var i = 0; i < points.Length; i++)
                points[i] = Valuation.NormalizePoint(points[i], Width, Height, CurrentXMin,
                    CurrentYMin, CurrentXMax, CurrentYMax);

            // first rectangle
            var firstIndex = 0;
            var firstWidth = points[firstIndex + 1].X - points[firstIndex].X;
            var firstHeight = Height - points[firstIndex].Y;

            var firstRectangle = new Rectangle
            {
                Fill = dataSet.Color,
                IsAntialiased = false,
                IsVisible = true,
                StrokeThickness = 0,
                Stroke = Background,
                Location = points[firstIndex],
                Width = firstWidth,
                Height = firstHeight,
                Opacity = 0.8f
            };

            var firstLine1 = new Line
            {
                Stroke = dataSet.Color,
                Fill = dataSet.Color,
                IsAntialiased = true,
                IsVisible = true,
                StrokeThickness = 2,
                Point1 = points[firstIndex],
                Point2 = new Point(points[firstIndex].X + firstWidth, points[firstIndex].Y),
                Opacity = 1
            };

            var firstLine2 = new Line
            {
                Stroke = dataSet.Color,
                Fill = dataSet.Color,
                IsAntialiased = true,
                IsVisible = true,
                StrokeThickness = 2,
                Point1 = new Point(points[firstIndex].X + firstWidth, points[firstIndex].Y),
                Point2 = new Point(points[firstIndex].X + firstWidth, points[firstIndex + 1].Y),
                Opacity = 1
            };

            if (visiblePoints.Count > length / 4)
            {
                firstRectangle.StrokeThickness = 0;
                firstRectangle.IsAntialiased = false;

                firstLine1.IsAntialiased = false;
                firstLine2.IsAntialiased = false;
            }

            if (visiblePoints.Count <= length / 32)
            {
                var ep = new Point(points[firstIndex].X + (points[firstIndex].X - points[firstIndex].X) / 2,
                    points[firstIndex].Y);
                var value = Valuation.DenormalizePointY2D(points[firstIndex].Y, Height, CurrentYMin,
                    CurrentYMax);

                var paint = new TextPaint
                {
                    TextStyle = TextStyle,
                    Fill = Foreground,
                    IsAntialiased = true
                };

                var v = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture);

                var text = new Text
                {
                    Stroke = Foreground,
                    Fill = Foreground,
                    Location = new Point(ep.X, ep.Y),
                    Style = TextStyle,
                    Value = v,
                    IsVisible = true,
                    IsAntialiased = true
                };

                var size = DrawingElement.MeasureText(v, paint);

                text.Location = new Point(text.Location.X - size.Width / 2 + firstWidth / 2, text.Location.Y - 6);

                AddTempObject(text);
            }

            AddTempObject(firstRectangle);
            AddTempObject(firstLine1);
            AddTempObject(firstLine2);

            // mid rectangles
            for (var i = 1; i < points.Length - 1; i++)
            {
                var width = points[i + 1].X - points[i].X;
                var height = Height - points[i].Y;

                var line0 = new Line
                {
                    Stroke = dataSet.Color,
                    Fill = dataSet.Color,
                    IsAntialiased = true,
                    IsVisible = true,
                    StrokeThickness = 2,
                    Point1 = new Point(points[i].X, points[i - 1].Y),
                    Point2 = points[i],
                    Opacity = 1
                };

                var line1 = new Line
                {
                    Stroke = dataSet.Color,
                    Fill = dataSet.Color,
                    IsAntialiased = true,
                    IsVisible = true,
                    StrokeThickness = 2,
                    Point1 = points[i],
                    Point2 = new Point(points[i].X + width, points[i].Y),
                    Opacity = 1
                };

                var line2 = new Line
                {
                    Stroke = dataSet.Color,
                    Fill = dataSet.Color,
                    IsAntialiased = true,
                    IsVisible = true,
                    StrokeThickness = 2,
                    Point1 = new Point(points[i].X + width, points[i].Y),
                    Point2 = new Point(points[i].X + width, points[i + 1].Y),
                    Opacity = 1
                };

                var rectangle = new Rectangle
                {
                    Fill = dataSet.Color,
                    IsAntialiased = false,
                    IsVisible = true,
                    StrokeThickness = 0,
                    Stroke = Background,
                    Location = points[i],
                    Width = width,
                    Height = height,
                    Opacity = dataSet.Opacity
                };

                if (visiblePoints.Count > length / 4)
                {
                    rectangle.StrokeThickness = 0;
                    rectangle.IsAntialiased = false;

                    line0.IsAntialiased = false;
                    line1.IsAntialiased = false;
                    line2.IsAntialiased = false;
                }

                if (visiblePoints.Count <= length / 32)
                {
                    // Добавляем подписи на столбцы
                    var ep = new Point(points[i].X + (points[i + 1].X - points[i].X) / 2, points[i].Y);
                    var value = Valuation.DenormalizePointY2D(points[i].Y, Height, CurrentYMin, CurrentYMax);

                    var paint = new TextPaint
                    {
                        TextStyle = TextStyle,
                        Fill = Foreground,
                        IsAntialiased = true
                    };

                    var v = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture);

                    var text = new Text
                    {
                        Stroke = Foreground,
                        Fill = Foreground,
                        Location = new Point(ep.X, ep.Y),
                        Style = TextStyle,
                        Value = v,
                        IsVisible = true,
                        IsAntialiased = true
                    };

                    var size = DrawingElement.MeasureText(v, paint);

                    text.Location = new Point(text.Location.X - size.Width / 2, text.Location.Y - 6);

                    AddTempObject(text);
                }

                AddTempObject(rectangle);
                AddTempObject(line0);
                AddTempObject(line1);
                AddTempObject(line2);
            }

            if (points.Length == 0) return;

            // Last rectangle

            var lastIndex = points.Length - 1;
            var lastWidth = Width - points[lastIndex].X;
            var lastHeight = Height - points[lastIndex].Y;

            var lastRectangle = new Rectangle
            {
                Fill = dataSet.Color,
                IsAntialiased = false,
                IsVisible = true,
                StrokeThickness = 2,
                Stroke = Background,
                Location = points[lastIndex],
                Width = lastWidth,
                Height = lastHeight,
                Opacity = 0.8f
            };

            var lastLine0 = new Line
            {
                Stroke = dataSet.Color,
                Fill = dataSet.Color,
                IsAntialiased = true,
                IsVisible = true,
                StrokeThickness = 2,
                Point1 = new Point(points[lastIndex].X, points[lastIndex - 1].Y),
                Point2 = points[lastIndex],
                Opacity = 1
            };

            var lastLine1 = new Line
            {
                Stroke = dataSet.Color,
                Fill = dataSet.Color,
                IsAntialiased = true,
                IsVisible = true,
                StrokeThickness = 0,
                Point1 = points[lastIndex],
                Point2 = new Point(points[lastIndex].X + lastWidth, points[lastIndex].Y),
                Opacity = 1
            };

            if (visiblePoints.Count > length / 4)
            {
                lastRectangle.StrokeThickness = 0;
                lastRectangle.IsAntialiased = false;

                lastLine0.IsAntialiased = false;
                lastLine1.IsAntialiased = false;
            }

            if (visiblePoints.Count <= length / 32)
            {
                var ep = new Point(points[lastIndex].X + (points[lastIndex].X - points[lastIndex].X) / 2,
                    points[lastIndex].Y);
                var value = Valuation.DenormalizePointY2D(points[lastIndex].Y, Height, CurrentYMin,
                    CurrentYMax);

                var paint = new TextPaint
                {
                    TextStyle = TextStyle,
                    Fill = Foreground,
                    IsAntialiased = true
                };

                var v = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture);

                var text = new Text
                {
                    Stroke = Foreground,
                    Fill = Foreground,
                    Location = new Point(ep.X, ep.Y),
                    Style = TextStyle,
                    Value = v,
                    IsVisible = true,
                    IsAntialiased = true
                };

                var size = DrawingElement.MeasureText(v, paint);

                text.Location = new Point(text.Location.X - size.Width / 2 + lastWidth / 2, text.Location.Y - 6);

                AddTempObject(text);
            }

            AddTempObject(lastRectangle);
            AddTempObject(lastLine0);
            AddTempObject(lastLine1);
        }

        /// <summary>
        ///     Adds object.
        /// </summary>
        /// <param name="obj">Drawing object.</param>
        private void AddTempObject(IDrawingObject obj)
        {
            _tempDrawingObjects.Add(obj);

            DrawingObjects.Add(obj);
        }

        private void ClearTempObject()
        {
            foreach (var obj in _tempDrawingObjects)
                DrawingObjects.Remove(obj);

            _tempDrawingObjects.Clear();
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