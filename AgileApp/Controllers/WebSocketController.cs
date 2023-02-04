using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;

namespace AgileApp.Controllers
{
    // <snippet>
    public class WebSocketController : ControllerBase
    {
        [HttpGet("/chat")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Echo(webSocket);
            }
            else
            {
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            }
        }
        // </snippet>

        private static async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var receiveResult = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            var buster = new Models.WebsocketMessage { type = "MESSAGE", payload = new Models.Payload { text = "Moj jest ten kawalek podlogi!", date = DateTime.UtcNow.ToString(), userId = 1, sender = "superUser" } };
            string deptObj = JsonSerializer.Serialize<Models.WebsocketMessage>(buster);
            byte[] bytesTTTtable = Encoding.ASCII.GetBytes(deptObj);
            var sendReq = new ArraySegment<byte>(bytesTTTtable);

            //var testBuster = JsonSerializer.Deserialize<List<Models.WebsocketMessage>>(sendReq);

            while (!receiveResult.CloseStatus.HasValue)
            {
                await webSocket.SendAsync(
                    new ArraySegment<byte>(bytesTTTtable, 0, sendReq.Count),
                    receiveResult.MessageType,
                    receiveResult.EndOfMessage,
                    CancellationToken.None);

                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }
    }
}
