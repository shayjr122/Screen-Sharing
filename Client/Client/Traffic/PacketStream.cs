using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Traffic
{
    public class PacketStreamReader
    {
        private const int BUFFER_SIZE = 970000;// 94 kb maximum
        private NetworkStream _networkStream;
        public PacketStreamReader(NetworkStream networkStream)
        {
            _networkStream = networkStream;
        }
        public NetworkStream GetNetworkStream()
        {
            return _networkStream;
        }
        public Packet Read()
        {
            string msg = "";
            try
            {
                msg = ReadString();
                if (msg.Contains('\0'))
                {
                    msg = msg.Substring(0, msg.IndexOf('\0'));
                }


                return Packet.FromJson(msg);
            }
            catch
            {
                throw new Exception("Read Error");
            }
        }

        private string ReadString()
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            int size = _networkStream.Read(buffer, 0, buffer.Length);
            string data = Encoding.UTF8.GetString(buffer);

            return data.Substring(0, size);
        }
    }

    public class PacketStreamWriter
    {
        private NetworkStream _networkStream;
        public PacketStreamWriter(NetworkStream networkStream)
        {
            _networkStream = networkStream;
        }
        public NetworkStream GetNetworkStream()
        {
            return _networkStream;
        }
        public void Write(Packet packet)
        {
            try
            {
                WriteString(packet.ToJson());
            }
            catch
            {
                throw new Exception("write Error");
            }
        }
        private void WriteString(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            _networkStream.Write(buffer, 0, buffer.Length);
        }
    }
}
