using Assets.Networking.Packets.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Networking.Packets.Packet
{
    class PositionPacketSend : IPacket
    {
        public PositionPacketSend(int x, int y, int z)
        {
            pw.Write((uint)Header.Position);
            pw.Write(x);
            pw.Write(y);
            pw.Write(z);
        }
    }
}
