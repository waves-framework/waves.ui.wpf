using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Windows.Data;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using SkiaSharp;

namespace Fluid.UI.Windows.Drawing.Engine.Skia.ViewModel
{
    /// <summary>
    /// Drawing canvas view model.
    /// </summary>
    public class DrawingElementPresentationViewModel : PresentationViewModel, IDrawingElementPresentationViewModel
    {
        private readonly object _collectionLocker = new object();

        private SKSurface _surface;

        /// <summary>
        /// Creates new instance of canvas view model.
        /// </summary>
        public DrawingElementPresentationViewModel()
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

        /// <inheritdoc />
        public bool IsDrawingInitialized { get; internal set; }

        /// <inheritdoc />
        public ICollection<IDrawingObject> DrawingObjects { get; private set; } = new ObservableCollection<IDrawingObject>();

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

        /// <summary>
        /// Sets surface pointer.
        /// </summary>
        /// <param name="ptr">Pointer.</param>
        public void SetSurfacePointer(IntPtr ptr)
        {
            var handle = GCHandle.FromIntPtr(ptr);
            
            _surface = handle.Target as SKSurface;

            if (_surface != null) 
                IsDrawingInitialized = true;
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

            if (_surface == null) return;
            if (_surface.Handle == IntPtr.Zero) return;

            _surface.Canvas.Clear(SKColors.Black);

            //foreach (var obj in DrawingObjects)
            //    obj.Draw(_surface.Canvas);
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

        /// <inheritdoc />
        public void Dispose()
        {
            _surface?.Dispose();
        }
    }
}