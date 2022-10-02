using System.Runtime.CompilerServices;

namespace Expland.Logging;

internal abstract class BaseLogger : ILogger
{
	public virtual LogLevel LogLevel { get; set; }

	public BaseLogger(LogLevel logLevel)
	{
		this.LogLevel = logLevel;
	}

	public void Log(LogLevel logLevel, string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		if (logLevel == LogLevel.NONE)
			return;

		if (this.LogLevel > logLevel)
			return;

		this.Write(logLevel, message, lineNumber, filePath, caller);
	}

	public void LogIf(LogLevel logLevel, bool expression, string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		if (logLevel == LogLevel.NONE)
			return;

		if (logLevel > this.LogLevel)
			return;

		if (!expression)
			return;

		this.Write(logLevel, message, lineNumber, filePath, caller);
	}

	public void LogTrace(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.Log(LogLevel.TRACE, message, lineNumber, filePath, caller);
	}

	public void LogTraceIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.LogIf(LogLevel.TRACE, expression, message, lineNumber, filePath, caller);
	}

	public void LogDebug(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.Log(LogLevel.DEBUG, message, lineNumber, filePath, caller);
	}

	public void LogDebugIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.LogIf(LogLevel.DEBUG, expression, message, lineNumber, filePath, caller);
	}

	public void LogInfo(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.Log(LogLevel.INFO, message, lineNumber, filePath, caller);
	}

	public void LogInfoIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.LogIf(LogLevel.INFO, expression, message, lineNumber, filePath, caller);
	}

	public void LogWarn(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.Log(LogLevel.WARN, message, lineNumber, filePath, caller);
	}

	public void LogWarnIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.LogIf(LogLevel.WARN, expression, message, lineNumber, filePath, caller);
	}

	public void LogError(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.Log(LogLevel.ERROR, message, lineNumber, filePath, caller);
	}

	public void LogErrorIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "")
	{
		this.LogIf(LogLevel.ERROR, expression, message, lineNumber, filePath, caller);
	}

	public virtual void Flush() { }

	protected abstract void Write(LogLevel logLevel, string message, int lineNumber = 0, string filePath = "", string caller = "");
}