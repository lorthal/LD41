using HundServer.Networking.Packets.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HundServer.Networking.Core
{
    class Server
    {
        //public Dictionary<string, Socket> _clients { get; private set; }
        public Client client1, client2;
        public static ServerSocket ServerSocket;
        public bool isRunning { get; private set; }

        public Server()
        {
            isRunning = false;
            //_clients = new Dictionary<string, Socket>();
            ServerSocket = new ServerSocket(this);
            ServerSocket.Bind(11000);
            ServerSocket.Listen(500);
            ServerSocket.Accept();

            if (ServerSocket._socket.Connected)
            {
                isRunning = true;
                Console.WriteLine("Connected");
            }
            Console.WriteLine("Connected");
        }

        public void AddNewClient(string token, Socket socket)
        {
            //_clients.Add(token, socket);

            if (client1 == null)
            {
                client1 = new Client(token, socket, 0, 0, 0);
            }
            else if(client2 == null)
            {
                client2 = new Client(token, socket, 0, 0, 0);
            }
            Console.WriteLine("New client added to list");
            Console.WriteLine(token);
        }
    }
}
