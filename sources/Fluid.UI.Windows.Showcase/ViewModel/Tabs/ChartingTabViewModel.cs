using System;
using System.Threading.Tasks;
using Fluid.Core.Base;
using Fluid.Core.Services.Interfaces;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Enums;
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
        /// Gets input service.
        /// </summary>
        public IInputService InputService { get; private set; }

        /// <summary>
        /// Gets drawing element presentation.
        /// </summary>
        public IChartPresentation ChartPresentation { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            DrawingService = App.Core.GetService<IDrawingService>();
            ThemeService = App.Core.GetService<IThemeService>();
            InputService = App.Core.GetService<IInputService>();

            ChartPresentation = new DataSetChartPresentation(DrawingService, ThemeService, InputService);
            ChartPresentation.Initialize();

            var context = ChartPresentation.DataContext as IDataSetChartViewModel;
            if (context == null) return;

            context.Update();

            var num1 = 128;
            var random1 = new Random();
            var points1 = new Point[num1];
            for (var i = 0; i < num1; i++)
            {
                points1[i].X = i / (float)num1;
                points1[i].Y = (float)random1.NextDouble() - 0.5f;
            }

            var dataSet1 = new DataSet(points1) { Color = ThemeService.SelectedTheme.GetMiscellaneousColor("Success-Brush"), Type = DataSetType.Bar };
            context.AddDataSet(dataSet1);

            var num2 = 64;
            var random2 = new Random();
            var points2 = new Point[num2];
            for (var i = 0; i < num2; i++)
            {
                points2[i].X = i / (float)num2;
                points2[i].Y = (float)random2.NextDouble() - 0.5f;
            }

            var dataSet2 = new DataSet(points2) { Color = ThemeService.SelectedTheme.GetMiscellaneousColor("Error-Brush"), Type = DataSetType.Bar };
            context.AddDataSet(dataSet2);

            //var task = new Task(async delegate
            //{
            //    do
            //    {
            //        for (var i = 0; i < num1; i++)
            //        {
            //            points1[i].X = i / (float)num1;
            //            points1[i].Y = (float)random1.NextDouble() - 0.5f;
            //        }

            //        for (var i = 0; i < num2; i++)
            //        {
            //            points2[i].X = i / (float)num2;
            //            points2[i].Y = (float)random2.NextDouble() - 0.5f;
            //        }

            //        context.UpdateDataSet(0, points1);
            //        context.UpdateDataSet(1, points2);

            //        await Task.Delay(TimeSpan.FromMilliseconds(1000 / 60.0d)).ConfigureAwait(false);

            //    } while (true);
            //});

            //task.Start();
        }
    }
}