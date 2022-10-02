using System.Runtime.CompilerServices;

namespace Expland.Logging;

public interface ILogger
{
	LogLevel LogLevel { get; set; }

	void Log(LogLevel logLevel, string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogTrace(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogDebug(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogInfo(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogWarn(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogError(string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");

	void LogIf(LogLevel logLevel, bool expression, string message, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogTraceIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogDebugIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogInfoIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogWarnIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");
	void LogErrorIf(string message, bool expression, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string filePath = "", [CallerMemberName] string caller = "");

	void Flush();
}