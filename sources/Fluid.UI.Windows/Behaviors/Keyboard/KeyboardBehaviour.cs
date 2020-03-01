namespace Fluid.UI.Windows.Behaviors.Keyboard
{
    public class KeyboardBehaviour
    {
        #region KeyDown

        public static readonly DependencyProperty KeyDownCommandProperty =
            DependencyProperty.RegisterAttached("KeyDownCommand", typeof(ICommand), typeof(KeyboardBehaviour),
                new FrameworkPropertyMetadata(KeyDownCommandChanged));

        private static void KeyDownCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement) d;

            element.KeyDown += Element_KeyDown;
        }

        private static void Element_KeyDown(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement) sender;

            var command = GetKeyDownCommand(element);

            command.Execute(e);
        }

        public static void SetKeyDownCommand(UIElement element, ICommand value)
        {
            element.SetValue(KeyDownCommandProperty, value);
        }

        public static ICommand GetKeyDownCommand(UIElement element)
        {
            return (ICommand) element.GetValue(KeyDownCommandProperty);
        }

        #endregion

        #region KeyUp

        public static readonly DependencyProperty KeyUpCommandProperty =
            DependencyProperty.RegisterAttached("KeyUpCommand", typeof(ICommand), typeof(KeyboardBehaviour),
                new FrameworkPropertyMetadata(KeyUpCommandChanged));

        private static void KeyUpCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = (FrameworkElement) d;

            element.KeyUp += Element_KeyUp;
        }

        private static void Element_KeyUp(object sender, KeyEventArgs e)
        {
            var element = (FrameworkElement) sender;

            var command = GetKeyUpCommand(element);

            command.Execute(e);
        }

        public static void SetKeyUpCommand(UIElement element, ICommand value)
        {
            element.SetValue(KeyUpCommandProperty, value);
        }

        public static ICommand GetKeyUpCommand(UIElement element)
        {
            return (ICommand) element.GetValue(KeyUpCommandProperty);
        }

        #endregion
    }
}