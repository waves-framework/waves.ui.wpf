using System;
using System.Windows;
using Fluid.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.Presentation.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Charting.View;
using Fluid.UI.Windows.Controls.Drawing.Charting.View.Interface;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.Charting.ViewModel.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.Presentation;
using Fluid.UI.Windows.Controls.Drawing.View.Interfaces;
using Fluid.UI.Windows.Controls.Drawing.ViewModel;
using Fluid.UI.Windows.Controls.Drawing.ViewModel.Interfaces;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Controls.Drawing.Charting.Presentation
{
    /// <summary>
    /// Chart presentation.
    /// </summary>
    public abstract class ChartPresentation : Fluid.Presentation.Base.Presentation, IChartPresentation
    {
        /// <inheritdoc />
        public ChartPresentation(IDrawingService drawingService, IThemeService themeService)
        {
            DrawingService = drawingService;
            ThemeService = themeService;

            SubscribeEvents();
        }

        /// <summary>
        /// Gets or sets theme service.
        /// </summary>
        public IThemeService ThemeService { get; set; }

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
        ///     Gets or sets drawing service.
        /// </summary>
        protected IDrawingService DrawingService { get; set; }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            if (ThemeService != null)
                ThemeService.PropertyChanged -= OnThemeServicePropertyChanged;

            if (DrawingService != null)
                DrawingService.EngineChanged -= OnDrawingServiceEngineChanged;
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
        /// Notifies when drawing service changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        protected virtual void OnDrawingServiceEngineChanged(object sender, EventArgs e)
        {
            Update();
        }

        /// <summary>
        /// Updates all.
        /// </summary>
        protected abstract void Update();

        /// <summary>
        /// Initialize colors.
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
        /// Subscribes events.
        /// </summary>
        private void SubscribeEvents()
        {
            if (ThemeService != null)
                ThemeService.PropertyChanged += OnThemeServicePropertyChanged;

            if (DrawingService != null)
                DrawingService.EngineChanged += OnDrawingServiceEngineChanged;
        }

        /// <summary>
        /// Actions when theme service property changed.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">Arguments.</param>
        private void OnThemeServicePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedTheme")
            {
                InitializeColors();

                DataContextBackingField.Update();
            }
        }
    }
}