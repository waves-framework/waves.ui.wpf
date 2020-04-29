using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using Fluid.Core.Base;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Commands;
using Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Extensions;
using Fluid.UI.Windows.Controls.Drawing.Interfaces;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel
{
    /// <summary>
    /// Drawing canvas view model.
    /// </summary>
    public class CanvasViewModel : PresentationViewModel, ICanvasViewModel
    {
        private readonly object _collectionLocker = new object();

        /// <summary>
        /// Creates new instance of canvas view model.
        /// </summary>
        public CanvasViewModel()
        {

        }

        /// <summary>
        /// Redrawing requested event handler.
        /// </summary>
        public event EventHandler RedrawRequested; 

        /// <summary>
        /// Gets or sets width.
        /// </summary>
        public float Width { get; internal set; }

        /// <summary>
        /// Gets or sets height.
        /// </summary>
        public float Height { get; internal set; }

        /// <summary>
        /// Gets or sets drawing canvas.
        /// </summary>
        public SKCanvas Canvas { get; internal set; }

        /// <inheritdoc />
        public bool IsDrawingInitialized { get; internal set; }

        /// <inheritdoc />
        public ICollection<IDrawingObject> DrawingObjects { get; private set; } = new ObservableCollection<IDrawingObject>();

        /// <inheritdoc />
        public ICommand PaintCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            InitializeCollectionSynchronization();
        }

        /// <inheritdoc />
        public void AddDrawingObject(IDrawingObject obj)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void RemoveDrawingObject(IDrawingObject obj)
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public void Update()
        {
            OnRedrawRequested();
        }

        /// <inheritdoc />
        public virtual void Draw()
        {
            if (!IsDrawingInitialized) return;

            Canvas.Clear(SKColor.Empty);

            foreach (var obj in DrawingObjects)
                obj.Draw(Canvas);
        }

        /// <inheritdoc />
        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Notifies when redrawing requested.
        /// </summary>
        protected virtual void OnRedrawRequested()
        {
            RedrawRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Initializes collection synchronization.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(DrawingObjects, _collectionLocker);
        }
    }
}