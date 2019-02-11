﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

#pragma warning disable CS0618 // Type or member is obsolete

namespace Server
{
    class Server : IDisposable
    {
        private int _portToListen;
        private List<Socket> _clients;
        private TcpListener _tcpListener;
        private Thread accepts;

        public Server(int portToListen)
        {
            PortToListen = portToListen;
            TcpListener = new TcpListener(PortToListen);
        }

        #region Properties
        public int PortToListen
        {
            get
            {
                return _portToListen;
            }
            set
            {
                _portToListen = value;
            }
        }
        public List<Socket> Clients
        {
            get
            {
                return _clients;
            }
            set
            {
                _clients = value;
            }
        }
        public TcpListener TcpListener
        {
            get
            {
                return _tcpListener;
            }
            set
            {
                _tcpListener = value;
            }
        }
        #endregion


        public void Dispose()
        {
            Stop();
            GC.SuppressFinalize(this);
        }


        private void Stop()
        {
            accepts.Abort();
        }
        public void Start()
        {
            TcpListener.Start();
            accepts = new Thread(StartAccept);
            accepts.Start();
        }
        private void StartAccept()
        {
            while(true)
            Clients.Add(TcpListener.AcceptSocket());
        }
    }
}
