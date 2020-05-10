using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;
using Fluid.Core.Services.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.View;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Presentation
{
    /// <summary>
    /// Data set chart presentation.
    /// </summary>
    public class DataSetChartPresentation : ChartPresentation, IChartPresentation
    {
        private ObservableCollection<IDataSet> _oldDataSets = new ObservableCollection<IDataSet>();

        /// <inheritdoc />
        public DataSetChartPresentation(IDrawingService drawingService, IThemeService themeService, IInputService inputService) : base(drawingService, themeService, inputService)
        {
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            Update();
        }

        /// <inheritdoc />
        protected override void Update()
        {
            if (DrawingService == null) return;
            if (ThemeService == null) return;

            var drawingElement = DrawingService.CurrentEngine.GetDrawingElement();
            var dataContext = new DataSetChartViewModel(drawingElement);
            var view = new ChartView()
            {
                DrawingElementView = (FrameworkElement)DrawingService.CurrentEngine.GetView()
            };

            if (_oldDataSets != null)
            {
                foreach (var dataSet in _oldDataSets)
                    dataContext.AddDataSet(dataSet);

                _oldDataSets.Clear();
            }

            DataContextBackingField = dataContext;
            ViewBackingField = view;

            InitializeColors();

            OnPropertyChanged(nameof(DataContext));
            OnPropertyChanged(nameof(View));

            base.Initialize();

            SubscribeEvents();

            dataContext.Update();
        }

        /// <summary>
        /// Initialize colors.
        /// </summary>
        protected override void InitializeColors()
        {
            base.InitializeColors();

            var context = DataContextBackingField as DataSetChartViewModel;
            if (context == null) return;
        }

        /// <inheritdoc />
        protected override void OnDrawingServiceEngineChanged(object sender, EventArgs e)
        {
            var context = DataContextBackingField as IDataSetChartViewModel;
            if (context == null) return;

            _oldDataSets = context.DataSets;

            UnsubscribeEvents();

            Update();
        }

        /// <summary>
        /// Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
            var view = View as ChartView;
            if (view == null) return;

            view.DrawingElementView.MouseMove += OnMouseMove;
            view.DrawingElementView.MouseEnter += OnMouseEnter;
            view.DrawingElementView.MouseLeave += OnMouseLeave;
            view.DrawingElementView.MouseDown += OnMouseDown;
            view.DrawingElementView.MouseUp += OnMouseUp;
            view.DrawingElementView.MouseWheel += OnMouseWheel;
            view.DrawingElementView.TouchEnter += OnTouchEnter;

            //view.DrawingElementView.ManipulationDelta += OnManipulationDelta;
        }

        /// <summary>
        /// Unsubscribes events.
        /// </summary>
        private void UnsubscribeEvents()
        {
            var view = View as ChartView;
            if (view == null) return;

            view.DrawingElementView.MouseMove -= OnMouseMove;
            view.DrawingElementView.MouseEnter -= OnMouseEnter;
            view.DrawingElementView.MouseLeave -= OnMouseLeave;
            view.DrawingElementView.MouseDown -= OnMouseDown;
            view.DrawingElementView.MouseUp -= OnMouseUp;
            view.DrawingElementView.MouseWheel -= OnMouseWheel;
            view.DrawingElementView.TouchEnter -= OnTouchEnter;

            //view.DrawingElementView.ManipulationDelta += OnManipulationDelta;
        }
    }
}