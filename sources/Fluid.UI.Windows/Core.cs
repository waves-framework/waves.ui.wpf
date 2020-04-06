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
    /// Ядро UI.
    /// </summary>
    public class Core : Fluid.Core.Core
    {
        private ResourceDictionary _primaryColorDictionary;
        private ResourceDictionary _accentColorDictionary;
        private ResourceDictionary _miscellaneousColorDictionary;

        /// <summary>
        /// Инициализировано ли ядро.
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// Получает или задает экземпляр запущенного приложения.
        /// </summary>
        public Application Application { get; private set; }

        /// <summary>
        /// Запуск ядра.
        /// </summary>
        public void Start(Application application)
        {
            try
            {
                Application = application;

                Start();

                if (!InitializeDictionaries())
                    throw new Exception("Ошибка при инициализации базовых словарей ресурсов UI.");

                if (!InitializeServices())
                    throw new Exception("Ошибка при инициализации сервисов UI.");

                IsInitialized = true;
            }
            catch (Exception ex)
            {
                WriteLogMessage(ex, "UI.Core");
            }
        }

        /// <summary>
        /// Инициализация сервисов.
        /// </summary>
        private bool InitializeServices()
        {
            // application
            var themeService = Manager.GetService<IThemeService>().First();
            if (themeService == null)
            {
                WriteLogMessage(new Message("Service loading", "Theme service is not loaded", "UI Core", MessageType.Warning));
            }
            else
            {
                RegisterService(themeService);
            }

            //egisterService<IThemeService>(new ThemeService(_primaryColorDictionary, _accentColorDictionary, _miscellaneousColorDictionary));

            return true;
        }

        /// <summary>
        /// Инициализация словарей.
        /// </summary>
        private bool InitializeDictionaries()
        {
            try
            {
                var dictionaries = Application.Resources.MergedDictionaries;
                if (dictionaries.Count == 1)
                {
                    var core = dictionaries[0];
                    if (core.Source.AbsolutePath.Equals("/Fluid.UI.Windows;component/Core.xaml"))
                    {
                        dictionaries = core.MergedDictionaries;

                        _primaryColorDictionary = dictionaries[0];
                        _accentColorDictionary = dictionaries[1];
                    }
                    else
                    {
                        throw new Exception("Неверный словарь ресурсов Core.xaml.");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                WriteLogMessage(new Message("Ошибка", "При инициализации конфигурации возникла ошибка:\r\n" + e.Message, "UI.Core", MessageType.Error));
                return false;
            }
        }
    }
}