using System;
using Fluid.Core.Base;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Presentation;
using Fluid.UI.Windows.Controls.Drawing.Charting.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    ///     View model for charts tab.
    /// </summary>
    public class ChartingTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets drawing service.
        /// </summary>
        public IDrawingService DrawingService { get; private set; }

        /// <summary>
        /// Gets themes service.
        /// </summary>
        public IThemeService ThemeService { get; private set; }

        /// <summary>
        /// Gets drawing element presentation.
        /// </summary>
        public IChartPresentation ChartPresentation { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            DrawingService = App.Core.GetService<IDrawingService>();
            ThemeService = App.Core.GetService<IThemeService>();

            ChartPresentation = new DataSetChartPresentation(DrawingService, ThemeService);
            ChartPresentation.Initialize();

            var context = ChartPresentation.DataContext as IDataSetChartViewModel;
            if (context == null) return;

            context.Update();

            var num = 128;
            var random = new Random();
            var points = new Point[num];
            for (var i = 0; i < num; i++)
            {
                points[i].X = i / (float)num;
                points[i].Y = (float)random.NextDouble() - 0.5f;
            }

            var dataSet = new DataSet(points) {Color = ThemeService.SelectedTheme.GetAccentColor(500)};
            context.AddDataSet(dataSet);
        }
    }
}