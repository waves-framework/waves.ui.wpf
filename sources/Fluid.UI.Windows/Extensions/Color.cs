namespace Fluid.UI.Windows.Extensions
{
    public static class Color
    {
        public static Core.Color ToFluidColor(this System.Windows.Media.Color color)
        {
            return new Core.Color(color.A, color.R, color.G, color.B);
        }
    }
}