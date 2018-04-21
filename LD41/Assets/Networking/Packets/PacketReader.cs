using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public class PacketReader : BinaryReader
{
    private BinaryFormatter _bf;
    public PacketReader(byte[] data)
        : base(new MemoryStream(data))
    {
        _bf = new BinaryFormatter();
    }
}
