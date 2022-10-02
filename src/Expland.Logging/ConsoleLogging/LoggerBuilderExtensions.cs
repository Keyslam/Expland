using Expland.Logging.ConsoleLogging;

namespace Expland.Logging;

public static partial class LoggerBuilderExtensions
{
	public static LoggerBuilder AddConsoleLogger(this LoggerBuilder loggerBuilder)
	{
		loggerBuilder.AddLogger(new ConsoleLogger(new DefaultFormatter()));

		return loggerBuilder;
	}
}