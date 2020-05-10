using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.EventArgs;
using Fluid.Core.Services.Interfaces;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.View;
using Fluid.UI.Windows.Controls.Drawing.Charting.View.Interface;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;
using MouseButton = System.Windows.Input.MouseButton;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Presentation
{
    /// <summary>
    ///     Chart presentation.
    /// </summary>
    public abstract class ChartPresentation : Fluid.Presentation.Base.Presentation, IChartPresentation
    {
        /// <inheritdoc />
        protected ChartPresentation(
            IDrawingService drawingService,
            IThemeService themeService,
            IInputService inputService)
        {
            DrawingService = drawingService;
            ThemeService = themeService;
            InputService = inputService;

            SubscribeEvents();
        }

        /// <inheritdoc />
        public override IPresentationViewModel DataContext => DataContextBackingField;

        /// <inheritdoc />
        public override IPresentationView View => ViewBackingField;

        /// <summary>
        ///     Gets or sets Data context's backing field.
        /// </summary>
        protected IChartViewModel DataContextBackingField;

        /// <summary>
        ///     Gets or sets View's backing field.
        /// </summary>
        protected IChartView ViewBackingField;

        /// <summary>
        ///     Gets or sets theme service.
        /// </summary>
        protected IThemeService ThemeService { get; set; }

        /// <summary>
        ///     Gets or sets drawing service.
        /// </summary>
        protected IDrawingService DrawingService { get; set; }

        /// <summary>
        ///     Gets or sets input service.
        /// </summary>
        protected IInputService InputService { get; set; }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            if (ThemeService != null)
                ThemeService.PropertyChanged -= OnThemeServicePropertyChanged;

            if (DrawingService != null)
                DrawingService.EngineChanged -= OnDrawingServiceEngineChanged;

            var view = View as ChartView;
            if (view == null) return;

            view.DrawingElementView.MouseMove -= OnMouseMove;
            view.DrawingElementView.MouseEnter -= OnMouseEnter;
            view.DrawingElementView.MouseLeave -= OnMouseLeave;
            view.DrawingElementView.MouseDown -= OnMouseDown;
            view.DrawingElementView.MouseUp -= OnMouseUp;
            view.DrawingElementView.MouseWheel -= OnMouseWheel;
            view.DrawingElementView.TouchEnter -= OnTouchEnter;
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (DataContext != null && View != null)
            {
                base.Initialize();
            }
        }

        /// <summary>
        ///     Notifies when drawing service changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnDrawingServiceEngineChanged(object sender, EventArgs e)
        {
            Update();
        }

        /// <summary>
        ///     Updates all.
        /// </summary>
        protected abstract void Update();

        /// <summary>
        ///     Initialize colors.
        /// </summary>
        protected virtual void InitializeColors()
        {
            if (!(DataContext is IChartViewModel context)) return;

            context.Background = ThemeService.SelectedTheme.GetPrimaryColor(100);
            context.BorderColor = ThemeService.SelectedTheme.GetPrimaryColor(900);
            context.XAxisZeroLineColor = ThemeService.SelectedTheme.GetPrimaryColor(900);
            context.XAxisPrimaryTicksColor = ThemeService.SelectedTheme.GetPrimaryColor(700);
            context.XAxisAdditionalTicksColor = ThemeService.SelectedTheme.GetPrimaryColor(500);
            context.YAxisZeroLineColor = ThemeService.SelectedTheme.GetPrimaryColor(900);
            context.YAxisPrimaryTicksColor = ThemeService.SelectedTheme.GetPrimaryColor(700);
            context.YAxisAdditionalTicksColor = ThemeService.SelectedTheme.GetPrimaryColor(500);
            context.Foreground = ThemeService.SelectedTheme.GetPrimaryForegroundColor(100);

            context.TextStyle.FontFamily = "#Lato Regular";
            context.TextStyle.FontSize = 12;
        }

        /// <summary>
        ///     Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
            if (ThemeService != null)
                ThemeService.PropertyChanged += OnThemeServicePropertyChanged;

            if (DrawingService != null)
                DrawingService.EngineChanged += OnDrawingServiceEngineChanged;
        }

        /// <summary>
        ///     Actions when theme service property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnThemeServicePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedTheme")
            {
                InitializeColors();

                DataContextBackingField.Update();
            }
        }

        /// <summary>
        /// Actions when mouse move.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                Fluid.Core.Base.Enums.MouseButton.None, 
                PointerEventType.Move, 
                0,
                new Fluid.Core.Base.Point(), 
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse enters.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseEnter(object sender, MouseEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);
            var args = new PointerEventArgs(
                Fluid.Core.Base.Enums.MouseButton.None, 
                PointerEventType.Enter, 
                0, 
                new Fluid.Core.Base.Point(),
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse leaves.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);
            var args = new PointerEventArgs(
                Fluid.Core.Base.Enums.MouseButton.None, 
                PointerEventType.Leave, 
                0, 
                new Fluid.Core.Base.Point(),
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse button is down.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var button = Fluid.Core.Base.Enums.MouseButton.None;

            switch (e.ChangedButton)
            {
                case System.Windows.Input.MouseButton.Left:
                    button = Fluid.Core.Base.Enums.MouseButton.Left;
                    break;
                case System.Windows.Input.MouseButton.Middle:
                    button = Fluid.Core.Base.Enums.MouseButton.Middle;
                    break;
                case System.Windows.Input.MouseButton.Right:
                    button = Fluid.Core.Base.Enums.MouseButton.Right;
                    break;
            }

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                button, 
                PointerEventType.Press, 
                0, 
                new Fluid.Core.Base.Point(),
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse ups.
        /// TODO: combine methods.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var button = Fluid.Core.Base.Enums.MouseButton.None;

            switch (e.ChangedButton)
            {
                case System.Windows.Input.MouseButton.Left:
                    button = Fluid.Core.Base.Enums.MouseButton.Left;
                    break;
                case System.Windows.Input.MouseButton.Middle:
                    button = Fluid.Core.Base.Enums.MouseButton.Middle;
                    break;
                case System.Windows.Input.MouseButton.Right:
                    button = Fluid.Core.Base.Enums.MouseButton.Right;
                    break;
            }

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                button,
                PointerEventType.Release,
                0,
                new Fluid.Core.Base.Point(),
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when mouse scrolling.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetPosition(element);

            var args = new PointerEventArgs(
                Fluid.Core.Base.Enums.MouseButton.None, 
                PointerEventType.VerticalScroll, 
                0,
                new Fluid.Core.Base.Point(e.Delta, 0), 
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        /// <summary>
        /// Actions when touch enters.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected void OnTouchEnter(object sender, TouchEventArgs e)
        {
            if (InputService == null) return;

            var element = sender as FrameworkElement;
            if (element == null) return;

            var position = e.GetTouchPoint(element).Position;

            var args = new PointerEventArgs(
                Fluid.Core.Base.Enums.MouseButton.None, 
                PointerEventType.Enter, 
                0, 
                new Fluid.Core.Base.Point(),
                new Fluid.Core.Base.Point((int)position.X, (int)position.Y));

            InputService.SetPointer(args);
        }

        // TODO: touch.
    }
}