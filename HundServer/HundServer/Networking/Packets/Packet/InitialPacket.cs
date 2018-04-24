using HundServer.Networking.Packets.Headers;
using HundServer.Networking.Packets.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundServer.Networking.Packets.Packet
{
    class InitialPacket : IPacket
    {
        public InitialPacket(string token)
        {
            pw.Write((ushort)Header.Init);
            pw.Write(token);
        }
    }
}
