namespace Expland.Logging;

public static partial class LoggerBuilderExtensions {
    public static LoggerBuilder AddListLogger(this LoggerBuilder loggerBuilder) {
        loggerBuilder.AddLogger(new ListLogger());
        
        return loggerBuilder;
    }
}