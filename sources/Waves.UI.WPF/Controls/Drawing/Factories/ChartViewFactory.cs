using Waves.UI.Drawing.Charting.Base.Interfaces;
using Waves.UI.Drawing.Charting.View.Interface;
using Waves.UI.WPF.Controls.Drawing.Charting.View;

namespace Waves.UI.WPF.Controls.Drawing.Factories
{
    /// <summary>
    /// Chart view factory.
    /// </summary>
    public class ChartViewFactory : IChartViewFactory
    {
        /// <inheritdoc />
        public IChartPresenterView GetChartView()
        {
            return new ChartView();
        }
    }
}