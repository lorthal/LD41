using Assets.Networking.Packets.IO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Networking.Packets.Packet
{
    class InitialPacket : IPacket
    {
        string token;
        public InitialPacket(PacketReader pr1)
        {
            token = pr1.ReadString();
            Console.WriteLine("Received token: " + token);
            //MainThreadDispatcher.Instance().Enqueue(ThisWillBeExecutedOnTheMainThread());
            //TestBoxNet.getInstance().Move(0, 0, 40);
        }

        public IEnumerator ThisWillBeExecutedOnTheMainThread()
        {
            Debug.Log("This is executed from the main thread");
            TestBoxNet.getInstance().Move(0, 0, 40);
            yield return null;
        }
    }
}
