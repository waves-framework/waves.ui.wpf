using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using Waves.UI.WPF.Behaviors.Interfaces;
using Microsoft.Xaml.Behaviors;

namespace Waves.UI.WPF.Behaviors
{
    /// <summary>
    /// Behavior for progress bar animation.
    /// </summary>
    public class ProgressBarAnimationBehavior : Behavior<ProgressBar>, IBehaviorCreator
    {
        private bool _isAnimating = false;

        private DoubleAnimation _animation;

        /// <inheritdoc />
        public Behavior Create()
        {
            return new ProgressBarAnimationBehavior();
        }

        /// <inheritdoc />
        protected override void OnAttached()
        {
            base.OnAttached();
            var progressBar = AssociatedObject;
            progressBar.ValueChanged += OnProgressBarValueChanged;
        }

        /// <inheritdoc />
        protected override void OnDetaching()
        {
            base.OnDetaching();
            var progressBar = AssociatedObject;
            progressBar.ValueChanged -= OnProgressBarValueChanged;
        }

        /// <summary>
        /// Actions when progress bar value changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnProgressBarValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isAnimating)
                return;

            if (!(sender is ProgressBar progressBar)) return;

            _isAnimating = true;

            _animation = new DoubleAnimation(e.OldValue, e.NewValue, new Duration(TimeSpan.FromMilliseconds(100)), FillBehavior.Stop);

            _animation.Completed += OnAnimationCompleted;

            progressBar.BeginAnimation(RangeBase.ValueProperty, _animation);

            e.Handled = true;
        }

        /// <summary>
        /// Actions when animation completed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            _isAnimating = false;

            _animation.Completed -= OnAnimationCompleted;
        }
    }
}