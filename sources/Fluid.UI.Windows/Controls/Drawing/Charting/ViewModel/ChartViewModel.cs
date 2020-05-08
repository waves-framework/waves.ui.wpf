using System.Collections.Generic;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Engines.System.ViewModel;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel
{
    /// <summary>
    /// Chart view model base.
    /// </summary>
    public abstract class ChartViewModel : DrawingElementPresentationViewModel, IChartViewModel
    {
        private bool _isZoomEnabled;
        private bool _isTitleVisible;
        private bool _isXAxisPrimaryTicksVisible;
        private bool _isXAxisAdditionalTicksVisible;
        private bool _isXAxisSignaturesVisible;
        private bool _isXAxisZeroLineVisible;
        private bool _isXAxisDescriptionVisible;
        private bool _isYAxisPrimaryTicksVisible;
        private bool _isYAxisAdditionalTicksVisible;
        private bool _isYAxisSignaturesVisible;
        private bool _isYAxisZeroLineVisible;
        private bool _isYAxisDescriptionVisible;
        private bool _isBorderVisible;
        private string _title;
        private string _xAxisName;
        private string _xAxisUnit;
        private string _yAxisName;
        private string _yAxisUnit;
        private float _xMin;
        private float _xMax;
        private float _yMin;
        private float _yMax;
        private int _xAxisPrimaryTicksCount;
        private int _xAxisAdditionalTicksCount;
        private int _yAxisPrimaryTicksCount;
        private int _yAxisAdditionalTicksCount;
        private float _xAxisPrimaryTickThickness;
        private float _xAxisAdditionalTickThickness;
        private float _xAxisZeroLineThickness;
        private float _yAxisPrimaryTickThickness;
        private float _yAxisAdditionalTickThickness;
        private float _yAxisZeroLineThickness;
        private float _borderThickness;
        private float[] _xAxisPrimaryTicksDashArray;
        private float[] _xAxisAdditionalTicksDashArray;
        private float[] _xAxisZeroLineDashArray;
        private float[] _yAxisPrimaryTicksDashArray;
        private float[] _yAxisAdditionalTicksDashArray;
        private float[] _yAxisZeroLineDashArray;
        private Color _xAxisPrimaryTicksColor;
        private Color _xAxisAdditionalTicksColor;
        private Color _xAxisZeroLineColor;
        private Color _yAxisPrimaryTicksColor;
        private Color _yAxisAdditionalTicksColor;
        private Color _yAxisZeroLineColor;
        private Color _borderColor;
        private TextStyle _textStyle;

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

        /// <inheritdoc />
        public void SetDefaultTicks()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void SetTicks(List<AxisTick> ticks)
        {
            throw new System.NotImplementedException();
        }
    }
}