using System;
using System.Collections.Generic;
using System.Windows;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.Interfaces;
using Fluid.Core.Services;
using Fluid.UI.Windows.Services.Interfaces;

namespace Fluid.UI.Windows.Services
{
    public class ThemeService : Service, IThemeService
    {
        private static ResourceDictionary _primaryColorDictionary;
        private static ResourceDictionary _accentColorDictionary;
        private static ResourceDictionary _miscellaneousColorDictionary;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("61482A15-667C-4993-AEAE-4F19A62C17B8");

        /// <inheritdoc />
        public override string Name { get; set; } = "Windows UI Theme Service";

        /// <inheritdoc />
        public ITheme SelectedTheme { get; private set; }

        /// <inheritdoc />
        public ICollection<ITheme> Themes { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;



            OnMessageReceived(this,
                new Message("Информация", "Сервис инициализирован.", Name, MessageType.Information));

            IsInitialized = true;
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
