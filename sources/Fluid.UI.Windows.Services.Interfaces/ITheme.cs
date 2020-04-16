using System;
using System.Windows;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;

namespace Fluid.UI.Windows.Services.Interfaces
{
    /// <summary>
    ///     Interface of theme.
    /// </summary>
    public interface ITheme : IObservableObject
    {
        /// <summary>
        ///     Gets whether theme is dark.
        /// </summary>
        bool IsDark { get; }

        /// <summary>
        ///     Gets theme ID.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        ///     Gets theme name.
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Gets theme primary resource dictionary.
        /// </summary>
        ResourceDictionary PrimaryColorResourceDictionary { get; }

        /// <summary>
        ///     Gets theme accent resource dictionary.
        /// </summary>
        ResourceDictionary AccentColorResourceDictionary { get; }

        /// <summary>
        ///     Gets theme miscellaneous resource dictionary.
        /// </summary>
        ResourceDictionary MiscellaneousResourceDictionary { get; }

        /// <summary>
        ///     Gets primary color by weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns>Color.</returns>
        Color GetPrimaryColor(int weight);

        /// <summary>
        ///     Gets primary foreground color by weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns>Color.</returns>
        Color GetPrimaryForegroundColor(int weight);

        /// <summary>
        ///     Gets accent color by weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns>Color.</returns>
        Color GetAccentColor(int weight);

        /// <summary>
        ///     Gets accent foreground color by weight.
        /// </summary>
        /// <param name="weight">Weight.</param>
        /// <returns>Color.</returns>
        Color GetAccentForegroundColor(int weight);

        /// <summary>
        ///     Gets miscellaneous color by key.
        /// </summary>
        /// <param name="key">Color key.</param>
        /// <returns>Color.</returns>
        Color GetMiscellaneousColor(string key);
    }
}