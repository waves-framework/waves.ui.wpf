using System;
using Waves.UI.Base.Interfaces;

namespace Waves.UI.Windows.Base
{
    /// <summary>
    ///     Theme.
    /// </summary>
    public class Theme : UI.Base.Theme
    {
        /// <summary>
        /// Creates new instance of <see cref="Theme"/>.
        /// </summary>
        /// <param name="id">Theme's id.</param>
        /// <param name="name">Theme's name.</param>
        /// <param name="lightColorSet">Primary light color set.</param>
        /// <param name="darkColorSet">Primary dark color set.</param>
        /// <param name="accentColorSet">Accent color set.</param>
        /// <param name="miscellaneousColorSet">Miscellaneous color set.</param>
        public Theme(
            Guid id,
            string name,
            IPrimaryColorSet lightColorSet,
            IPrimaryColorSet darkColorSet,
            IAccentColorSet accentColorSet,
            IMiscellaneousColorSet miscellaneousColorSet)
            : base(
                id,
                name,
                lightColorSet,
                darkColorSet,
                accentColorSet,
                miscellaneousColorSet)
        {
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            PrimaryLightColorSet.Dispose();
            PrimaryDarkColorSet.Dispose();
            AccentColorSet.Dispose();
            MiscellaneousColorSet.Dispose();
        }
    }
}