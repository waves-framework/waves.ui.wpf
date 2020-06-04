using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;
using Waves.Presentation.Interfaces;
using Waves.UI.Base.Interfaces;
using Waves.UI.Windows.Commands;
using Waves.UI.Windows.Controls.Modality.Base.Interfaces;
using Waves.UI.Windows.Controls.Modality.Presentation.Interfaces;
using Waves.UI.Windows.Controls.Modality.ViewModel.Interfaces;

namespace Waves.UI.Windows.Controls.Modality.Presentation
{
    /// <summary>
    /// Base abstract modality window presentation.
    /// </summary>
    public abstract class ModalWindowPresentation : Waves.Presentation.Base.Presentation, IModalWindowPresentation
    {
        private readonly object _locker = new object();

        /// <summary>
        /// Creates new instance of <see cref="ModalWindowPresentation"/>.
        /// </summary>
        protected ModalWindowPresentation()
        {
            InitializeCollectionSynchronization();
            InitializeCommands();
        }

        /// <inheritdoc />
        public event EventHandler<IModalWindowPresentation> WindowRequestClosing;

        /// <inheritdoc />
        public abstract IVectorImage Icon { get; }

        /// <inheritdoc />
        public abstract string Title { get; }

        /// <inheritdoc />
        public virtual double MaxHeight { get; set; } = 240;

        /// <inheritdoc />
        public virtual double MaxWidth { get; set; } = 320;

        /// <inheritdoc />
        public abstract override IPresentationViewModel DataContext { get; }

        /// <inheritdoc />
        public abstract override IPresentationView View { get; }

        /// <inheritdoc />
        public ICollection<IModalWindowAction> Actions { get; private set; } = new ObservableCollection<IModalWindowAction>();

        /// <summary>
        /// Command to "Close Window".
        /// </summary>
        public ICommand CloseWindowCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            base.Initialize();

            if (!(DataContext is IModalWindowPresentationViewModel context)) return;

            context.AttachActions(Actions);
        }

        /// <summary>
        /// Actions when window requesting closing.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnWindowRequestClosing(IModalWindowPresentation e)
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
            var presentation = obj as IModalWindowPresentation;
            if (presentation == null) return;

            OnWindowRequestClosing(presentation);
        }
    }
}