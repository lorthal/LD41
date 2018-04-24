using Assets.Networking.Packets.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Networking.Packets.Packet
{
    class PositionPacket : IPacket
    {
        int x, y, z;
        public PositionPacket(PacketReader pr1)
        {
            x = pr1.ReadInt32();
            y = pr1.ReadInt32();
            z = pr1.ReadInt32();
            MainThreadDispatcher.Instance().Enqueue(ThisWillBeExecutedOnTheMainThread());
            //TestBoxNet.getInstance().Move(0, 0, 40);
        }

        public IEnumerator ThisWillBeExecutedOnTheMainThread()
        {
            TestBoxNet.getInstance().Move(x,y,z);
            yield return null;
        }
    }
}
