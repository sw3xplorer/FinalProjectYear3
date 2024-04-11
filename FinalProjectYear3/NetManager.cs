using System.IO.Pipes;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace FinalProjectYear3;

public static class NetManager
{
    // Declare variables
    static bool _isClient;
    static TcpListener _listener;
    static TcpClient _connectedClient;
    static Stream _stream;

    // Client
    // A method used on the client side. It attempts to connect to the host via TCP.
    public static void Client()
    {
        // Try to connect to host.
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

    // Host
    // Method used on the host side. It listens after an IP that is trying to connect.
    public static void Host()
    {
        // Define the listener variable and start listening.
        _listener = new TcpListener(IPAddress.Any, 1234);
        _listener.Start();

        // Program freezes until someone connects. (Host side only)
        // Accepts the incoming IP and begins to listen.
        _connectedClient = _listener.AcceptTcpClient();
        Listen();
    }
    // A thread is a "while loop" that can be run simultaneosly as the rest of the code
    // runs. This thread is used for listening after data streams.
    static Thread _listenThread = new(() =>
    {
        // Set the stream as the stream from the connected client.
        _stream = _connectedClient.GetStream();

        // While connected, tries to read the buffer.
        while (_connectedClient.Connected)
        {
            // Buffer contains data that was received
            // bool = 1 byte
            // int = 4 bytes
            // Max 5 bytes per byte array.

            // Makes a new byte buffer. Sets the length to the client's buffer.
            byte[] _buffer = new byte[_connectedClient.ReceiveBufferSize];
            try
            {
                // Read the stream with a span of the buffer array.
                _stream.Read(_buffer);
            }
            catch
            {
                // Display message if the stream can't be read.
                Console.WriteLine("Other user disconnected. Exiting...");
                Task.Delay(3000).Wait();
                Environment.Exit(0);
            }
            // Define if _hitResult is true if the first byte in the buffer (a bool) is
            // true or not. A bool is true if it's 1 and false if it's 0.
            bool _hitResult = _buffer[0] > 0;

            // Converts the rest of the bytes into 32-bit integer. Converts the byte at 
            // index 1 and onwards.
            int _damageResult = BitConverter.ToInt32(_buffer[1..]);

            // Code for aligning cursor and cleaning the correct area.
            if (_isClient)
            {
                ClearArea.Clear(0, 28, 30, 29);
                Console.SetCursorPosition(0, 28);
            } 
            else
            {
                ClearArea.Clear(0, 10, 30, 11);
                Console.SetCursorPosition(0, 10);
            }

            
            if (_hitResult)
            {
                Console.WriteLine($"Hit for: {_damageResult}");
                // Write the damage received.
            }
            else
            {
                Console.WriteLine("The bullet missed. Hit for: 0");
                // Inform that the bullet missed.
            }
            if (_isClient)
            {
                // If this instance is a client, send the following data back to the host:
                // Did the bullet hit? How much damage the bullet dealt.
                Send(_hitResult, _damageResult);
            }
        }
    });

    // Method that starts the thread.
    public static void Listen()
    {
        _listenThread.Start();
    }

    public static void Send(bool hit, int damage)
    {
        // bool = 1 byte
        // int = 4 bytes
        // Max 5 in length per byte array

        // Makes a list of data (bytes) to be sent. 
        List<byte> _bytes = new();

        // Adds the range (size) of bytes to the list.
        _bytes.AddRange(BitConverter.GetBytes(hit));
        _bytes.AddRange(BitConverter.GetBytes(damage));

        // Check if the stream is flowing (devices are connected).
        if (_stream != null)
        {
            Console.SetCursorPosition(0, 8);
            _stream.Write(_bytes.ToArray());
            // Writes what the list contains. It is first converted to an array.
        }
    }
    // Decides if the instance of the program is the host or not. Returns the result.
    public static string DecideHost()
    {
        Console.WriteLine("1 for host or 2 for client.");
        string _result = Console.ReadLine();
        // Store the user input in a string. Then check if it's valid.
        while (_result != "1" || _result != "2")
        {
            if (_result == "1")
            {
                Host();
                _isClient = false;
                break;
            }
            else if (_result == "2")
            {
                Client();
                _isClient = true;
                break;
            }
            else
            {
                // Failsafe so you can't write gibberish and select something.
                Console.WriteLine("Write 1 or 2.");
                _result = Console.ReadLine();
            }
        }
        return _result;
    }
}
