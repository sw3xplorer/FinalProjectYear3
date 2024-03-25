using System.Net;
using System.Net.Sockets;
using Microsoft.VisualBasic;

namespace FinalProjectYear3;

public class NetManager
{

    // Client stuff
    public void Test()
    {
        var ownClient = new TcpClient("127.0.0.1", 1234);
    }

    // Host stuff

    public void HostTest()
    {
        var listener = new TcpListener(IPAddress.Any, 1234);
        listener.Start();
        // Program freezes until someone connects.
        var connectedClient = listener.AcceptTcpClient();
    }

}
