using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace KestrelWebServer
{
    public class WebServer
    {
        public WebServer()
        {
			/* for simplicity everything in constructor */
			var httpUrl = @"http://127.0.0.1:8008/";
			var hostBuilder = new WebHostBuilder()
				.UseKestrel()
				.UseUrls(httpUrl);

			hostBuilder.Configure(app =>
			{
				app.UseWebSockets();
				app.Run(async context =>
				{
					if (!context.WebSockets.IsWebSocketRequest)
					{
						await context.Response.WriteAsync("Not WebSocketRequest");
					}
					else
					{
						try
						{
							await context.WebSockets.AcceptWebSocketAsync();
							Console.WriteLine("Connected");
						}
						catch (Exception e)
						{
							Console.WriteLine(e);
							throw;
						}
					}
				});
			});

			var host = hostBuilder.Build();
			host.Start();
		}
    }
}