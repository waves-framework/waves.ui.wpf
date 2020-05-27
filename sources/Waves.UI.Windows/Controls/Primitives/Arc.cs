using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace Waves.UI.Windows.Controls.Primitives
{
    public sealed class Arc : FrameworkElement
    {
        [Category("Arc")]
        public Point Center
        {
            get { return (Point)GetValue(CenterProperty); }
            set { SetValue(CenterProperty, value); }
        }

        [Category("Arc")]
        public bool OverrideCenter
        {
            get { return (bool)GetValue(OverrideCenterProperty); }
            set { SetValue(OverrideCenterProperty, value); }
        }

        [Category("Arc")]
        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        [Category("Arc")]
        public double SweepAngle
        {
            get { return (double)GetValue(SweepAngleProperty); }
            set { SetValue(SweepAngleProperty, value); }
        }

        [Category("Arc")]
        public double Radius
        {
            get { return (double)GetValue(RadiusProperty); }
            set { SetValue(RadiusProperty, value); }
        }

        [Category("Arc")]
        public double StrokeThickness
        {
            get { return (double)GetValue(StrokeThicknessProperty); }
            set { SetValue(StrokeThicknessProperty, value); }
        }

        [Category("Arc")]
        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StartAngleProperty = DependencyProperty.Register(
            "StartAngle",
            typeof(double),
            typeof(Arc),
            new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty SweepAngleProperty = DependencyProperty.Register(
            "SweepAngle",
            typeof(double),
            typeof(Arc),
            new FrameworkPropertyMetadata((double)180, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty RadiusProperty = DependencyProperty.Register(
            "Radius",
            typeof(double),
            typeof(Arc),
            new FrameworkPropertyMetadata(10.0, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
            "Stroke",
            typeof(Brush),
            typeof(Arc),
            new FrameworkPropertyMetadata(Brushes.Black, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
            "StrokeThickness",
            typeof(double),
            typeof(Arc),
            new FrameworkPropertyMetadata((double)1, FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty CenterProperty = DependencyProperty.Register(
            "Center",
            typeof(Point),
            typeof(Arc),
            new FrameworkPropertyMetadata(new Point(), FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty OverrideCenterProperty = DependencyProperty.Register(
            "OverrideCenter",
            typeof(bool),
            typeof(Arc),
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender));

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            Draw(dc);
        }

        private void Draw(DrawingContext dc)
        {
            var center = OverrideCenter ? CenterPointFromRect(new Rect(RenderSize)) : Center;

            var startPoint = PolarToCartesian(StartAngle, Radius, center);
            var endPoint = PolarToCartesian(StartAngle + SweepAngle, Radius, center);

            var isLarge = StartAngle + SweepAngle - StartAngle > 180;

            var segments = new List<PathSegment>(1)
            {
                new ArcSegment(endPoint, new Size(Radius, Radius), 0.0, isLarge, SweepDirection.Clockwise, true)
            };

            var figures = new List<PathFigure>(1);
            var pf = new PathFigure(startPoint, segments, true) { IsClosed = false };

            figures.Add(pf);

            System.Windows.Media.Geometry g = new PathGeometry(figures, FillRule.EvenOdd, null);

            dc.DrawGeometry(null, new Pen(Stroke, StrokeThickness), g);
        }

        private static Point CenterPointFromRect(Rect rect)
        {
            return new Point(rect.Width / 2, rect.Height / 2);
        }

        public static Point PolarToCartesian(double angle, double radius, Point center)
        {
            var angleRad = Math.PI / 180.0 * (angle - 90);

            var x = radius * Math.Cos(angleRad) + center.X;
            var y = radius * Math.Sin(angleRad) + center.Y;

            return new Point(x, y);
        }
    }
}