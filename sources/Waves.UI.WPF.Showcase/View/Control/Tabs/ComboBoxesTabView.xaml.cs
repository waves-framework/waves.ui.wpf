using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.UI.WPF.Showcase.View.Control.Tabs
{
    /// <summary>
    /// Логика взаимодействия для ComboBoxesTabView.xaml
    /// </summary>
    public partial class ComboBoxesTabView : IPresentationView
    {
        /// <summary>
        /// Creates new instance of ComboBoxes tab view.
        /// </summary>
        public ComboBoxesTabView()
        {
            InitializeComponent();
        }

        /// <inheritdoc />
        public event EventHandler<IMessage> MessageReceived;

        /// <summary>
        /// Notifies when message received.
        /// </summary>
        /// <param name="e">Message.</param>
        protected virtual void OnMessageReceived(IMessage e)
        {
            MessageReceived?.Invoke(this, e);
        }
    }
}
