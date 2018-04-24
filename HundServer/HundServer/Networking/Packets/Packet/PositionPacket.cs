using HundServer.Networking.Packets.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundServer.Networking.Packets.Packet
{
    class PositionPacket : IPacket
    {
        public PositionPacket(int x, int y, int z)
        {
            pw.Write((ushort)Header.Position);
            pw.Write(x);
            pw.Write(y);
            pw.Write(z);
        }
    }
}
