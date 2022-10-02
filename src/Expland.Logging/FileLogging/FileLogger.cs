using System.Text;

namespace Expland.Logging;

// TODO Make filename an argument
// TODO Delegate formatting to other class
internal class FileLogger : BaseLogger {
	private string fileName = String.Empty;
	private StreamWriter file;

	public FileLogger(Encoding encoding, LogLevel logLevel = LogLevel.TRACE) : base(logLevel) {
		fileName = $"{DateTime.Now:yyyyMMddTHHmmss}-Log.txt";

		file = new StreamWriter(fileName, false, encoding);
	}

	public override void Flush() {
		file.Flush();
	}
	
	protected override void Write(LogLevel logLevel, string message, int lineNumber, string filePath, string caller) {
		string relFilePath = filePath.Substring(Environment.CurrentDirectory.Length);

		file.WriteLine($"{DateTime.Now} - [{logLevel}] - {message} ({caller} {relFilePath}:{lineNumber})");
	}
}