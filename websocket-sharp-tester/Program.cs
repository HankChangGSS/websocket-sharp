using WebSocketSharp;

//https://www.piesocket.com/websocket-tester
using (var ws = new WebSocketSharp.WebSocket("wss://demo.piesocket.com/v3/channel_123?api_key=VCXCEuvhGcBDP7XhiJJUDvR1e1D3eiVjgZ9VRiaV&notify_self"))
{
    ws.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 | System.Security.Authentication.SslProtocols.Tls11 | System.Security.Authentication.SslProtocols.Tls;

    ws.OnMessage += (sender, e) =>
    {
        WS_OnMessage(sender, e);
        Console.WriteLine("WebSocket says: " + e.Data);
    };

    ws.Connect();

    ws.Send("Hello");

    while (true)
    {
        ws.Ping("test");
        Task.Delay(10000).Wait();
    }

    Console.ReadKey(true);
}

static void WS_OnMessage(object sender, MessageEventArgs e)
{
    //Process Data...
    Console.WriteLine(e.Data);
    Console.WriteLine();
    Console.WriteLine();
}