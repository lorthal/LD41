using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Assets.Networking.Packets.IO
{
    public class PacketWriter : BinaryWriter
    {
        private MemoryStream _ms;
        private BinaryFormatter _bf;

        public PacketWriter()
            : base()
        {
            _ms = new MemoryStream();
            _bf = new BinaryFormatter();
            OutStream = _ms;
        }

        public byte[] GetBytes()
        {
            Close();

            byte[] data = _ms.ToArray();

            return data;
        }
    }
}
