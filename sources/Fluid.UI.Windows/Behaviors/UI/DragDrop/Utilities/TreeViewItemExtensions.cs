﻿namespace Fluid.UI.Windows.Behaviors.UI.DragDrop.Utilities
{
    /// <summary>
    /// Extension methods for TreeViewItem
    /// </summary>
    public static class TreeViewItemExtensions
    {
        /// <summary>
        /// Try get the height of the header part for the given TreeViewItem.
        /// If there is no PART_Header it will return Size.Empty.
        /// </summary>
        /// <param name="item">The TreeViewItem.</param>
        public static System.Windows.Size GetHeaderSize(this TreeViewItem item)
        {
            if (item == null)
            {
                return System.Windows.Size.Empty;
            }
            var header = GetHeaderControl(item);
            return header != null ? new System.Windows.Size(header.ActualWidth, header.ActualHeight) : item.RenderSize;
        }

        /// <summary>
        /// Try get the header part of the given TreeViewItem.
        /// If there is no PART_Header it will return null.
        /// </summary>
        /// <param name="item">The TreeViewItem.</param>
        public static FrameworkElement GetHeaderControl(this TreeViewItem item)
        {
            return item?.Template?.FindName("PART_Header", item) as FrameworkElement;
        }
    }
}