﻿using System;
using Waves.Core.Base.Interfaces;
using Waves.Presentation.Interfaces;

namespace Waves.UI.WPF.Showcase.View.Control.Tabs
{
    /// <summary>
    ///     Логика взаимодействия для CheckBoxexTabView.xaml
    /// </summary>
    public partial class CheckBoxesTabView : IPresentationView
    {
        /// <summary>
        ///     Creates new instance of check box tab view.
        /// </summary>
        public CheckBoxesTabView()
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