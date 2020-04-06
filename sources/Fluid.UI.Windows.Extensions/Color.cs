namespace Fluid.UI.Windows.Extensions
{
    /// <summary>
    /// Класс расширений для работы с цветом.
    /// </summary>
    public static class Color
    {
        /// <summary>
        /// Конвертирует System.Windows.Media.Color в Fluid.Core.Base.Color.
        /// </summary>
        /// <param name="color">Экземпляр System.Windows.Media.Color.</param>
        /// <returns>Новый экземпляр Fluid.Core.Base.Color.</returns>
        public static Fluid.Core.Base.Color ToFluidColor(this System.Windows.Media.Color color)
        {
            return new Fluid.Core.Base.Color(color.A, color.R, color.G, color.B);
        }
    }
}