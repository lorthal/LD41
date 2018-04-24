using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HundServer.Networking
{
    class Client
    {
        public string token;
        public Socket socket;
        public int x, y, z;

        public Client(string token, Socket socket, int x, int y, int z)
        {
            this.token = token;
            this.socket = socket;
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
