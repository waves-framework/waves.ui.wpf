using Waves.Core.Base;
using Waves.Core.Base.Enums;
using Waves.Core.Services.Interfaces;
using Waves.Presentation.Base;
using Waves.UI.Windows.Showcase.Services.Interfaces;

namespace Waves.UI.Windows.Showcase.ViewModel.Tabs
{
    /// <summary>
    ///     Core tab view model.
    /// </summary>
    public class CoreTabViewModel : PresentationViewModel
    {
        private ITextGeneratorService _textGeneratorService;

        /// <summary>
        ///     Gets logging service.
        /// </summary>
        public ILoggingService LoggingService { get; private set; }

        /// <inheritdoc />
        public override void Initialize()
        {
            LoggingService = App.Core.GetService<ILoggingService>();

            _textGeneratorService = App.Core.GetService<ITextGeneratorService>();

            //LoggingService.WriteMessageToLog(new Message(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText(), _textGeneratorService.GenerateWord(), MessageType.Information));
            //LoggingService.WriteMessageToLog(new Message(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText(), _textGeneratorService.GenerateWord(), MessageType.Debug));
            //LoggingService.WriteMessageToLog(new Message(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText(), _textGeneratorService.GenerateWord(), MessageType.Warning));
            //LoggingService.WriteMessageToLog(new Message(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText(), _textGeneratorService.GenerateWord(), MessageType.Error));
            //LoggingService.WriteMessageToLog(new Message(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText(), _textGeneratorService.GenerateWord(), MessageType.Fatal));
            //LoggingService.WriteMessageToLog(new Message(_textGeneratorService.GenerateWord(), _textGeneratorService.GenerateText(), _textGeneratorService.GenerateWord(), MessageType.Success));
        }


    }
}