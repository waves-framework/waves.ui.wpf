using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.UI.WPF.Showcase.View.Control
{
    /// <summary>
    ///     Логика взаимодействия для MainControlView.xaml
    /// </summary>
    public partial class MainControlView : IPresentationView
    {
        private int _previousIndex = -1;

        /// <summary>
        /// Creates new instance of main control.
        /// </summary>
        public MainControlView()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }

        /// <summary>
        /// Actions when tab selection changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnTabSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var tabControl = sender as TabControl;
            if (tabControl == null) return;

            var currentIndex = tabControl.SelectedIndex;

            if (_previousIndex == currentIndex) return;

            foreach (var grid in FindVisualChildren<Grid>(this))
            {
                if (grid.Name != "TabContentGrid") continue;

                var animation = new DoubleAnimation(0, 1, new Duration(TimeSpan.FromMilliseconds(250)), FillBehavior.HoldEnd);
                grid.BeginAnimation(Grid.OpacityProperty, animation);

                _previousIndex = currentIndex;
            }
        }

        /// <summary>
        /// Finds children in visual tree by dependency object.
        /// </summary>
        /// <typeparam name="T">Children type.</typeparam>
        /// <param name="dependencyObject">Dependency object.</param>
        /// <returns></returns>
        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            if (dependencyObject == null) yield break;

            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(dependencyObject); i++)
            {
                var child = VisualTreeHelper.GetChild(dependencyObject, i);
                if (child is T t)
                    yield return t;

                foreach (var childOfChild in FindVisualChildren<T>(child))
                    yield return childOfChild;
            }
        }
    }
}