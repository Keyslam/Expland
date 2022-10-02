using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using ImGuiNET;
using StreamJsonRpc;

namespace Expland.Game;

public class GameWindow
{
#pragma warning disable 8618
	IWindow window;
	IInputContext inputContext;
	GL gl;
	ImGuiController imGuiController;
	JsonRpc rpc;
	Expland.Transport.IEditorTransport editorRpcInterface;
#pragma warning restore 8618

	string input = string.Empty;

	public void Run()
	{
		var windowOptions = WindowOptions.Default;
		windowOptions.Size = new Vector2D<int>(1280, 720);
		windowOptions.Title = "Expland";

		window = Window.Create(windowOptions);
		window.Load += OnWindowLoad;
		window.Update += OnWindowUpdate;
		window.Render += OnWindowRender;

		window.Run();

		void OnWindowLoad()
		{
			inputContext = window.CreateInput();
			gl = window.CreateOpenGL();
			imGuiController = new ImGuiController(gl, window, inputContext);
			ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable; // new

			var moreOptions = WindowOptions.Default;
			moreOptions.Size = new Vector2D<int>(320, 320);
			moreOptions.Title = "Child window";
			// var anotherWindow = window.CreateWindow(moreOptions);
			// anotherWindow.Run();

			foreach (var keyboard in inputContext.Keyboards)
			{
				keyboard.KeyDown += (keyboard, key, amount) =>
				{
					// Console.WriteLine(key.ToString());
				};
			}

			rpc = JsonRpc.Attach(
				Console.OpenStandardOutput(),
				Console.OpenStandardInput(),
				new GameTransport()
			);

			editorRpcInterface = rpc.Attach<Expland.Transport.IEditorTransport>();
		}

		void OnWindowUpdate(double dt)
		{
			imGuiController.Update((float)dt);

			ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());

			ImGui.InputText("Message", ref input, 100);

			if (ImGui.Button("Send a Message")) {
				editorRpcInterface.Test(input);
			}
		}


		void OnWindowRender(double dt)
		{
			gl.Clear(ClearBufferMask.ColorBufferBit);

			imGuiController.Render();
		}
	}

	public void Quit()
	{
		window.Close();
	}
}