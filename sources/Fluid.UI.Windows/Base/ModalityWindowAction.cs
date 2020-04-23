using System;
using System.Windows.Input;
using Fluid.Core.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Commands;
using Microsoft.Xaml.Behaviors.Core;

namespace Fluid.UI.Windows.Base
{
    /// <summary>
    /// Base class of modality window action.
    /// </summary>
    public class ModalityWindowAction : ObservableObject, IModalityWindowAction
    {
        /// <summary>
        /// Creates new instance of <see cref="ModalityWindowAction"/>. 
        /// </summary>
        /// <param name="caption">Caption.</param>
        /// <param name="icon">Icon.</param>
        /// <param name="action">Action.</param>
        public ModalityWindowAction(string caption, IVectorIcon icon, Action action)
        {
            Caption = caption;
            ToolTip = caption;
            Icon = icon;
            Action = action;

            InitializeCommand();
        }

        /// <summary>
        /// Creates new instance of <see cref="ModalityWindowAction"/>. 
        /// </summary>
        /// <param name="caption">Caption.</param>
        /// <param name="icon">Icon.</param>
        /// <param name="action">Action.</param>
        /// <param name="isAccent">Is accent.</param>
        public ModalityWindowAction(string caption, IVectorIcon icon, Action action, bool isAccent)
        {
            Caption = caption;
            ToolTip = caption;
            Icon = icon;
            Action = action;
            IsAccent = isAccent;

            InitializeCommand();
        }

        /// <summary>
        /// Creates new instance of <see cref="ModalityWindowAction"/>. 
        /// </summary>
        /// <param name="caption">Caption.</param>
        /// <param name="toolTip">ToolTip.</param>
        /// <param name="icon">Icon.</param>
        /// <param name="action">Action.</param>
        public ModalityWindowAction(string caption, string toolTip, IVectorIcon icon, Action action)
        {
            Caption = caption;
            ToolTip = toolTip;
            Icon = icon;
            Action = action;

            InitializeCommand();
        }

        /// <summary>
        /// Creates new instance of <see cref="ModalityWindowAction"/>. 
        /// </summary>
        /// <param name="caption">Caption.</param>
        /// <param name="toolTip">ToolTip.</param>
        /// <param name="icon">Icon.</param>
        /// <param name="action">Action.</param>
        /// <param name="isAccent">Is accent.</param>
        public ModalityWindowAction(string caption, string toolTip, IVectorIcon icon, Action action, bool isAccent)
        {
            Caption = caption;
            ToolTip = toolTip;
            Icon = icon;
            Action = action;
            IsAccent = isAccent;

            InitializeCommand();
        }

        /// <inheritdoc />
        public bool IsAccent { get; private set; }

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public IVectorIcon Icon { get; private set; }

        /// <inheritdoc />
        public string Caption { get; private set; }

        /// <inheritdoc />
        public string ToolTip { get; private set; }

        /// <inheritdoc />
        public Action Action { get; private set; }

        /// <summary>
        /// Gets command for action.
        /// </summary>
        public ICommand Command { get; private set; }

        /// <summary>
        /// Returns new "OK" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalityWindowAction OkModalityWindowAction(Action action)
        {
            return new ModalityWindowAction("Ok", new ResourcesVectorIcon("Icon-Success", 14, 14), action);
        }

        /// <summary>
        /// Returns new "Save" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalityWindowAction SaveModalityWindowAction(Action action)
        {
            return new ModalityWindowAction("Save", new ResourcesVectorIcon("Icon-Save", 14, 14), action, true);
        }

        /// <summary>
        /// Returns new "Save" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalityWindowAction CloseModalityWindowAction(Action action)
        {
            return new ModalityWindowAction("Close", new ResourcesVectorIcon("Icon-Delete", 14, 14), action);
        }

        /// <summary>
        /// Initializes base command.
        /// </summary>
        private void InitializeCommand()
        {
            Command = new Command(OnCommandExecute);
        }

        /// <summary>
        /// Actions when command executing.
        /// </summary>
        /// <param name="obj">Parameter.</param>
        private void OnCommandExecute(object obj)
        {
            Action?.Invoke();
        }
    }
}