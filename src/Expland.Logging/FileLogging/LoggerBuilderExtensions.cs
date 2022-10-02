using System.Text;

namespace Expland.Logging;

public static partial class LoggerBuilderExtensions {
    public static LoggerBuilder AddFileLogger(this LoggerBuilder loggerBuilder, Encoding encoding) {
        loggerBuilder.AddLogger(new FileLogger(encoding));
        
        return loggerBuilder;
    }
}