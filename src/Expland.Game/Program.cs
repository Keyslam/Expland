using Expland.Logging;

var logger = new LoggerBuilder()
	.SetLogLevel(LogLevel.DEBUG)
	.AddConsoleLogger()
	.AddFileLogger(System.Text.Encoding.UTF8)
	.Result;

logger.LogDebug("Test message");

logger.Flush();