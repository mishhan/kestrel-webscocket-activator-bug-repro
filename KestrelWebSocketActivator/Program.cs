using System.Net.WebSockets;
using System.Reflection;

var assembly = Assembly.LoadFrom("KestrelWebServer.dll");
Activator.CreateInstance(assembly.ExportedTypes.First());

var webSocketClient = new ClientWebSocket();
var token = new CancellationToken();
try
{
	await webSocketClient.ConnectAsync(new Uri("ws://127.0.0.1:8008/"), token);
}
catch (Exception e)
{
	Console.WriteLine(e);
	throw;
}
