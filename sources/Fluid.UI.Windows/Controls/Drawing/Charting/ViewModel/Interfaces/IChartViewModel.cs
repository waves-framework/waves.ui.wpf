using System.Collections.Generic;
using Fluid.Core.Base;
using Fluid.Core.Services.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces
{
    /// <summary>
    /// Interface for chart view model.
    /// </summary>
    public interface IChartViewModel : IDrawingElementViewModel
    {
        /// <summary>
        ///     Gets or sets whether zoom is enabled.
        /// </summary>
        bool IsZoomEnabled { get; set; }

        /// <summary>
        ///     Gets or sets whether title is visible.
        /// </summary>
        bool IsTitleVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether X axis primary ticks is visible.
        /// </summary>
        bool IsXAxisPrimaryTicksVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether X axis additional ticks is visible.
        /// </summary>
        bool IsXAxisAdditionalTicksVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether X axis signatures is visible.
        /// </summary>
        bool IsXAxisSignaturesVisible { get; set; }

        /// <summary>
        ///     Gets or sets X axis zero line is visible.
        /// </summary>
        bool IsXAxisZeroLineVisible { get; set; }

        /// <summary>
        ///     Gets or sets X axis descriptions is visible.
        /// </summary>
        bool IsXAxisDescriptionVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether Y axis primary ticks is visible.
        /// </summary>
        bool IsYAxisPrimaryTicksVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether Y axis additional ticks is visible.
        /// </summary>
        bool IsYAxisAdditionalTicksVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether Y axis signatures is visible.
        /// </summary>
        bool IsYAxisSignaturesVisible { get; set; }

        /// <summary>
        ///     Gets or sets Y axis zero line is visible.
        /// </summary>
        bool IsYAxisZeroLineVisible { get; set; }

        /// <summary>
        ///     Gets or sets Y axis description is visible.
        /// </summary>
        bool IsYAxisDescriptionVisible { get; set; }

        /// <summary>
        ///     Gets or sets chart border visibility.
        /// </summary>
        bool IsBorderVisible { get; set; }

        /// <summary>
        ///     Gets or sets whether zooming around X axis zero.
        /// </summary>
        bool IsXAxisZoomAroundZero { get; set; }

        /// <summary>
        ///     Gets or sets whether zooming around Y axis zero.
        /// </summary>
        bool IsYAxisZoomAroundZero { get; set; }

        /// <summary>
        ///     Gets or sets chart title.
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///     Gets or sets X axis name.
        /// </summary>
        string XAxisName { get; set; }

        /// <summary>
        ///     Gets or sets X axis unit.
        /// </summary>
        string XAxisUnit { get; set; }

        /// <summary>
        ///     Gets or sets Y axis name.
        /// </summary>
        string YAxisName { get; set; }

        /// <summary>
        ///     Gets or sets Y axis unit.
        /// </summary>
        string YAxisUnit { get; set; }

        /// <summary>
        ///     Gets or sets minimum boundary along the X axis.
        /// </summary>
        float XMin { get; set; }

        /// <summary>
        ///     Gets or sets maximum boundary along the X axis.
        /// </summary>
        float XMax { get; set; }

        /// <summary>
        ///     Gets or sets minimum boundary along the Y axis.
        /// </summary>
        float YMin { get; set; }

        /// <summary>
        ///     Gets or sets maximum boundary along the Y axis.
        /// </summary>
        float YMax { get; set; }

        /// <summary>
        ///     Gets or sets X axis primary ticks count.
        /// </summary>
        int XAxisPrimaryTicksCount { get; set; }

        /// <summary>
        ///     Gets or sets X axis additional ticks count.
        /// </summary>
        int XAxisAdditionalTicksCount { get; set; }

        /// <summary>
        ///     Gets or sets Y axis primary ticks count.
        /// </summary>
        int YAxisPrimaryTicksCount { get; set; }

        /// <summary>
        ///     Gets or sets Y axis additional ticks count.
        /// </summary>
        int YAxisAdditionalTicksCount { get; set; }

        /// <summary>
        ///     Gets or sets X axis primary tick thickness.
        /// </summary>
        float XAxisPrimaryTickThickness { get; set; }

        /// <summary>
        ///     Gets or sets X axis additional tick thickness.
        /// </summary>
        float XAxisAdditionalTickThickness { get; set; }

        /// <summary>
        ///     Gets or sets X axis zero line thickness.
        /// </summary>
        float XAxisZeroLineThickness { get; set; }

        /// <summary>
        ///     Gets or sets Y axis primary tick thickness.
        /// </summary>
        float YAxisPrimaryTickThickness { get; set; }

        /// <summary>
        ///     Gets or sets Y axis additional tick thickness.
        /// </summary>
        float YAxisAdditionalTickThickness { get; set; }

        /// <summary>
        ///     Gets or sets Y axis zero line thickness.
        /// </summary>
        float YAxisZeroLineThickness { get; set; }

        /// <summary>
        ///     Gets or sets chart border thickness.
        /// </summary>
        float BorderThickness { get; set; }

        /// <summary>
        ///     Gets or sets X axis primary ticks dash array.
        /// </summary>
        float[] XAxisPrimaryTicksDashArray { get; set; }

        /// <summary>
        ///     Gets or sets X axis additional ticks dash array.
        /// </summary>
        float[] XAxisAdditionalTicksDashArray { get; set; }

        /// <summary>
        ///     Gets or sets X axis zero line dash array.
        /// </summary>
        float[] XAxisZeroLineDashArray { get; set; }

        /// <summary>
        ///     Gets or sets Y axis primary ticks dash array.
        /// </summary>
        float[] YAxisPrimaryTicksDashArray { get; set; }

        /// <summary>
        ///     Gets or sets Y axis additional ticks dash array.
        /// </summary>
        float[] YAxisAdditionalTicksDashArray { get; set; }

        /// <summary>
        ///     Gets or sets Y axis zero line dash array.
        /// </summary>
        float[] YAxisZeroLineDashArray { get; set; }

        /// <summary>
        ///     Gets or sets X axis primary ticks color.
        /// </summary>
        Color XAxisPrimaryTicksColor { get; set; }

        /// <summary>
        ///     Gets or sets X axis additional ticks color.
        /// </summary>
        Color XAxisAdditionalTicksColor { get; set; }

        /// <summary>
        ///     Gets or sets X axis zero line color.
        /// </summary>
        Color XAxisZeroLineColor { get; set; }

        /// <summary>
        ///     Gets or sets Y axis primary ticks color.
        /// </summary>
        Color YAxisPrimaryTicksColor { get; set; }

        /// <summary>
        ///     Gets or sets Y axis additional ticks color.
        /// </summary>
        Color YAxisAdditionalTicksColor { get; set; }

        /// <summary>
        ///     Gets or sets Y axis zero line color.
        /// </summary>
        Color YAxisZeroLineColor { get; set; }

        /// <summary>
        ///     Gets or sets chart border color.
        /// </summary>
        Color BorderColor { get; set; }

        /// <summary>
        ///     Gets or sets chart text style.
        /// </summary>
        TextStyle TextStyle { get; set; }

        /// <summary>
        /// Gets or sets input service.
        /// </summary>
        IInputService InputService { get; set; }

        /// <summary>
        /// Sets default ticks.
        /// </summary>
        void SetDefaultTicks();

        /// <summary>
        /// Sets one's own ticks.
        /// </summary>
        /// <param name="ticks">Ticks.</param>
        void SetTicks(List<AxisTick> ticks);
    }
}