using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Fluid.UI.Windows.Drawing.Engine.Skia.View;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.ViewModel
{
    /// <summary>
    ///     Drawing canvas view model.
    /// </summary>
    public class DrawingElementPresentationViewModel : PresentationViewModel, IDrawingElementViewModel
    {
        private readonly object _collectionLocker = new object();

        private readonly object _surfaceLocker = new object();

        private DrawingElement _drawingElement;

        /// <summary>
        ///     Gets or sets whether is drawing initialized.
        /// </summary>
        public bool IsDrawingInitialized { get; internal set; }

        /// <summary>
        ///     Redrawing requested event handler.
        /// </summary>
        public event EventHandler RedrawRequested;

        /// <summary>
        ///     Gets or sets width.
        /// </summary>
        public float Width { get; internal set; }

        /// <summary>
        ///     Gets or sets height.
        /// </summary>
        public float Height { get; internal set; }


        /// <inheritdoc />
        public ICollection<IDrawingObject> DrawingObjects { get; } = new ObservableCollection<IDrawingObject>();

        /// <inheritdoc />
        public override void Initialize()
        {
            InitializeCollectionSynchronization();
        }

        /// <inheritdoc />
        public void AddDrawingObject(IDrawingObject obj)
        {
            DrawingObjects.Add(obj);

            OnRedrawRequested();
        }

        /// <inheritdoc />
        public void RemoveDrawingObject(IDrawingObject obj)
        {
            DrawingObjects.Remove(obj);
            OnRedrawRequested();
        }

        /// <inheritdoc />
        public void Update()
        {
            OnRedrawRequested();
        }

        /// <summary>
        ///     Draws objects.
        /// </summary>
        public virtual void Draw(SKSurface surface)
        {
            if (_drawingElement == null)
            {
                _drawingElement = new DrawingElement(surface);
            }
            else
            {
                if (_drawingElement.Surface == null) _drawingElement.Surface = surface;

                if (_drawingElement.Surface.Handle == IntPtr.Zero) _drawingElement.Surface = surface;
            }

            surface.Canvas.Clear(SKColor.Empty);

            foreach (var obj in DrawingObjects)
                obj.Draw(_drawingElement);
        }

        /// <inheritdoc />
        public void Clear()
        {
            DrawingObjects.Clear();
            Update();
        }

        /// <summary>
        ///     Notifies when redrawing requested.
        /// </summary>
        protected virtual void OnRedrawRequested()
        {
            RedrawRequested?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        ///     Initializes collection synchronization.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(DrawingObjects, _collectionLocker);
        }

        /// <inheritdoc />
        public void Dispose()
        {
        }
    }
}