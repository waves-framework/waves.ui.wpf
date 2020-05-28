using Microsoft.Xaml.Behaviors;

namespace Waves.UI.Windows.Behaviors.Interfaces
{
    /// <summary>
    /// Interfaces of behavior creator.
    /// </summary>
    public interface IBehaviorCreator
    {
        /// <summary>
        /// Creates behavior.
        /// </summary>
        /// <returns>Behavior.</returns>
        Behavior Create();
    }
}