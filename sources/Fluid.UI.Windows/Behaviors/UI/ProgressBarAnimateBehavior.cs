namespace Fluid.UI.Windows.Behaviors.UI
{
    public class ProgressBarAnimateBehavior : Behavior<ProgressBar>
    {
        private bool _isAnimating;

        protected override void OnAttached()
        {
            base.OnAttached();
            var progressBar = AssociatedObject;
            progressBar.ValueChanged += ProgressBar_ValueChanged;
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_isAnimating)
                return;

            _isAnimating = true;

            var doubleAnimation = new DoubleAnimation
                (e.OldValue, e.NewValue, new Duration(TimeSpan.FromSeconds(0.1)), FillBehavior.Stop);
            doubleAnimation.Completed += Db_Completed;

            ((ProgressBar) sender).BeginAnimation(RangeBase.ValueProperty, doubleAnimation);

            e.Handled = true;
        }

        private void Db_Completed(object sender, EventArgs e)
        {
            _isAnimating = false;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var progressBar = AssociatedObject;
            progressBar.ValueChanged -= ProgressBar_ValueChanged;
        }
    }
}