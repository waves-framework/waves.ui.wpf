using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Commands;
using Fluid.UI.Windows.Presentation.ModalityWindows.Interfaces;

namespace Fluid.UI.Windows.Presentation.ModalityWindows.Base
{
    /// <summary>
    /// Base abstract modality window presentation.
    /// </summary>
    public abstract class ModalityWindowPresentation : Fluid.Presentation.Base.Presentation, IModalityWindowPresentation
    {
        private readonly object _locker = new object();

        /// <summary>
        /// Creates new instance of <see cref="ModalityWindowPresentation"/>.
        /// </summary>
        protected ModalityWindowPresentation()
        {
            InitializeCollectionSynchronization();
            InitializeCommands();
        }

        /// <inheritdoc />
        public event EventHandler<IModalityWindowPresentation> WindowRequestClosing;

        /// <inheritdoc />
        public abstract IVectorIcon Icon { get; }

        /// <inheritdoc />
        public abstract string Title { get; }

        /// <inheritdoc />
        public virtual double Height { get; set; } = 240;

        /// <inheritdoc />
        public virtual double Width { get; set; } = 320;

        /// <inheritdoc />
        public abstract override IPresentationViewModel DataContext { get; }

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public ICollection<IModalityWindowAction> Actions { get; private set; } = new ObservableCollection<IModalityWindowAction>();

        /// <summary>
        /// Command to "Close Window".
        /// </summary>
        public ICommand CloseWindowCommand { get; private set; }

        /// <summary>
        /// Actions when window requesting closing.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWindowRequestClosing(IModalityWindowPresentation e)
        {
            WindowRequestClosing?.Invoke(this, e);
        }

        /// <summary>
        /// Initializes collection synchronization.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(Actions, _locker);
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            CloseWindowCommand = new Command(OnCloseWindow);
        }

        /// <summary>
        /// Actions when close window.
        /// </summary>
        /// <param name="obj"></param>
        private void OnCloseWindow(object obj)
        {
            var presentation = obj as IModalityWindowPresentation;
            if (presentation == null) return;

            OnWindowRequestClosing(presentation);
        }
    }
}