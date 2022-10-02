namespace Expland.Logging;

internal class VoidLogger : BaseLogger
{
	public VoidLogger(LogLevel logLevel = LogLevel.TRACE) : base(logLevel) { }

	protected override void Write(LogLevel logLevel, string message, int lineNumber = 0, string filePath = "", string caller = "")
	{

	}
}