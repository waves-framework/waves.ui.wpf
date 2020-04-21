using System;
using System.Collections.Generic;
using System.Text;
using Fluid.Core.Base.Interfaces;
using Fluid.Presentation.Base;

namespace Fluid.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Configuration tab view model.
    /// </summary>
    public class ConfigurationTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets core configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            Configuration = App.Core.Configuration;
        }
    }
}
