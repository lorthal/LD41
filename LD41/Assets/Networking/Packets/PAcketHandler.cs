using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class PacketHandler
{
    public static void Handle(byte[] packet)
    {
        PacketReader pr = new PacketReader(packet);
        Header header = (Header)pr.ReadUInt16();
        Console.WriteLine(DateTime.Now + " | Received packet: " + header);

        switch (header)
        {
            case Header.Init:
                {
                    InitialPacket pc = new InitialPacket(pr);
                }
                break;
        }
    }
}
