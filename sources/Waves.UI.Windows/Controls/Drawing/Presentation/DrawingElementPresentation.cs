using System;
using Waves.Core.Services.Interfaces;
using Waves.Presentation.Interfaces;
using Waves.UI.Windows.Controls.Drawing.Presentation.Interfaces;
using Waves.UI.Windows.Controls.Drawing.View.Interfaces;
using Waves.UI.Windows.Controls.Drawing.ViewModel;
using Waves.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Waves.UI.Windows.Services.Interfaces;

namespace Waves.UI.Windows.Controls.Drawing.Presentation
{
    /// <summary>
    ///     Drawing element presentation.
    /// </summary>
    public class DrawingElementPresentation : Waves.Presentation.Base.Presentation, IDrawingElementPresentation
    {
        /// <summary>
        ///     Creates new instance of <see cref="DrawingElementPresentation" />
        /// </summary>
        /// <param name="drawingService">Drawing service.</param>
        /// <param name="inputService">Input service.</param>
        public DrawingElementPresentation(IDrawingService drawingService, IInputService inputService)
        {
            DrawingService = drawingService;
            InputService = inputService;
        }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => DataContextBackingField;

        /// <inheritdoc />
        public override IPresentationView View => ViewBackingField;

        /// <summary>
        ///     Gets or sets Data context's backing field.
        /// </summary>
        protected IDrawingElementViewModel DataContextBackingField;

        /// <summary>
        ///     Gets or sets View's backing field.
        /// </summary>
        protected IDrawingElementView ViewBackingField;

        /// <summary>
        ///     Gets or sets drawing service.
        /// </summary>
        protected IDrawingService DrawingService { get; set; }

        /// <summary>
        /// Gets or sets input service.
        /// </summary>
        protected IInputService InputService { get; set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (DrawingService?.CurrentEngine == null) return;

            SubscribeEvents();

            DataContextBackingField = new DrawingElementViewModel(DrawingService.CurrentEngine.GetDrawingElement());
            ViewBackingField = DrawingService.CurrentEngine.GetView(InputService);

            OnPropertyChanged(nameof(DataContext));
            OnPropertyChanged(nameof(View));

            base.Initialize();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            DrawingService.EngineChanged -= OnDrawingServiceEngineChanged;
        }

        /// <summary>
        ///     Actions when drawing engine changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnDrawingServiceEngineChanged(object sender, EventArgs e)
        {
            var dataContext = new DrawingElementViewModel(DrawingService.CurrentEngine.GetDrawingElement());

            var currentContext = DataContextBackingField;
            if (currentContext == null) return;

            var view = DrawingService.CurrentEngine.GetView(InputService);

            DataContextBackingField = dataContext;
            ViewBackingField = view;

            ViewBackingField.DataContext = DataContextBackingField;

            dataContext.Update();

            OnPropertyChanged(nameof(DataContext));
            OnPropertyChanged(nameof(View));
        }

        /// <summary>
        ///     Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
            DrawingService.EngineChanged += OnDrawingServiceEngineChanged;
        }
    }
}