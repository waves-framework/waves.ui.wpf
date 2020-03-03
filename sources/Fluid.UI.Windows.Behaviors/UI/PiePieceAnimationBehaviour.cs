namespace Fluid.UI.Windows.Behaviors.UI
{
    public class PiePieceAnimationBehaviour : Behavior<PiePiece>
    {
        private bool _isAnimating;

        protected override void OnAttached()
        {
            base.OnAttached();
            var piePiece = AssociatedObject;
            piePiece.WedgeAngleChanged += OnWedgeAngleChanged;
        }

        private void OnWedgeAngleChanged(double oldValue, double newValue)
        {
            if (_isAnimating)
                return;

            _isAnimating = true;

            var doubleAnimation = new DoubleAnimation
                (oldValue, newValue, new Duration(TimeSpan.FromSeconds(0.1)), FillBehavior.Stop);
            doubleAnimation.Completed += DoubleAnimation_Completed;

            var piePiece = AssociatedObject;

            piePiece.BeginAnimation(PiePiece.WedgeAngleProperty, doubleAnimation);
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            _isAnimating = false;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            var piePiece = AssociatedObject;
            piePiece.WedgeAngleChanged -= OnWedgeAngleChanged;
        }
    }
}
