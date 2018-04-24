using HundServer.Networking.Packets;
using HundServer.Networking.Packets.Packet;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HundServer.Networking.Core
{
    class ServerSocket
    {
        public Server main { get; private set; }
        public Socket _socket { get; private set; }
        private byte[] _buffer = new byte[1024];

        public ServerSocket(Server server)
        {
            this.main = server;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Bind(int port)
        {
            _socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), port));
        }

        public void Listen(int backlog)
        {
            _socket.Listen(backlog);
        }

        public void Accept()
        {
            _socket.BeginAccept(AcceptedCallback, null);
        }

        private void AcceptedCallback(IAsyncResult result)
        {
            Socket clientSocket = _socket.EndAccept(result);
            string newToken = Guid.NewGuid().ToString();
            clientSocket.Send(new InitialPacket(newToken).Data);
            //for (int i = 0; i < 40; i++)
            //{
            //    clientSocket.Send(new PositionPacket(0, 0, i).Data);
            //    Thread.Sleep(3);
            //    Console.WriteLine("Sent " + i);
            //}
            main.AddNewClient(newToken, clientSocket);
            _buffer = new byte[1024];
            clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, clientSocket);
            Accept();
        }

        public void TryReceive()
        {
            _buffer = new byte[1024];
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                Socket clientSocket = (Socket)result.AsyncState;
                if (clientSocket.Connected)
                {
                    int bufferSize = clientSocket.EndReceive(result);
                    byte[] packet = new byte[bufferSize];
                    Array.Copy(_buffer, packet, packet.Length);

                    //handle packet
                    if (packet.Length > 0)
                    {
                        PacketHandler.Handle(packet, clientSocket);
                    }

                    _buffer = new byte[1024];
                    clientSocket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, clientSocket);
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.StackTrace);
            }
        }
    }
}
