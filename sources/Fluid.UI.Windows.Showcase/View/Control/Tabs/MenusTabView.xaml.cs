﻿using System;
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
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Interfaces;

namespace Fluid.UI.Windows.Showcase.View.Control.Tabs
{
    /// <summary>
    /// Логика взаимодействия для MenusTabView.xaml
    /// </summary>
    public partial class MenusTabView : IPresentationView
    {
        /// <summary>
        /// Creates new instance of menus tab view.
        /// </summary>
        public MenusTabView()
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