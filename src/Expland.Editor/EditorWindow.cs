using Silk.NET;
using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.Windowing;
using Silk.NET.OpenGL;
using Silk.NET.OpenGL.Extensions.ImGui;
using ImGuiNET;
using System.IO.Pipes;
using StreamJsonRpc;
using System.Diagnostics;

namespace Expland.Editor;

public class EditorWindow
{
#pragma warning disable 8618
	IWindow window;
	IInputContext inputContext;
	GL gl;
	ImGuiController imGuiController;
	Process gameInstance;

	EditorTransport editorRpcInterface;
#pragma warning restore 8618

	public void Run()
	{
		editorRpcInterface = new EditorTransport();

		var windowOptions = WindowOptions.Default;
		windowOptions.Size = new Vector2D<int>(1280, 720);
		windowOptions.Title = "Expland Editor";

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
			ImGui.GetIO().ConfigFlags |= ImGuiConfigFlags.DockingEnable;
		}

		void OnWindowUpdate(double dt)
		{
			imGuiController.Update((float)dt);

			ImGui.DockSpaceOverViewport(ImGui.GetMainViewport());

			if (ImGui.Begin("Test"))
			{
				if (ImGui.Button("Launch Game"))
				{
					Console.WriteLine(gameInstance);
					if (gameInstance != null)
					{
						gameInstance.Kill();
					}

					gameInstance = Process.Start(new ProcessStartInfo("cmd.exe")
					{
						WindowStyle = ProcessWindowStyle.Normal,
						RedirectStandardInput = true,
						RedirectStandardOutput = true,
						Arguments = "/C dotnet run --project src/Expland.Game/Expland.Game.csproj"
					})!;

					var rpc = JsonRpc.Attach(
						gameInstance.StandardInput.BaseStream,
						gameInstance.StandardOutput.BaseStream,
						this.editorRpcInterface
					);
                    var gameRpcInterface = rpc.Attach<Expland.Transport.IGameTransport>();

					// Task.WaitAll(rpc.Completion);
				}

				ImGui.Text("Last received message: ");
				ImGui.SameLine();
				ImGui.Text(editorRpcInterface.lastMessage);

				ImGui.End();
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