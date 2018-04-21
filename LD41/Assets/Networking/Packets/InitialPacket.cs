using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class InitialPacket : IPacket
{
    string token;
    public InitialPacket(PacketReader pr1)
    {
        token = pr1.ReadString();
        // rec
    }
}
