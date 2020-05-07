using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Fluid.Core.Base;
using Fluid.UI.Windows.Base;
using Fluid.UI.Windows.Base.Interfaces;
using Fluid.UI.Windows.Commands;
using Fluid.UI.Windows.Controls.Modality.Base.Interfaces;

namespace Fluid.UI.Windows.Controls.Modality.Base
{
    /// <summary>
    /// Base class of modality window action.
    /// </summary>
    public class ModalWindowAction : ObservableObject, IModalWindowAction
    {
        /// <summary>
        /// Creates new instance of <see cref="ModalWindowAction"/>. 
        /// </summary>
        /// <param name="caption">Caption.</param>
        /// <param name="action">Action.</param>
        /// <param name="icon">Icon.</param>
        /// <param name="isAccent">Is accent.</param>
        /// <param name="toolTip">Tool tip.</param>
        public ModalWindowAction(string caption, Action action, IVectorIcon icon = null, bool isAccent = false, string toolTip = null)
        {
            Caption = caption;
            ToolTip = !string.IsNullOrEmpty(toolTip) ? toolTip : caption;
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
        public static IModalWindowAction Ok(Action action)
        {
            return new ModalWindowAction("Ok", action, new ResourcesVectorIcon("Icon-Success", 14, 14));
        }

        /// <summary>
        /// Returns new "Save" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalWindowAction Save(Action action)
        {
            return new ModalWindowAction("Save", action, new ResourcesVectorIcon("Icon-Save", 14, 14), true);
        }

        /// <summary>
        /// Returns new "Save" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalWindowAction Close(Action action)
        {
            return new ModalWindowAction("Close", action, new ResourcesVectorIcon("Icon-Delete", 14, 14));
        }

        /// <summary>
        /// Returns new "Yes" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalWindowAction Yes(Action action)
        {
            return new ModalWindowAction("Yes", action, null, true);
        }

        /// <summary>
        /// Returns new "No" action.
        /// </summary>
        /// <param name="action">Action.</param>
        /// <returns>Modality window action.</returns>
        public static IModalWindowAction No(Action action)
        {
            return new ModalWindowAction("No", action);
        }

        /// <summary>
        /// Returns collection of "Save" and "Close" modal actions.
        /// </summary>
        /// <param name="saveAction">"Save" action.</param>
        /// <param name="closeAction">"Close" action.</param>
        /// <returns>Modal action collection.</returns>
        public static ICollection<IModalWindowAction> SaveClose(Action saveAction, Action closeAction)
        {
            return new ObservableCollection<IModalWindowAction>(){Save(saveAction), Close(closeAction)};
        }

        /// <summary>
        /// Returns collection of "Yes" and "No" modal actions.
        /// </summary>
        /// <param name="yesAction">"Yes" action.</param>
        /// <param name="noAction">"No" action.</param>
        /// <returns>Modal action collection.</returns>
        public static ICollection<IModalWindowAction> YesNo(Action yesAction, Action noAction)
        {
            return new ObservableCollection<IModalWindowAction>() {  No(noAction), Yes(yesAction) };
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