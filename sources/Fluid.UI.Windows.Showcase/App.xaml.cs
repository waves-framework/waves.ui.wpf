using System;
using System.Windows;
using Fluid.UI.Windows.Showcase.View.Window;
using Fluid.UI.Windows.Showcase.ViewModel;
using Bootstrapper = Fluid.UI.Windows.Core.Core;

namespace Fluid.UI.Windows.Showcase
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <inheritdoc />
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Bootstrapper.Start(this);

                var viewModel = new MainViewModel();
                var view = new MainWindowView {DataContext = viewModel};
                view.Show();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}