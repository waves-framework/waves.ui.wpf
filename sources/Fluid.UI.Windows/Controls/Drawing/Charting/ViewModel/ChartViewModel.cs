using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Fluid.Core.Base;
using Fluid.Core.Base.EventArgs;
using Fluid.Core.Services.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Enums;
using Fluid.UI.Windows.Controls.Drawing.Charting.Utils;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel
{
    /// <summary>
    ///     Chart view model base.
    /// </summary>
    public class ChartViewModel : DrawingElementViewModel, IChartViewModel
    {
        private readonly object _axisLocker = new object();

        private readonly List<IDrawingObject> _axisTicksDrawingObjects = new List<IDrawingObject>();
        private readonly List<IDrawingObject> _axisSignaturesDrawingObjects = new List<IDrawingObject>();

        private bool _hasDefaultTicks = true;
        private bool _isZoomEnabled = true;
        private bool _isTitleVisible = true;
        private bool _isXAxisPrimaryTicksVisible = true;
        private bool _isXAxisAdditionalTicksVisible = true;
        private bool _isXAxisSignaturesVisible = true;
        private bool _isXAxisZeroLineVisible = true;
        private bool _isXAxisDescriptionVisible = true;
        private bool _isYAxisPrimaryTicksVisible = true;
        private bool _isYAxisAdditionalTicksVisible = true;
        private bool _isYAxisSignaturesVisible = true;
        private bool _isYAxisZeroLineVisible = true;
        private bool _isYAxisDescriptionVisible = true;
        private bool _isBorderVisible = true;

        private string _title = "New chart";
        private string _xAxisName = "X axis";
        private string _xAxisUnit = "unit";
        private string _yAxisName = "Y axis";
        private string _yAxisUnit = "unit";

        private float _xMin;
        private float _xMax = 1;
        private float _yMin = -1;
        private float _yMax = 1;
        private float _currentXMin;
        private float _currentXMax = 1;
        private float _currentYMin= -1;
        private float _currentYMax = 1;

        private int _xAxisPrimaryTicksCount = 4;
        private int _xAxisAdditionalTicksCount = 4;
        private int _yAxisPrimaryTicksCount = 4;
        private int _yAxisAdditionalTicksCount = 4;

        private float _xAxisPrimaryTickThickness = 1;
        private float _xAxisAdditionalTickThickness = 1;
        private float _xAxisZeroLineThickness = 1;
        private float _yAxisPrimaryTickThickness = 1;
        private float _yAxisAdditionalTickThickness = 1;
        private float _yAxisZeroLineThickness = 1;
        private float _borderThickness = 1;

        private float[] _xAxisPrimaryTicksDashArray = { 4.0f, 4.0f, 0.0f, 0.0f };
        private float[] _xAxisAdditionalTicksDashArray = { 8.0f, 4.0f, 0.0f, 0.0f };
        private float[] _xAxisZeroLineDashArray;
        private float[] _yAxisPrimaryTicksDashArray = { 4.0f, 4.0f, 0.0f, 0.0f };
        private float[] _yAxisAdditionalTicksDashArray = { 8.0f, 4.0f, 0.0f, 0.0f };
        private float[] _yAxisZeroLineDashArray;

        private Color _xAxisPrimaryTicksColor = Color.Gray;
        private Color _xAxisAdditionalTicksColor = Color.LightGray;
        private Color _xAxisZeroLineColor = Color.Black;
        private Color _yAxisPrimaryTicksColor = Color.Gray;
        private Color _yAxisAdditionalTicksColor = Color.LightGray;
        private Color _yAxisZeroLineColor = Color.Black;
        private Color _borderColor = Color.Black;

        private TextStyle _textStyle = new TextStyle();
        private IInputService _inputService;

        /// <inheritdoc />
        public ChartViewModel(IDrawingElement drawingElement) : base(drawingElement)
        {
            SetDefaultTicks();
        }

        /// <inheritdoc />
        public bool IsZoomEnabled
        {
            get => _isZoomEnabled;
            set
            {
                _isZoomEnabled = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsTitleVisible
        {
            get => _isTitleVisible;
            set
            {
                _isTitleVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsXAxisPrimaryTicksVisible
        {
            get => _isXAxisPrimaryTicksVisible;
            set
            {
                _isXAxisPrimaryTicksVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsXAxisAdditionalTicksVisible
        {
            get => _isXAxisAdditionalTicksVisible;
            set
            {
                _isXAxisAdditionalTicksVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsXAxisSignaturesVisible
        {
            get => _isXAxisSignaturesVisible;
            set
            {
                _isXAxisSignaturesVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsXAxisZeroLineVisible
        {
            get => _isXAxisZeroLineVisible;
            set
            {
                _isXAxisZeroLineVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsXAxisDescriptionVisible
        {
            get => _isXAxisDescriptionVisible;
            set
            {
                _isXAxisDescriptionVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsYAxisPrimaryTicksVisible
        {
            get => _isYAxisPrimaryTicksVisible;
            set
            {
                _isYAxisPrimaryTicksVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsYAxisAdditionalTicksVisible
        {
            get => _isYAxisAdditionalTicksVisible;
            set
            {
                _isYAxisAdditionalTicksVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsYAxisSignaturesVisible
        {
            get => _isYAxisSignaturesVisible;
            set
            {
                _isYAxisSignaturesVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsYAxisZeroLineVisible
        {
            get => _isYAxisZeroLineVisible;
            set
            {
                _isYAxisZeroLineVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsYAxisDescriptionVisible
        {
            get => _isYAxisDescriptionVisible;
            set
            {
                _isYAxisDescriptionVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsBorderVisible
        {
            get => _isBorderVisible;
            set
            {
                _isBorderVisible = value;
                Update();
            }
        }

        /// <inheritdoc />
        public bool IsXAxisZoomAroundZero { get; set; }

        /// <inheritdoc />
        public bool IsYAxisZoomAroundZero { get; set; }

        /// <inheritdoc />
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                Update();
            }
        }

        /// <inheritdoc />
        public string XAxisName
        {
            get => _xAxisName;
            set
            {
                _xAxisName = value;
                Update();
            }
        }

        /// <inheritdoc />
        public string XAxisUnit
        {
            get => _xAxisUnit;
            set
            {
                _xAxisUnit = value;
                Update();
            }
        }

        /// <inheritdoc />
        public string YAxisName
        {
            get => _yAxisName;
            set
            {
                _yAxisName = value;
                Update();
            }
        }

        /// <inheritdoc />
        public string YAxisUnit
        {
            get => _yAxisUnit;
            set
            {
                _yAxisUnit = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float XMin
        {
            get => _xMin;
            set
            {
                _xMin = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float XMax
        {
            get => _xMax;
            set
            {
                _xMax = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float YMin
        {
            get => _yMin;
            set
            {
                _yMin = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float YMax
        {
            get => _yMax;
            set
            {
                _yMax = value;
                Update();
            }
        }

        /// <summary>
        ///     Gets or sets current XMin.
        /// </summary>
        public float CurrentXMin
        {
            get => _currentXMin;
            set
            {
                _currentXMin = value;
                Update();
            }
        }

        /// <summary>
        ///     Gets or sets current XMax.
        /// </summary>
        public float CurrentXMax
        {
            get => _currentXMax;
            set
            {
                _currentXMax = value;
                Update();
            }
        }

        /// <summary>
        ///     Gets or sets current YMin.
        /// </summary>
        public float CurrentYMin
        {
            get => _currentYMin;
            set
            {
                _currentYMin = value;
                Update();
            }
        }

        /// <summary>
        ///     Gets or sets current YMax.
        /// </summary>
        public float CurrentYMax
        {
            get => _currentYMax;
            set
            {
                _currentYMax = value;
                Update();
            }
        }

        /// <inheritdoc />
        public int XAxisPrimaryTicksCount
        {
            get => _xAxisPrimaryTicksCount;
            set
            {
                _xAxisPrimaryTicksCount = value;
                Update();
            }
        }

        /// <inheritdoc />
        public int XAxisAdditionalTicksCount
        {
            get => _xAxisAdditionalTicksCount;
            set
            {
                _xAxisAdditionalTicksCount = value;
                Update();
            }
        }

        /// <inheritdoc />
        public int YAxisPrimaryTicksCount
        {
            get => _yAxisPrimaryTicksCount;
            set
            {
                _yAxisPrimaryTicksCount = value;
                Update();
            }
        }

        /// <inheritdoc />
        public int YAxisAdditionalTicksCount
        {
            get => _yAxisAdditionalTicksCount;
            set
            {
                _yAxisAdditionalTicksCount = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float XAxisPrimaryTickThickness
        {
            get => _xAxisPrimaryTickThickness;
            set
            {
                _xAxisPrimaryTickThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float XAxisAdditionalTickThickness
        {
            get => _xAxisAdditionalTickThickness;
            set
            {
                _xAxisAdditionalTickThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float XAxisZeroLineThickness
        {
            get => _xAxisZeroLineThickness;
            set
            {
                _xAxisZeroLineThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float YAxisPrimaryTickThickness
        {
            get => _yAxisPrimaryTickThickness;
            set
            {
                _yAxisPrimaryTickThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float YAxisAdditionalTickThickness
        {
            get => _yAxisAdditionalTickThickness;
            set
            {
                _yAxisAdditionalTickThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float YAxisZeroLineThickness
        {
            get => _yAxisZeroLineThickness;
            set
            {
                _yAxisZeroLineThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float BorderThickness
        {
            get => _borderThickness;
            set
            {
                _borderThickness = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float[] XAxisPrimaryTicksDashArray
        {
            get => _xAxisPrimaryTicksDashArray;
            set
            {
                _xAxisPrimaryTicksDashArray = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float[] XAxisAdditionalTicksDashArray
        {
            get => _xAxisAdditionalTicksDashArray;
            set
            {
                _xAxisAdditionalTicksDashArray = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float[] XAxisZeroLineDashArray
        {
            get => _xAxisZeroLineDashArray;
            set
            {
                _xAxisZeroLineDashArray = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float[] YAxisPrimaryTicksDashArray
        {
            get => _yAxisPrimaryTicksDashArray;
            set
            {
                _yAxisPrimaryTicksDashArray = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float[] YAxisAdditionalTicksDashArray
        {
            get => _yAxisAdditionalTicksDashArray;
            set
            {
                _yAxisAdditionalTicksDashArray = value;
                Update();
            }
        }

        /// <inheritdoc />
        public float[] YAxisZeroLineDashArray
        {
            get => _yAxisZeroLineDashArray;
            set
            {
                _yAxisZeroLineDashArray = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color XAxisPrimaryTicksColor
        {
            get => _xAxisPrimaryTicksColor;
            set
            {
                _xAxisPrimaryTicksColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color XAxisAdditionalTicksColor
        {
            get => _xAxisAdditionalTicksColor;
            set
            {
                _xAxisAdditionalTicksColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color XAxisZeroLineColor
        {
            get => _xAxisZeroLineColor;
            set
            {
                _xAxisZeroLineColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color YAxisPrimaryTicksColor
        {
            get => _yAxisPrimaryTicksColor;
            set
            {
                _yAxisPrimaryTicksColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color YAxisAdditionalTicksColor
        {
            get => _yAxisAdditionalTicksColor;
            set
            {
                _yAxisAdditionalTicksColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color YAxisZeroLineColor
        {
            get => _yAxisZeroLineColor;
            set
            {
                _yAxisZeroLineColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Update();
            }
        }

        /// <inheritdoc />
        public TextStyle TextStyle
        {
            get => _textStyle;
            set
            {
                _textStyle = value;
                Update();
            }
        }

        /// <summary>
        /// Gets or sets input service.
        /// </summary>
        public IInputService InputService
        {
            get => _inputService;
            set
            {
                if (_inputService != null)
                {
                    _inputService.PointerStateChanged -= OnInputServicePointerStateChanged;
                    _inputService.KeyPressed -= OnInputServiceKeyPressed;
                    _inputService.KeyReleased -= OnInputServiceKeyReleased;
                }

                _inputService = value;

                if (_inputService != null)
                {
                    _inputService.PointerStateChanged += OnInputServicePointerStateChanged;
                    _inputService.KeyPressed += OnInputServiceKeyPressed;
                    _inputService.KeyReleased += OnInputServiceKeyReleased;
                }
            }
        }

        /// <summary>
        /// Gets or sets whether CTRL key is pressed.
        /// </summary>
        protected bool IsCtrlPressed { get; set; }

        /// <summary>
        /// Gets or sets whether SHIFT key is pressed.
        /// </summary>
        protected bool IsShiftPressed { get; set; }

        /// <summary>
        /// Gets or sets whether is mouse over chart.
        /// </summary>
        protected bool IsMouseOver { get; set; }

        /// <summary>
        /// Gets or sets last mouse position.
        /// </summary>
        protected Point LastMousePosition { get; set; }

        /// <summary>
        /// Gets or sets Axis ticks list.
        /// </summary>
        protected List<AxisTick> AxisTicks { get; set; } = new List<AxisTick>();

        /// <inheritdoc />
        public override void Draw(object element)
        {
            lock (_axisLocker)
            {
                GenerateAxisTicksDrawingObjects();
                GenerateAxisTicksSignaturesDrawingObjects();
            }

            base.Draw(element);

            DrawingElement?.Draw(element, DrawingObjects);
        }

        /// <inheritdoc />
        public sealed override void Update()
        {
            if (_hasDefaultTicks) 
                SetDefaultTicks();

            OnRedrawRequested();
        }

        /// <inheritdoc />
        public void SetDefaultTicks()
        {
            _hasDefaultTicks = true;

            lock (_axisLocker)
            {
                AxisTicks.Clear();

                AxisTicks.GenerateAxisTicks(CurrentXMin, CurrentXMax, XAxisPrimaryTicksCount, XAxisAdditionalTicksCount,
                    AxisTickOrientation.Horizontal);

                AxisTicks.GenerateAxisTicks(CurrentYMin, CurrentYMax, YAxisPrimaryTicksCount, YAxisAdditionalTicksCount,
                    AxisTickOrientation.Vertical);
            }
        }

        /// <inheritdoc />
        public void SetTicks(List<AxisTick> ticks)
        {
            lock (_axisLocker)
            {
                _hasDefaultTicks = false;
                AxisTicks = ticks;
            }
        }

        /// <summary>
        /// Generates axis ticks drawing objects.
        /// </summary>
        private void GenerateAxisTicksDrawingObjects()
        {
            foreach (var obj in _axisTicksDrawingObjects)
                DrawingObjects.Remove(obj);

            _axisTicksDrawingObjects.Clear();

            foreach (var tick in AxisTicks.ToList())
            {
                if (tick.Orientation == AxisTickOrientation.Horizontal)
                {
                    if (tick.Type == AxisTickType.Primary)
                    {
                        if (!IsXAxisPrimaryTicksVisible) continue;

                        var obj = Ticks.GetXAxisTickLine(tick.Value, XAxisPrimaryTickThickness,
                            XAxisPrimaryTicksColor, XAxisPrimaryTicksDashArray, 0.5f, CurrentXMin, CurrentXMax,
                            (float)Width, (float)Height);

                        DrawingObjects.Add(obj);

                        _axisTicksDrawingObjects.Add(obj);
                    }

                    else if (tick.Type == AxisTickType.Additional)
                    {
                        if (!IsXAxisAdditionalTicksVisible) continue;

                        var obj = Ticks.GetXAxisTickLine(tick.Value, XAxisAdditionalTickThickness,
                            XAxisAdditionalTicksColor, XAxisAdditionalTicksDashArray, 0.25f, CurrentXMin,
                            CurrentXMax, (float)Width, (float)Height);

                        DrawingObjects.Add(obj);

                        _axisTicksDrawingObjects.Add(obj);
                    }

                    else if (tick.Type == AxisTickType.Zero)
                    {
                        if (!IsXAxisZeroLineVisible) continue;

                        var obj = Ticks.GetXAxisTickLine(tick.Value, XAxisZeroLineThickness,
                            XAxisZeroLineColor, XAxisZeroLineDashArray, 1f, CurrentXMin, CurrentXMax,
                            (float)Width, (float)Height);

                        DrawingObjects.Add(obj);

                        _axisTicksDrawingObjects.Add(obj);
                    }
                }

                else if (tick.Orientation == AxisTickOrientation.Vertical)
                {
                    if (tick.Type == AxisTickType.Primary)
                    {
                        if (!IsYAxisPrimaryTicksVisible) continue;

                        var obj = Ticks.GetYAxisTickLine(tick.Value, YAxisPrimaryTickThickness,
                            YAxisPrimaryTicksColor, YAxisPrimaryTicksDashArray, 0.5f, CurrentYMin, CurrentYMax,
                            (float)Width, (float)Height);

                        DrawingObjects.Add(obj);

                        _axisTicksDrawingObjects.Add(obj);
                    }

                    else if (tick.Type == AxisTickType.Additional)
                    {
                        if (!IsYAxisAdditionalTicksVisible) continue;

                        var obj = Ticks.GetYAxisTickLine(tick.Value, YAxisAdditionalTickThickness,
                            YAxisAdditionalTicksColor, YAxisAdditionalTicksDashArray, 0.25f, CurrentYMin,
                            CurrentYMax, (float)Width, (float)Height);

                        DrawingObjects.Add(obj);

                        _axisTicksDrawingObjects.Add(obj);
                    }

                    else if (tick.Type == AxisTickType.Zero)
                    {
                        if (!IsYAxisZeroLineVisible) continue;

                        var obj = Ticks.GetYAxisTickLine(tick.Value, YAxisZeroLineThickness,
                            YAxisZeroLineColor, YAxisZeroLineDashArray, 1f, CurrentYMin, CurrentYMax,
                            (float)Width, (float)Height);

                        DrawingObjects.Add(obj);

                        _axisTicksDrawingObjects.Add(obj);
                    }
                }
            }
        }

        /// <summary>
        /// Generates axis tick signatures drawing objects.
        /// </summary>
        private void GenerateAxisTicksSignaturesDrawingObjects()
        {
            foreach (var obj in _axisSignaturesDrawingObjects)
                DrawingObjects.Remove(obj);
            _axisSignaturesDrawingObjects.Clear();

            var paint = new TextPaint()
            {
                Fill = Foreground,
                IsAntialiased = true,
                Opacity = 1.0f,
                TextStyle = TextStyle
            };

            foreach (var tick in AxisTicks.ToList())
            {
                if (tick == null) continue;
                if (tick.Type != AxisTickType.Primary && tick.Type != AxisTickType.Zero) continue;

                if (tick.Orientation == AxisTickOrientation.Horizontal)
                {
                    if (!IsXAxisSignaturesVisible) continue;

                    var text = Signatures.GetXAxisSignature(tick.Value, tick.Description, paint,
                        CurrentXMin, CurrentXMax, (float)Width, (float)Height);

                    var size = DrawingElement.MeasureText(tick.Description, paint);

                    text.Location = new Point(text.Location.X - size.Width / 2, text.Location.Y);

                    var rectangle = Signatures.GetXAxisSignatureRectangle(
                        tick.Value, 
                        Background,
                        XAxisPrimaryTicksColor,
                        0.8f,
                        1,
                        6,
                        size.Width,
                        size.Height,
                        CurrentXMin,
                        CurrentXMax,
                        Width,
                        Height);

                    DrawingObjects.Add(rectangle);
                    DrawingObjects.Add(text);

                    _axisSignaturesDrawingObjects.Add(rectangle);
                    _axisSignaturesDrawingObjects.Add(text);
                }

                if (tick.Orientation == AxisTickOrientation.Vertical)
                {
                    if (!IsYAxisSignaturesVisible) continue;

                    var text = Signatures.GetYAxisSignature(tick.Value, tick.Description, paint,
                        CurrentYMin, CurrentYMax, (float)Width, (float)Height);

                    var size = DrawingElement.MeasureText(tick.Description, paint);

                    text.Location = new Point(text.Location.X, text.Location.Y + size.Height / 2);

                    var rectangle = Signatures.GetYAxisSignatureRectangle(
                        tick.Value,
                        Background,
                        YAxisPrimaryTicksColor,
                        0.8f,
                        1,
                        6,
                        size.Width,
                        size.Height,
                        CurrentYMin,
                        CurrentYMax,
                        Width,
                        Height);

                    DrawingObjects.Add(rectangle);
                    DrawingObjects.Add(text);

                    _axisSignaturesDrawingObjects.Add(rectangle);
                    _axisSignaturesDrawingObjects.Add(text);
                }
            }
        }

        /// <summary>
        /// Zooms chart.
        /// </summary>
        /// <param name="delta">Zoom delta.</param>
        /// <param name="position">Zoom position.</param>
        private void ZoomChart(int delta, Point position)
        {
            if (!IsMouseOver) return;
            if (!IsZoomEnabled) return;

            var deltaF = delta / 1000.0f;

            var x = Valuation.DenormalizePointX2D(position.X, (float)Width, CurrentXMin, CurrentXMax);
            var y = Valuation.DenormalizePointY2D(position.Y, (float)Height, CurrentYMin, CurrentYMax);

            if (IsCtrlPressed)
            {
                var yMin = 0.0f;
                var yMax = 0.0f;

                if (IsYAxisZoomAroundZero)
                {
                    yMin = -CurrentYMin * deltaF;
                    yMax = CurrentYMax * deltaF;
                }
                else
                {
                    yMin = (y - CurrentYMin) * deltaF;
                    yMax = (CurrentYMax - y) * deltaF;
                }

                if (CurrentYMax - yMax - (CurrentYMin + yMin) > (YMax - YMin) / 1000000)
                {
                    CurrentYMax -= yMax;
                    CurrentYMin += yMin;
                }

                if (CurrentYMin < YMin)
                    CurrentYMin = YMin;
                if (CurrentYMax > YMax)
                    CurrentYMax = YMax;

                Update();
                return;
            }

            if (IsShiftPressed)
            {
                ScrollChart(deltaF, x, y);

                Update();
                return;
            }

            var xMin = (x - CurrentXMin) * deltaF;
            var xMax = (CurrentXMax - x) * deltaF;

            if (CurrentXMax - xMax - (CurrentXMin + xMin) > (XMax - XMin) / 1000000)
            {
                CurrentXMax -= xMax;
                CurrentXMin += xMin;
            }

            if (CurrentXMin < XMin)
                CurrentXMin = XMin;
            if (CurrentXMax > XMax)
                CurrentXMax = XMax;

            Update();
        }

        /// <summary>
        /// Scrolls chart along the X axis.
        /// </summary>
        /// <param name="delta">Scrolling delta.</param>
        /// <param name="x">Scroll value along the X axis.</param>
        /// <param name="y">Scroll value along the Y axis.</param>
        private void ScrollChart(float delta, float x, float y)
        {
            var xMin = delta * 10f;
            var xMax = delta * 10f;

            if (CurrentXMax + xMax > XMax)
                return;
            if (CurrentXMin + xMin < XMin)
                return;

            CurrentXMax += xMax;
            CurrentXMin += xMin;

            if (CurrentXMin < XMin)
                CurrentXMin = XMin;
            if (CurrentXMax > XMax)
                CurrentXMax = XMax;
        }

        /// <summary>
        /// Actions when pointer state changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnInputServicePointerStateChanged(object sender, Fluid.Core.Base.EventArgs.PointerEventArgs e)
        {
            
        }

        /// <summary>
        /// Actions when key pressed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnInputServiceKeyPressed(object sender, KeyEventArgs e)
        {

        }

        /// <summary>
        /// Actions when key released.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnInputServiceKeyReleased(object sender, KeyEventArgs e)
        {
            
        }
    }
}