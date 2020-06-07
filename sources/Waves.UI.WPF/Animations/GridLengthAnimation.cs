using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace Waves.UI.WPF.Animations
{
    /// <summary>
    ///     Grid length animation.
    /// </summary>
    public class GridLengthAnimation : AnimationTimeline
    {
        /// <summary>
        ///     Creates new instance of <see cref="GridLengthAnimation" />.
        /// </summary>
        static GridLengthAnimation()
        {
            FromProperty = DependencyProperty.Register("From", typeof(GridLength),
                typeof(GridLengthAnimation));

            ToProperty = DependencyProperty.Register("To", typeof(GridLength),
                typeof(GridLengthAnimation));
        }

        /// <summary>
        ///     Gets target's property type.
        /// </summary>
        public override Type TargetPropertyType => typeof(GridLength);

        /// <summary>
        ///     Creates new instance of grid length animation.
        /// </summary>
        /// <returns>Instance of grid length animation.</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new GridLengthAnimation();
        }

        /// <summary>
        ///     Gets "From" property.
        /// </summary>
        public static readonly DependencyProperty FromProperty;

        /// <summary>
        ///     Gets "To" property.
        /// </summary>
        public static readonly DependencyProperty ToProperty;

        /// <summary>
        ///     Gets or sets "From" property.
        /// </summary>
        public GridLength From
        {
            get => (GridLength) GetValue(FromProperty);
            set => SetValue(FromProperty, value);
        }

        /// <summary>
        ///     Gets or sets "To" property.
        /// </summary>
        public GridLength To
        {
            get => (GridLength) GetValue(ToProperty);
            set => SetValue(ToProperty, value);
        }

        /// <summary>
        ///     Gets current value.
        /// </summary>
        /// <param name="defaultOriginValue">Default original value.</param>
        /// <param name="defaultDestinationValue">Default destination value.</param>
        /// <param name="animationClock">Animation clock.</param>
        /// <returns>Value.</returns>
        public override object GetCurrentValue(object defaultOriginValue,
            object defaultDestinationValue, AnimationClock animationClock)
        {
            var fromVal = ((GridLength) GetValue(FromProperty)).Value;
            var toVal = ((GridLength) GetValue(ToProperty)).Value;

            if (animationClock.CurrentProgress == null) return new GridLength();

            return fromVal > toVal
                ? new GridLength((1 - animationClock.CurrentProgress.Value) * (fromVal - toVal) + toVal,
                    GridUnitType.Pixel)
                : new GridLength(animationClock.CurrentProgress.Value * (toVal - fromVal) + fromVal, GridUnitType.Pixel);
        }
    }
}