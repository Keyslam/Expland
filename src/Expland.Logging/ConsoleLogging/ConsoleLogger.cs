namespace Expland.Logging.ConsoleLogging;

internal class ConsoleLogger : BaseLogger
{
	private IFormatter Formatter { get; }

	public ConsoleLogger(IFormatter formatter, LogLevel logLevel = LogLevel.TRACE) : base(logLevel) { 
		this.Formatter = formatter;
	}

	protected override void Write(LogLevel logLevel, string message, int lineNumber, string filePath, string caller)
	{
		var formattedString = this.Formatter.Format(
			logLevel,
			message,
			lineNumber,
			filePath,
			caller,
			DateTime.Now
		);

		foreach (var fragment in formattedString.Fragments) {
			Console.ForegroundColor = fragment.ForegroundColor;
			Console.BackgroundColor = fragment.BackgroundColor;
			Console.Write(fragment.Text);
		}
		Console.ResetColor();
	}
}