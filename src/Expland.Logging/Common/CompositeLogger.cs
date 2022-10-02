namespace Expland.Logging;

internal class CompositeLogger : BaseLogger
{
	private LogLevel logLevel;
	public override LogLevel LogLevel
	{
		get => this.logLevel;
		set
		{
			this.logLevel = value;

			if (this.loggers == null)
				return;

			this.CascadeLogLevel();
		}
	}

	private List<ILogger> loggers;

	public CompositeLogger(LogLevel logLevel = LogLevel.TRACE) : base(logLevel)
	{
		this.loggers = new List<ILogger>();
		this.LogLevel = logLevel;
	}

	public void AddLogger(ILogger logger)
	{
		this.loggers.Add(logger);
		logger.LogLevel = this.LogLevel;
	}

	public void RemoveLogger(ILogger logger)
	{
		this.loggers.Remove(logger);
	}

	protected override void Write(LogLevel logLevel, string message, int lineNumber = 0, string filePath = "", string caller = "")
	{
		foreach (ILogger logger in this.loggers)
			logger.Log(logLevel, message, lineNumber, filePath, caller);
	}

	public override void Flush()
	{
		foreach (ILogger logger in this.loggers)
			logger.Flush();
	}

	private void CascadeLogLevel()
	{
		foreach (ILogger logger in this.loggers)
			logger.LogLevel = this.logLevel;
	}
}