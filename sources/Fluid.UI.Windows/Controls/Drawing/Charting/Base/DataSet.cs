using System;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Enums;
using Fluid.UI.Windows.Controls.Drawing.Charting.Base.Interfaces;
using Object = Fluid.Core.Base.Object;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Base
{
    /// <summary>
    /// Data set.
    /// </summary>
    public sealed class DataSet : Object, IDataSet
    {
        /// <summary>
        ///     Creates new instance of <see cref="DataSet"/>.
        /// </summary>
        public DataSet()
        {
        }

        /// <summary>
        ///     Creates new instance of <see cref="DataSet"/>.
        /// </summary>
        /// <param name="data">Data.</param>
        public DataSet(Point[] data)
        {
            Data = data ?? throw new ArgumentNullException(nameof(data), "Description was null.");
        }

        /// <summary>
        ///     Creates new instance of <see cref="DataSet"/>.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <param name="description">Descriptions.</param>
        public DataSet(Point[] data, string[] description)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Description was null.");
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description), "Description was null.");
            }

            if (data.Length != description.Length)
            {
                throw new Exception("Array lengths do not match.");
            }

            Data = data;
            Description = description;
        }

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override string Name { get; set; } = "Data set";

        /// <inheritdoc />
        public Color Color { get; set; } = Color.Black;

        /// <inheritdoc />
        public Point[] Data { get; private set; }

        /// <inheritdoc />
        public string[] Description { get; private set; }

        /// <inheritdoc />
        public DataSetType Type { get; set; } = DataSetType.Line;

        /// <inheritdoc />
        public float Opacity { get; set; } = 1.0f;

        /// <inheritdoc />
        public void UpdateDataSet(Point[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Description was null.");
            }

            if (data.Length != Data.Length)
                Data = new Point[data.Length];

            for (var i = 0; i < Data.Length; i++)
                Data[i] = data[i];
        }

        /// <inheritdoc />
        public void UpdateDataSet(Point[] data, string[] description)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Description was null.");
            }

            if (description == null)
            {
                throw new ArgumentNullException(nameof(description), "Description was null.");
            }

            if (data.Length != Data.Length)
                Data = new Point[data.Length];

            for (var i = 0; i < Data.Length; i++)
                Data[i] = data[i];

            if (data.Length != description.Length)
            {
                throw new Exception("Array lengths do not match.");
            }

            if (description.Length != Description.Length)
                Description = new string[description.Length];

            for (var i = 0; i < Description.Length; i++)
                Description[i] = description[i];
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }
    }
}