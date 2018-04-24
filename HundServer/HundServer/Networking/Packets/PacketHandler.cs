using HundServer.Networking.Core;
using HundServer.Networking.Packets.Headers;
using HundServer.Networking.Packets.IO;
using HundServer.Networking.Packets.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HundServer.Networking.Packets
{
    public static class PacketHandler
    {
        public static void Handle(byte[] packet, Socket clientSocket)
        {
            Console.WriteLine("Reading packet");
            PacketReader pr = new PacketReader(packet);

            Header header = (Header)pr.ReadInt16();

            switch (header)
            {
                case Header.Init:
                    {
                        Console.WriteLine("init packet");
                    }
                    break;
                case Header.Position:
                    {
                        int y = pr.ReadInt32();
                        int z = pr.ReadInt32();
                        int x = pr.ReadInt32();

                        //if(Server.ServerSocket.main.client1.token == token)
                        //{
                            Console.WriteLine("Sending position to enemy 1");
                            Server.ServerSocket.main.client1.socket.Send(new PositionPacket(x, y, z).Data);
                        //}
                        //if (Server.ServerSocket.main.client2.token == token)
                        //{
                        //    Console.WriteLine("Sending position to enemy 1");
                        //    Server.ServerSocket.main.client1.socket.Send(new PositionPacket(x, y, z).Data);
                        //}
                    }
                    break;
            }
        }
    }
}
