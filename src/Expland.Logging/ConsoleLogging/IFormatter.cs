namespace Expland.Logging.ConsoleLogging;

public interface IFormatter {
    FormattedString Format(LogLevel logLevel, string message, int lineNumber, string filePath, string caller, DateTime time);
}