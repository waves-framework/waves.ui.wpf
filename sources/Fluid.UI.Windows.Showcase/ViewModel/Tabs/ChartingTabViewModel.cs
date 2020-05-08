using Fluid.Core.Base;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Base;
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
        /// Gets drawing element presentation.
        /// </summary>
        public IDrawingElementPresentation DrawingElementPresentation { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            DrawingService = App.Core.GetService<IDrawingService>();
            DrawingElementPresentation = DrawingService.CreatePresentation();
            DrawingElementPresentation.Initialize();

            var context = DrawingElementPresentation.DataContext as IDrawingElementViewModel;
            if (context == null) return;

            context.AddDrawingObject(new Line()
            {
                Point1 = new Point(0,0),
                Point2 = new Point(100,100),
                Stroke = Color.Black,
                StrokeThickness = 2
            });

            context.AddDrawingObject(new Ellipse()
            {
                Radius = 24,
                Location = new Point(100,100),
                Stroke = Color.Black,
                Fill = Color.Red,
                StrokeThickness = 2
            });

            context.AddDrawingObject(new Rectangle()
            {
                CornerRadius = 6,
                Width = 24,
                Height = 24,
                Location = new Point(200, 200),
                Stroke = Color.Black,
                Fill = Color.Blue,
                StrokeThickness = 2
            });

            context.AddDrawingObject(new Text()
            {
                Fill = Color.Black,
                Value = "Text sample",
                Location = new Point(300,300),
                Style = new TextStyle()
                {
                    FontSize = 12,
                    FontFamily = "Lato",
                }
            });
        }
    }
}