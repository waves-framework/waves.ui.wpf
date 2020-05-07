using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Windows.Data;
using Fluid.Core.Base;
using Fluid.Core.Base.Enums;
using Fluid.Core.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Base.Interfaces;
using Fluid.UI.Windows.Drawing.Presentation;
using Fluid.UI.Windows.Drawing.Presentation.Interfaces;

namespace Fluid.UI.Windows.Drawing.Services
{
    /// <summary>
    /// Drawing service.
    /// </summary>
    [Export(typeof(IService))]
    public class DrawingService : Service, Interfaces.IDrawingService
    {
        private readonly object _pathsLocker = new object();
        private readonly object _enginesLocker = new object();
        private IDrawingEngine _currentEngine;

        /// <summary>
        /// Gets or sets loaded drawing engines.
        /// </summary>
        [ImportMany]
        private IEnumerable<IDrawingEngine> DrawingEngines { get; set; }

        /// <inheritdoc />
        public event EventHandler EngineChanged;

        /// <inheritdoc />
        public override Guid Id { get; } = Guid.Parse("47D1A008-2278-43F0-9E95-878EE5001D27");

        /// <inheritdoc />
        public override string Name { get; set; } = "Drawing service";

        /// <inheritdoc />
        public IDrawingEngine CurrentEngine
        {
            get => _currentEngine;
            set
            {
                _currentEngine = value;

                OnPropertyChanged();

                OnEngineChanged();
            }
        }

        /// <inheritdoc />
        public List<string> EnginePaths { get; set; } = new List<string>();

        /// <inheritdoc />
        public ICollection<IDrawingEngine> Engines { get; private set; } = new ObservableCollection<IDrawingEngine>();

        /// <inheritdoc />
        public IDrawingElementPresentation CreatePresentation()
        {
            return new DrawingElementPresentation(this);
        }

        /// <inheritdoc />
        public void AddPath(string path)
        {
            try
            {
                if (!EnginePaths.Contains(path)) EnginePaths?.Add(path);

                OnMessageReceived(this, new Message("Adding drawing engines path", "Drawing engines path added successfully.", Name,
                    MessageType.Success));
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }

        /// <inheritdoc />
        public void RemovePath(string path)
        {
            try
            {
                if (EnginePaths.Contains(path)) EnginePaths?.Remove(path);

                OnMessageReceived(this, new Message("Removing drawing engines path", "Drawing engines path removed successfully.", Name,
                    MessageType.Success));
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }

        /// <inheritdoc />
        public void UpdateEnginesCollection()
        {
            try
            {
                LoadEngines();
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }

        /// <inheritdoc />
        public override void Initialize()
        {
            if (IsInitialized) return;

            try
            {
                InitializeCollectionSynchronization();
                LoadEngines();

                IsInitialized = true;

                OnMessageReceived(this,
                    new Message(
                        "Initialization",
                        "Service was initialized.",
                        Name,
                        MessageType.Information));
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }

        /// <inheritdoc />
        public override void LoadConfiguration(IConfiguration configuration)
        {
            try
            {
                EnginePaths.AddRange(LoadConfigurationValue(configuration, "DrawingService-EnginePaths", new List<string>()));

                var name = LoadConfigurationValue(configuration, "DrawingService-DefaultEngineName", string.Empty);

                if (!string.IsNullOrEmpty(name))
                {
                    foreach (var engine in Engines)
                    {
                        if (!string.Equals(engine.Name, name, StringComparison.OrdinalIgnoreCase)) continue;

                        CurrentEngine = engine;
                        break;
                    }
                }
                else
                {
                    if (Engines.Count > 0)
                        CurrentEngine = Engines.First();
                }

                OnMessageReceived(this, new Message("Configuration loading", "Configuration loads successfully.", Name,
                    MessageType.Success));
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }

        /// <inheritdoc />
        public override void SaveConfiguration(IConfiguration configuration)
        {
            try
            {
                if (EnginePaths.Count > 1)
                {
                    configuration.SetPropertyValue("ApplicationService-Paths", EnginePaths.GetRange(1, EnginePaths.Count - 1));

                    OnMessageReceived(this, new Message("Configuration saving", "Configuration saves successfully.", Name,
                        MessageType.Success));
                }

                if (CurrentEngine != null)
                {
                    configuration.SetPropertyValue("DrawingService-DefaultEngineName", CurrentEngine.Name);
                }
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
        }

        /// <summary>
        /// Notifies when engine changed.
        /// </summary>
        protected virtual void OnEngineChanged()
        {
            EngineChanged?.Invoke(this, EventArgs.Empty);

            OnMessageReceived(this, new Message("Drawing engine", "Drawing engine changed to " + CurrentEngine.Name + ".", Name,
                MessageType.Information));
        }

        /// <summary>
        /// Initializes collection synchronization.
        /// </summary>
        private void InitializeCollectionSynchronization()
        {
            BindingOperations.EnableCollectionSynchronization(EnginePaths, _pathsLocker);
            BindingOperations.EnableCollectionSynchronization(Engines, _enginesLocker);
        }

        /// <summary>
        /// Loads engines.
        /// </summary>
        private void LoadEngines()
        {
            try
            {
                var assemblies = new List<Assembly>();

                // TODO: Path to current directory. Temporary solution.
                EnginePaths.Add(Environment.CurrentDirectory);

                foreach (var path in EnginePaths)
                {
                    if (!Directory.Exists(path))
                    {
                        OnMessageReceived(this,
                            new Message(
                                "Loading path error",
                                "Path to engine ( " + path + ") doesn't exists or was deleted.",
                                Name,
                                MessageType.Error));

                        continue;
                    }

                    foreach (var file in Directory.GetFiles(path, "*.dll", SearchOption.AllDirectories))
                    {
                        try
                        {
                            var hasItem = false;
                            var fileInfo = new FileInfo(file);
                            foreach (var assembly in assemblies)
                            {
                                var name = assembly.GetName().Name;

                                if (name == fileInfo.Name.Replace(fileInfo.Extension, "")) hasItem = true;
                            }

                            if (!hasItem) assemblies.Add(AssemblyLoadContext.Default.LoadFromAssemblyPath(file));
                        }
                        catch (Exception e)
                        {
                            OnMessageReceived(this, new Message("Loading assemblies", "Error loading assembly (" + file + ").", Name, e,false));
                        }
                    }
                }

                // TODO: Path to current directory. Temporary solution.
                EnginePaths.Remove(Environment.CurrentDirectory);

                var configuration = new ContainerConfiguration()
                    .WithAssemblies(assemblies);

                using var container = configuration.CreateContainer();
                DrawingEngines = container.GetExports<IDrawingEngine>();

                Engines.Clear();
                foreach (var engine in DrawingEngines)
                {
                    Engines.Add(engine);
                }

                if (DrawingEngines != null)
                {
                    if (!Engines.Any())
                    {
                        OnMessageReceived(this, new Message("Loading engines", "Engines not found.", Name,
                            MessageType.Warning));
                    }
                    else
                    {
                        OnMessageReceived(this, new Message("Loading engines", "Engines loads successfully (" + Engines.Count() + " engines).", Name,
                            MessageType.Success));
                    }
                }
                else
                {
                    OnMessageReceived(this, new Message("Loading engines", "Engines were not loaded.", Name, MessageType.Warning));
                }
            }
            catch (Exception e)
            {
                OnMessageReceived(this, new Message(e, false));
            }
        }
    }
}