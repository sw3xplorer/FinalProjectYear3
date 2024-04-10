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
        try
        {
            _connectedClient = new TcpClient("127.0.0.1", 1234);
            Listen();
        }
        catch
        {
            Console.WriteLine("Failed to connect. Enter to retry:");
            Console.ReadLine();
        }
    }

    // Host stuff

    public static void Host()
    {

        _listener = new TcpListener(IPAddress.Any, 1234);
        _listener.Start();
        // Program freezes until someone connects.
        _connectedClient = _listener.AcceptTcpClient();
        Listen();
    }

    static Thread listenThread = new(() =>
    {
        _stream = _connectedClient.GetStream();
        while (_connectedClient.Connected)
        {
            // Buffer contains data that was received
            byte[] _buffer = new byte[_connectedClient.ReceiveBufferSize];
            try
            {
                _stream.Read(_buffer);
            }
            catch
            {
                Console.WriteLine("Host disconnected. Exiting...");
                Task.Delay(2000).Wait();
                Environment.Exit(0);
            }
            // BitConverter.ToBoolean(_buffer[0]);
            bool _hitResult = _buffer[0] > 0;
            int _damageResult = BitConverter.ToInt32(_buffer[1..]);
            if (_hitResult)
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
        if(_stream != null)
        {
            _stream.Write(_bytes.ToArray());
        }
    }
    public static string DecideHost()
    {
        Console.WriteLine("1 for host or 2 for client.");
        string _result = Console.ReadLine();
        while (_result != "1" || _result != "2")
        {
            if (_result == "1")
            {
                Host();
                break;
            }
            else if (_result == "2")
            {
                Client();
                break;
            }
            else
            {
                Console.WriteLine("Write 1 or 2.");
                _result = Console.ReadLine();
            }
        }
        return _result;
    }
}
