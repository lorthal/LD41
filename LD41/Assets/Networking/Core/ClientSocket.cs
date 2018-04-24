using Assets.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

namespace Assets.Networking.Core
{
    public class ClientSocket : MoveBehaviour
    {
        public Socket _socket;
        private byte[] _buffer;

        public ClientSocket()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ipAddress, int port)
        {
            _socket.BeginConnect(new IPEndPoint(IPAddress.Parse(ipAddress), port), ConnectionCallback, null);
        }

        private void ConnectionCallback(IAsyncResult asyncResult)
        {
            if (_socket.Connected)
            {
                Debug.Log("Connected to the server");
                _buffer = new byte[1024];
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            else
            {
                Debug.Log("Could not connect");
            }
        }

        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                int bufferLenght = _socket.EndReceive(result);
                byte[] packet = new byte[bufferLenght];
                Array.Copy(_buffer, packet, packet.Length);

                PacketHandler.Handle(packet);

                _buffer = new byte[1024];
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, ReceiveCallback, null);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
