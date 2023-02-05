using AgileApp.Services.Chat;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace AgileApp.Controllers
{
    // <snippet>
    public class WebSocketController : ControllerBase
    {
        private readonly IChatService _chatService;

        public WebSocketController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpGet("/chat")]
        public async Task Get()
        {
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                using var webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                await Load(webSocket);
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

            while (!receiveResult.CloseStatus.HasValue)
            {
                //await webSocket.SendAsync(
                //    new ArraySegment<byte>(buffer, 0, receiveResult.Count),
                //    receiveResult.MessageType,
                //    receiveResult.EndOfMessage,
                //    CancellationToken.None);

                receiveResult = await webSocket.ReceiveAsync(
                    new ArraySegment<byte>(buffer), CancellationToken.None);

                string s = Encoding.ASCII.GetString(buffer);

                var xd = "";
            }

            await webSocket.CloseAsync(
                receiveResult.CloseStatus.Value,
                receiveResult.CloseStatusDescription,
                CancellationToken.None);
        }

        private async Task Load(WebSocket webSocket)
        {
            var response = new Models.WebsocketMessageLoad();
            response.type = "LOAD";

            var messages = _chatService.Load();
            if (messages.Count > 0)
            {
                response.payload = messages;

                int count = 0;
                var msgRes = PrepareMessageFromList(response, out count);

                await webSocket.SendAsync(
                        new ArraySegment<byte>(msgRes, 0, count),
                        WebSocketMessageType.Text,
                        true,
                        CancellationToken.None);
            }
        }

        private byte[] PrepareMessageFromList(Models.WebsocketMessageLoad payload, out int count)
        {
            string json = JsonSerializer.Serialize<Models.WebsocketMessageLoad>(payload);
            json = json.Replace(@"\u0022", "\"").Replace("\"{", "{").Replace("}\"", "}");
            byte[] jsonBytesTable = Encoding.ASCII.GetBytes(json);
            var countRequest = new ArraySegment<byte>(jsonBytesTable);

            count = countRequest.Count; 
            return jsonBytesTable;
        }
    }
}
