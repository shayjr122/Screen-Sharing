using Client.Traffic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.User
{
    class Client
    {
        private string _server;
        private TcpClient _client;
        private int _portToSend;
        private PacketStreamWriter _writer;
        private PacketStreamReader _reader;

        public Client(string server, int portToSend)
        {
            Server = server;
            PortToSend = portToSend;
            TcpClient = new TcpClient();
            Connect();

        }

        private void Connect()
        {
            try
            {
                TcpClient.Connect(IPAddress.Parse(Server), 80);
            }
            catch
            {
                throw new Exception("faild to connect");
            }
            NetworkStream networkStream = TcpClient.GetStream();
            Writer = new PacketStreamWriter(networkStream);
            Reader = new PacketStreamReader(networkStream);
        }

        #region Properties
        public string Server
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;
            }
        }
        public TcpClient TcpClient
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
            }
        }
        public int PortToSend
        {
            get
            {
                return _portToSend;
            }
            set
            {
                _portToSend = value;
            }
        }
        public PacketStreamReader Reader
        {
            get
            {
                return _reader;
            }
            set
            {
                _reader = value;
            }
        }
        public PacketStreamWriter Writer
        {
            get
            {
                return _writer;
            }
            set
            {
                _writer = value;
            }
        }
        #endregion

    }
}
