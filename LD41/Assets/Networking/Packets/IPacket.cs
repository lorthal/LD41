using System;

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
