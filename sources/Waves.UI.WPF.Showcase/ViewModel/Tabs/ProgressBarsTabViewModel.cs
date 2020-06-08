using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Waves.Presentation.Base;
using Waves.UI.WPF.Commands;

namespace Waves.UI.WPF.Showcase.ViewModel.Tabs
{
    /// <summary>
    /// Progress bars tab view model.
    /// </summary>
    public class ProgressBarsTabViewModel : PresentationViewModel
    {
        /// <summary>
        /// Gets whether first task is running.
        /// </summary>
        public bool IsFirstRunning { get; private set; }

        /// <summary>
        /// Gets whether second task is running.
        /// </summary>
        public bool IsSecondRunning { get; private set; }

        /// <summary>
        /// Gets first progress.
        /// </summary>
        public int FirstProgress { get; set; } = 0;

        /// <summary>
        /// Gets second progress.
        /// </summary>
        public int SecondProgress { get; set; } = 0;

        /// <summary>
        /// Gets first button text.
        /// </summary>
        public string FirstButtonProgressText { get; private set; } = "Run";

        /// <summary>
        /// Gets second button text.
        /// </summary>
        public string SecondButtonProgressText { get; private set; } = "Run";

        /// <summary>
        /// Gets first button run command.
        /// </summary>
        public ICommand FirstButtonRunCommand { get; private set; }

        /// <summary>
        /// Gets second button run command.
        /// </summary>
        public ICommand SecondButtonRunCommand { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            InitializeCommands();
        }

        /// <summary>
        /// Initializes commands.
        /// </summary>
        private void InitializeCommands()
        {
            FirstButtonRunCommand = new Command(OnFirstRun);
            SecondButtonRunCommand = new Command(OnSecondRun);
        }

        /// <summary>
        /// First command action.
        /// </summary>
        /// <param name="obj"></param>
        private async void OnFirstRun(object obj)
        {
            if (!IsFirstRunning)
            {
                IsFirstRunning = true;
                await FirstProgressTask().ConfigureAwait(false);
            }
            else
            {
                FirstButtonProgressText = "Run";
                IsFirstRunning = false;
            }
        }

        /// <summary>
        /// Second command action.
        /// </summary>
        /// <param name="obj"></param>
        private async void OnSecondRun(object obj)
        {
            if (!IsSecondRunning)
            {
                IsSecondRunning = true;
                await SecondProgressTask().ConfigureAwait(false);
            }
            else
            {
                SecondButtonProgressText = "Run";
                IsSecondRunning = false;
            }
        }

        /// <summary>
        /// Task for first progress.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task FirstProgressTask()
        {
            FirstProgress = 0;

            for (var i = 0; i < 100; i++)
            {
                await Task.Delay(100).ConfigureAwait(false);

                if (!IsFirstRunning)
                    break;

                FirstButtonProgressText = "Running... (" + i + "%)";
                FirstProgress = i;
            }

            FirstProgress = 0;
            FirstButtonProgressText = "Run";

            IsFirstRunning = false;
        }

        /// <summary>
        /// Task for second progress.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task SecondProgressTask()
        {
            SecondProgress = 0;

            for (var i = 0; i < 100; i++)
            {
                await Task.Delay(100).ConfigureAwait(false);

                if (!IsSecondRunning)
                    break;

                SecondButtonProgressText = "Running... (" + i + "%)";
                SecondProgress = i;
            }

            SecondProgress = 0;
            SecondButtonProgressText = "Run";

            IsSecondRunning = false;
        }
    }
}