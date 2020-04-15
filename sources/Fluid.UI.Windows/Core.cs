using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Services;
using Fluid.UI.Windows.Services.Interfaces;
using Application = System.Windows.Application;

namespace Fluid.UI.Windows
{
    /// <summary>
    /// UI Core.
    /// </summary>
    public class Core : Fluid.Core.Core
    {
        private ResourceDictionary _primaryColorDictionary;
        private ResourceDictionary _accentColorDictionary;
        private ResourceDictionary _miscellaneousColorDictionary;

        /// <summary>
        /// Gets whether UI Core is initialized.
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// Gets instance of attached application.
        /// </summary>
        public Application Application { get; private set; }

        /// <inheritdoc />
        public override void Start()
        {
            try
            {
                base.Start();

                Initialize();
                
                IsInitialized = true;
            }
            catch (Exception ex)
            {
                WriteLogException(ex, "UI.Core");
            }
        }

        /// <summary>
        /// Starts UI core.
        /// </summary>
        /// <param name="application">Application instance.</param>
        public void Start(Application application)
        {
            Application = application;

            Start();
        }

        /// <summary>
        /// Initializes UI Core.
        /// </summary>
        private void Initialize()
        {
            InitializeServices();
        }

        /// <summary>
        /// Initializes UI core base services.
        /// </summary>
        private void InitializeServices()
        {
            RegisterService(ServiceManager.GetService<IThemeService>().First());

            GetService<IThemeService>().AttachApplication(Application);
        }
    }
}