using System;
using System.Collections;
using System.IO;
using System.Resources;
using System.Windows;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Application = System.Windows.Application;
using Bootstrapper = Fluid.Core.Core;

namespace Fluid.UI.Windows.Core
{
    /// <summary>
    /// Ядро UI.
    /// </summary>
    public static class Core
    {
        private static ResourceDictionary _primaryColorDictionary;
        private static ResourceDictionary _accentColorDictionary;
        private static ResourceDictionary _miscellaneousColorDictionary;

        /// <summary>
        /// Инициализировано ли ядро.
        /// </summary>
        public static bool IsInitialized { get; private set; }

        /// <summary>
        /// Получает или задает экземпляр запущенного приложения.
        /// </summary>
        public static Application Application { get; private set; }

        /// <summary>
        /// Запуск ядра.
        /// </summary>
        public static void Start(Application application)
        {
            try
            {
                Application = application;

                Bootstrapper.Start();

                if (!InitializeDictionaries())
                    throw new Exception("Ошибка при инициализации базовых словарей ресурсов UI.");

                if (!InitializeServices())
                    throw new Exception("Ошибка при инициализации сервисов UI.");

                IsInitialized = true;
            }
            catch (Exception ex)
            {
                Bootstrapper.WriteLogMessage(ex, "UI.Core");
            }
        }

        /// <summary>
        /// Инициализация сервисов.
        /// </summary>
        private static bool InitializeServices()
        {
            return true;
        }

        /// <summary>
        /// Инициализация словарей.
        /// </summary>
        private static bool InitializeDictionaries()
        {
            try
            {
                var dictionaries = Application.Resources.MergedDictionaries;
                if (dictionaries.Count == 1)
                {
                    var core = dictionaries[0];
                    if (core.Source.AbsolutePath.Equals("/Fluid.UI.Windows.Core;component/Core.xaml"))
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
                Bootstrapper.WriteLogMessage(new Message("Ошибка", "При инициализации конфигурации возникла ошибка:\r\n" + e.Message, "UI.Core", MessageType.Error));
                return false;
            }
        }
    }
}