using Assets.Networking.Packets.Headers;
using Assets.Networking.Packets.IO;
using Assets.Networking.Packets.Packet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Networking.Packets
{
    class PacketHandler : MonoBehaviour
    {
        public static void Handle(byte[] packet)
        {
            PacketReader pr = new PacketReader(packet);
            Header header = (Header)pr.ReadUInt16();
            Debug.Log(DateTime.Now + " | Received packet: " + header);

            switch (header)
            {
                case Header.Init:
                    {
                        InitialPacket pc = new InitialPacket(pr);
                    }
                    break;
                case Header.Position:
                    {
                        PositionPacket pc = new PositionPacket(pr);
                    }
                    break;
            }
        }
    }
}
