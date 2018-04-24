using HundServer.Networking.Packets.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundServer.Networking.Packets.Packet
{
    abstract class IPacket
    {
        protected PacketWriter pw = new PacketWriter();
        protected PacketReader pr;
        protected byte[] packet;

        public byte[] Data
        {
            get { return pw.GetBytes(); }
            set { }
        }
    }
}
