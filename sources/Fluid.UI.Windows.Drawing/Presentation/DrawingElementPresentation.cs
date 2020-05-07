using System;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Presentation.Interfaces;
using Fluid.UI.Windows.Drawing.Services.Interfaces;

namespace Fluid.UI.Windows.Drawing.Presentation
{
    /// <summary>
    /// Drawing element presentation.
    /// </summary>
    public class DrawingElementPresentation : Fluid.Presentation.Base.Presentation, IDrawingElementPresentation
    {
        private readonly IDrawingService _drawingService;

        private IPresentationViewModel _dataContext;
        private IPresentationView _view;

        /// <summary>
        /// Creates new instance of <see cref="DrawingElementPresentation"/>
        /// </summary>
        /// <param name="drawingService"></param>
        public DrawingElementPresentation(IDrawingService drawingService)
        {
            _drawingService = drawingService;

            SubscribeEvents();
        }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => _dataContext;

        /// <inheritdoc />
        public override IPresentationView View => _view;

        /// <inheritdoc />
        public override void Initialize()
        {
            if (_drawingService == null) return;

            _dataContext = _drawingService.CurrentEngine.GetViewModel();
            _view = _drawingService.CurrentEngine.GetView();

            OnPropertyChanged(nameof(DataContext));
            OnPropertyChanged(nameof(View));

            base.Initialize();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            _drawingService.EngineChanged -= OnDrawingServiceEngineChanged;
        }

        /// <summary>
        /// Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
            _drawingService.EngineChanged += OnDrawingServiceEngineChanged;
        }

        /// <summary>
        /// Actions when drawing engine changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnDrawingServiceEngineChanged(object sender, EventArgs e)
        {
            var dataContext = _drawingService.CurrentEngine.GetViewModel();
            if (dataContext == null) return;

            var currentContext = _dataContext as IDrawingElementPresentationViewModel;
            if (currentContext == null) return;

            var view = _drawingService.CurrentEngine.GetView();

            foreach (var obj in currentContext.DrawingObjects) 
                dataContext.AddDrawingObject(obj);

            _dataContext = dataContext;
            _view = view;

            _view.DataContext = _dataContext;

            OnPropertyChanged(nameof(DataContext));
            OnPropertyChanged(nameof(View));
        }
    }
}