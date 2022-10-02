namespace Expland.Logging.ConsoleLogging;

public class DefaultFormatter : IFormatter
{
	public FormattedString Format(LogLevel logLevel, string message, int lineNumber, string filePath, string caller, DateTime time)
	{
		var formattedString = new FormattedString();

#if DEBUG
		string relFilePath = filePath.Substring(Environment.CurrentDirectory.Length);
#else
		string relFilePath = filePath;
#endif

		ConsoleColor defaultForegroundColor = ConsoleColor.White;
		ConsoleColor defaultBackgroundColor = ConsoleColor.Black;

		formattedString.Fragments.Add(new FormattedString.Fragment(
			defaultForegroundColor,
			defaultBackgroundColor,
			$"{DateTime.Now} - ["
		));

		formattedString.Fragments.Add(new FormattedString.Fragment(
			this.MapLogLevelToConsoleColor(logLevel),
			defaultBackgroundColor,
			$"{logLevel}"
		));

		formattedString.Fragments.Add(new FormattedString.Fragment(
			defaultForegroundColor,
			defaultBackgroundColor,
			$"] - "
		));

		formattedString.Fragments.Add(new FormattedString.Fragment(
			logLevel == LogLevel.ERROR ? ConsoleColor.DarkRed : ConsoleColor.Yellow,
			defaultBackgroundColor,
			$"{message} "
		));

		formattedString.Fragments.Add(new FormattedString.Fragment(
			defaultForegroundColor,
			defaultBackgroundColor,
			$"- {caller} ({relFilePath}:{lineNumber})\r\n"
		));

		return formattedString;
	}

	private ConsoleColor MapLogLevelToConsoleColor(LogLevel logLevel)
	{
		switch (logLevel)
		{
			case LogLevel.NONE:
				return ConsoleColor.White;
			case LogLevel.TRACE:
				return ConsoleColor.Green;
			case LogLevel.DEBUG:
				return ConsoleColor.Gray;
			case LogLevel.INFO:
				return ConsoleColor.Cyan;
			case LogLevel.WARN:
				return ConsoleColor.DarkYellow;
			case LogLevel.ERROR:
				return ConsoleColor.DarkRed;
			default:
				return ConsoleColor.White;
		}
	}
}