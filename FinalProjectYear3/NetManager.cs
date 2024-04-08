using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace FinalProjectYear3;

public static class NetManager
{
    static TcpListener _listener;
    static TcpClient _connectedClient;
    static Stream _stream;
    // Client stuff

    public static void Client()
    {
        _connectedClient = new TcpClient("127.0.0.1", 1234);
        Listen();
    }

    // Host stuff

    public static void Host()
    {
        _listener = new TcpListener(IPAddress.Any, 1234);
        _listener.Start();
        // Program freezes until someone connects.
        _connectedClient = _listener.AcceptTcpClient();
    }

static Thread listenThread = new(() => {
        _stream = _connectedClient.GetStream();
        while(_connectedClient.Connected)
        {
            // Buffer contains data that was received
            byte[] _buffer = new byte[_connectedClient.ReceiveBufferSize];
            _stream.Read(_buffer);
            // BitConverter.ToBoolean(_buffer[0]);
            bool _hitResult = _buffer[0] > 0;
            int _damageResult = BitConverter.ToInt32(_buffer[1..]);
            if(_hitResult)
            {
                Console.WriteLine($"Got hit for: {_damageResult}");
            }
            else
            {
                Console.WriteLine("The bullet missed. Hit for: 0");
            }
        }
});

    public static void Listen()
    {
        listenThread.Start();
    }

    public static void Send(bool hit, int damage)
    {
        // bool = 1 byte
        // int = 4 bytes
        // Max 5 in length per byte array
        List<byte> _bytes = new();
        _bytes.AddRange(BitConverter.GetBytes(hit));
        _bytes.AddRange(BitConverter.GetBytes(damage));
        _stream.Write(_bytes.ToArray());
    }

}
