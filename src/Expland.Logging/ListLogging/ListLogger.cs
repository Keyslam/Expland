namespace Expland.Logging;

// TODO Make Logs private, provide function instead
internal class ListLogger : BaseLogger {
	public class LogData {
		public DateTime Time { get; }
		public LogLevel LogLevel { get; }
		public string Message { get; }
		public int LineNumber { get; }
		public string RelativeFilePath { get; }
		public string Caller { get; }

		public LogData(DateTime time, LogLevel logLevel, string message, int lineNumber, string relativeFilePath, string caller) {
			this.Time = time;
			this.LogLevel = logLevel;
			this.Message = message;
			this.LineNumber = lineNumber;
			this.RelativeFilePath = relativeFilePath;
			this.Caller = caller;
		}
	}

	public List<LogData> Logs { get; }

	public ListLogger(LogLevel logLevel = LogLevel.TRACE) : base(logLevel) {
		this.Logs = new List<LogData>();
	}

	protected override void Write(LogLevel logLevel, string message, int lineNumber, string filePath, string caller) {
		string relFilePath = filePath.Substring(Environment.CurrentDirectory.Length);

		var logData = new LogData(
			DateTime.Now,
			logLevel,
			message,
			lineNumber,
			relFilePath,
			caller
		);

		this.Logs.Add(logData);
	}
}