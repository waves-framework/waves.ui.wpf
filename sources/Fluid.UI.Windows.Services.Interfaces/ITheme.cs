using System;
using System.Collections.Generic;
using System.Windows;
using Fluid.Core.Base;
using Fluid.Core.Base.Interfaces;

namespace Fluid.UI.Windows.Services.Interfaces
{
    /// <summary>
    ///     Интерфейс темы.
    /// </summary>
    public interface ITheme : IObservableObject
    {
        /// <summary>
        /// Gets theme ID.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        ///     Получает наименование темы.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Получает словарь основных цветов.
        /// </summary>
        ResourceDictionary PrimaryColorResourceDictionary { get; }

        /// <summary>
        /// Получает словарь акцентных цветов.
        /// </summary>
        ResourceDictionary AccentColorResourceDictionary { get; }

        /// <summary>
        /// Получает словарь дополнительных цветов.
        /// </summary>
        ResourceDictionary MiscellaneousResourceDictionary { get; }

        /// <summary>
        /// Получает основной цвет по весу.
        /// </summary>
        /// <param name="weight">Вес.</param>
        /// <returns>Цвет.</returns>
        Color GetPrimaryColor(int weight);

        /// <summary>
        /// Получает основной цвет текста по весу.
        /// </summary>
        /// <param name="weight">Вес.</param>
        /// <returns>Цвет.</returns>
        Color GetPrimaryForegroundColor(int weight);

        /// <summary>
        /// Получает акцентный цвет по весу.
        /// </summary>
        /// <param name="weight">Вес.</param>
        /// <returns>Цвет.</returns>
        Color GetAccentColor(int weight);

        /// <summary>
        /// Получает акцентный цвет текста по весу.
        /// </summary>
        /// <param name="weight">Вес.</param>
        /// <returns>Цвет.</returns>
        Color GetAccentForegroundColor(int weight);

        /// <summary>
        /// Получает дополнительный цвет по ключу и весу.
        /// </summary>
        /// <param name="key">Ключ.</param>
        /// <returns>Цвет.</returns>
        Color GetMiscellaneousColor(string key);
    }
}