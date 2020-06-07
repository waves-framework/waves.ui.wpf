using System.Windows.Data;
using Waves.UI.WPF.Commands;

namespace Waves.UI.WPF.Controls.Modality.Presentation
{
    /// <summary>
    ///     Base abstract modality window presentation.
    /// </summary>
    public abstract class ModalWindowPresentation : UI.Modality.Presentation.ModalWindowPresentation
    {
        private readonly object _locker = new object();

        /// <summary>
        ///     Creates new instance of <see cref="ModalWindowPresentation" />.
        /// </summary>
        protected ModalWindowPresentation()
        {
            InitializeCollectionSynchronization();
            InitializeCommands();
        }

        /// <summary>
        ///     Initializes collection synchronization.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(Actions, _locker);
        }

        /// <summary>
        ///     Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            CloseWindowCommand = new Command(OnCloseWindow);
        }
    }
}