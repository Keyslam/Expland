namespace Expland.Logging;

public class LoggerBuilder
{
	public ILogger Result { get; private set; }

#pragma warning disable 8618
	public LoggerBuilder()
	{
		this.Reset();
	}
#pragma warning restore 8618

	public LoggerBuilder SetLogLevel(LogLevel logLevel)
	{
		this.Result.LogLevel = logLevel;

		return this;
	}

	public void Reset()
	{
		this.Result = new VoidLogger(LogLevel.NONE);
	}

	public void AddLogger(ILogger logger)
	{
		if (this.Result is VoidLogger)
			this.Result = logger;
		else if (this.Result is CompositeLogger compositeLogger)
			compositeLogger.AddLogger(logger);
		else
		{
			var previous = this.Result;
			this.Result = new CompositeLogger(this.Result.LogLevel);
			this.AddLogger(previous);
			this.AddLogger(logger);
		}
	}
}