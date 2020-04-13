using System.Windows;

namespace Fluid.UI.Windows.Controls.Helpers
{
    /// <summary>
    /// TextBox's dependency property helper.
    /// </summary>
    public class TextBox
    {
        /// <summary>
        ///     Gets or sets "Description" dependency property.
        /// </summary>
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.RegisterAttached("Description", typeof(string), typeof(TextBox),
                new UIPropertyMetadata(string.Empty));

        /// <summary>
        /// Gets description.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <returns>Description value.</returns>
        public static string GetDescription(DependencyObject obj)
        {
            return (string) obj.GetValue(DescriptionProperty);
        }

        /// <summary>
        ///     Sets description.
        /// </summary>
        /// <param name="obj">Dependency object.</param>
        /// <param name="value">Description value.</param>
        public static void SetDescription(DependencyObject obj, string value)
        {
            obj.SetValue(DescriptionProperty, value);
        }
    }
}