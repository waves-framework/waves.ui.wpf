﻿namespace Fluid.UI.Windows.Behaviors.UI.DragDrop
{
    public class DropTargetHighlightAdorner : DropTargetAdorner
    {
        [Obsolete("This constructor is obsolete and will be deleted in next major release.")]
        public DropTargetHighlightAdorner(UIElement adornedElement)
            : base(adornedElement, (DropInfo)null)
        {
        }

        public DropTargetHighlightAdorner(UIElement adornedElement, DropInfo dropInfo)
            : base(adornedElement, dropInfo)
        {
        }

        /// <summary>
        /// When overridden in a derived class, participates in rendering operations that are directed by the layout system.
        /// The rendering instructions for this element are not used directly when this method is invoked, and are instead preserved for
        /// later asynchronous use by layout and drawing.
        /// </summary>
        /// <param name="drawingContext">The drawing instructions for a specific element. This context is provided to the layout system.</param>
        protected override void OnRender(DrawingContext drawingContext)
        {
            var dropInfo = this.DropInfo;
            var visualTargetItem = dropInfo.VisualTargetItem;
            if (visualTargetItem != null)
            {
                var rect = Rect.Empty;

                var tvItem = visualTargetItem as TreeViewItem;
                if (tvItem != null && VisualTreeHelper.GetChildrenCount(tvItem) > 0)
                {
                    var descendant = VisualTreeHelper.GetDescendantBounds(tvItem);
                    var translatePoint = tvItem.TranslatePoint(new Point(), this.AdornedElement);
                    var itemRect = new Rect(translatePoint, tvItem.RenderSize);
                    descendant.Union(itemRect);
                    translatePoint.Offset(1, 0);
                    rect = new Rect(translatePoint, new System.Windows.Size(descendant.Width - translatePoint.X - 1, tvItem.ActualHeight));
                }
                if (rect.IsEmpty)
                {
                    rect = new Rect(visualTargetItem.TranslatePoint(new Point(), this.AdornedElement), VisualTreeHelper.GetDescendantBounds(visualTargetItem).Size);
                }
                drawingContext.DrawRoundedRectangle(null, this.Pen, rect, 2, 2);
            }
        }
    }
}