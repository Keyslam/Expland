using Expland.Transport;

namespace Expland.Editor;

public class EditorTransport : IEditorTransport
{
	public string lastMessage = String.Empty;

	public void Test(string message)
	{
		lastMessage = message;
	}
}