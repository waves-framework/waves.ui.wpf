using System;
using System.Windows;

namespace Fluid.UI.Windows.Services.Interfaces
{
    /// <summary>
    /// Интерфейс темы.
    /// </summary>
    public interface ITheme
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Словарь основных цветов.
        /// </summary>
        ResourceDictionary PrimaryColorDictionaryInfo { get; set; }

        /// <summary>
        /// Словарь акцентных цветов.
        /// </summary>
        ResourceDictionary AccentColorDictionaryInfo { get; set; }

        /// <summary>
        /// Словарь дополнительных цветов.
        /// </summary>
        ResourceDictionary MiscellaneousColorDictionaryInfo { get; set; }
    }
}