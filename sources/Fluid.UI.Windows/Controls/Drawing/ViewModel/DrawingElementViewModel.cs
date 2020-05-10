using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using Fluid.Core.Base;
using Fluid.Presentation.Base;
using Fluid.UI.Windows.Controls.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.ViewModel
{
    /// <summary>
    ///     Drawing element view model base.
    /// </summary>
    public class DrawingElementViewModel : PresentationViewModel, IDrawingElementViewModel
    {
        private readonly object _collectionLocker = new object();

        /// <summary>
        /// Creates new instance of <see cref="DrawingElementViewModel"/>.
        /// </summary>
        public DrawingElementViewModel(IDrawingElement drawingElement)
        {
            DrawingElement = drawingElement;
        }

        /// <summary>
        ///     Redrawing requested event handler.
        /// </summary>
        public event EventHandler RedrawRequested;

        /// <summary>
        ///     Gets or sets whether is drawing initialized.
        /// </summary>
        public bool IsDrawingInitialized { get; set; }

        /// <summary>
        ///     Gets or sets width.
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        ///     Gets or sets height.
        /// </summary>
        public float Height { get; set; }

        /// <inheritdoc />
        public Color Foreground { get; set; } = Color.Black;

        /// <inheritdoc />
        public Color Background { get; set; } = Color.White;

        /// <summary>
        ///     Gets or sets drawing element.
        /// </summary>
        public IDrawingElement DrawingElement { get; set; }

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
        public virtual void Update()
        {
            OnRedrawRequested();
        }

        /// <summary>
        ///     Draws objects.
        /// </summary>
        public virtual void Draw(object element)
        {
            DrawingElement?.Draw(element, DrawingObjects);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            DrawingElement?.Dispose();
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
    }
}