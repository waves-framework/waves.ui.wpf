using System;
using System.Collections.Generic;
using Fluid.Core.Base;
using Fluid.UI.Windows.Controls.Drawing.Interfaces;
using SkiaSharp;

namespace Fluid.UI.Windows.Controls.Drawing.Controls.Canvas.ViewModel.Interfaces
{
    /// <summary>
    /// Interface for drawing canvas.
    /// </summary>
    public interface ICanvasViewModel
    {
        /// <summary>
        ///     Gets or sets font size.
        /// </summary>
        double FontSize { get; set; }

        /// <summary>
        ///     Фон области отрисовки.
        /// </summary>
        Color Background { get; set; }

        /// <summary>
        ///     Цвет текста на области отрисовки.
        /// </summary>
        Color Foreground { get; set; }

        /// <summary>
        ///     Список отрисовываемых объектов.
        /// </summary>
        List<IDrawingObject> DrawingObjects { get; }

        /// <summary>
        ///     Событие необходимости перирисовки.
        /// </summary>
        event EventHandler RedrawRequired;

        /// <summary>
        ///     Инициализация.
        /// </summary>
        void Initialize();

        /// <summary>
        ///     Обновление области отрисовки.
        /// </summary>
        ///     Удаление объекта отрисовки.
        /// </summary>
        /// <param name="obj"></param>
        void RemoveObject(IDrawingObject obj);

        /// <summary>
        ///     Очистка области отрисовки.
        /// </summary>
        void Clear();

        /// <summary>
        ///     Отрисовка.
        /// </summary>
        /// <param name="surface"></param>
        void Draw(SKSurface surface);
    }
}