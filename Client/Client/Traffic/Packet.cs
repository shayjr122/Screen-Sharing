using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Traffic
{
    public enum SessionType
    {
        ROOM = 0,
        SHARE_SCREEN = 1,
        CHAT = 2
    }

    public enum MessageType
    {
        STRING = 0,
        SHARE_SCREEN = 1,
        PIC = 2
    }

    public class Packet
    {
        // Header
        private int _id;// Session id
        private string _userName;// How send this message
        private SessionType _sessionType;// Session type
        private MessageType _messageType;// Message type

        // body
        private byte[] _body;

        public Packet(int id, string userName, SessionType sessionType, MessageType messageType, byte[] body)
        {
            Id = id;
            UserName = userName;
            SessionType = sessionType;
            MessageType = messageType;
            Body = body;
        }

        #region Properties
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }
        public SessionType SessionType
        {
            get
            {
                return _sessionType;
            }
            set
            {
                _sessionType = value;
            }
        }
        public MessageType MessageType
        {
            get
            {
                return _messageType;
            }
            set
            {
                _messageType = value;
            }
        }
        public byte[] Body
        {
            get
            {
                return _body;
            }
            set
            {
                _body = value;
            }
        }
        #endregion

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public static Packet FromJson(string data)
        {
            return JsonConvert.DeserializeObject<Packet>(data);
        }
    }
}
