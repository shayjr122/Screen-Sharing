using Client.ScreenSetting;
using Client.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Media;

namespace Client.Traffic
{
    class TrafficManager
    {
        private Client.User.Client _client;
        private System.Windows.Controls.Image _screen;
        private Thread _shareScreen;
        private bool _isShareAlive;

     
        public TrafficManager(string server, int port, System.Windows.Controls.Image image)
        {
            Player = image;
            Client = new Client.User.Client(server, port);
            IsShareAlive = false;

            
        }
        public void ShareScreen(int sessionID, string userName, MessageType messageType, bool client = true)// Session id
        {
            switch (messageType)
            {
                case MessageType.SHARE_SCREEN: 
                        IsShareAlive = true;
                        if (ThreadShareScreen != null)
                        {
                            ThreadShareScreen.Abort();
                            ThreadShareScreen = null;
                        }
                        if (client)
                        {

                            ThreadShareScreen = new Thread(() => ShareScreen(sessionID, userName));
                            ThreadShareScreen.Start();
                        }
                        else
                        {
                            ThreadShareScreen = new Thread(GetScreen);
                            ThreadShareScreen.Start();
                        }

                        break;
                case MessageType.CHAT:
                    break;
                case MessageType.ROOM_CHAT:
                    break;
            }
        }

        #region Properties
        public Client.User.Client Client
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
        public System.Windows.Controls.Image Player
        {
            get
            {
                return _screen;
            }
            set
            {
                _screen = value;
            }
        }
        public Thread ThreadShareScreen
        {
            get
            {
                return _shareScreen;
            }
            set
            {
                _shareScreen = value;
            }
        }
        public bool IsShareAlive
        {
            get
            {
                return _isShareAlive;
            }
            set
            {
                _isShareAlive = value;
            }
        }
        #endregion


        public void ShareScreen(int sessionID,string userName)
        {
            JpegBitmapEncoder encoder;
            while (true)
            {
                byte[] data;
                BitmapImage shot = BitToImage(Screen.Shot());
                encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(shot));
                MemoryStream ms = new MemoryStream();
                encoder.Save(ms);
                data = ms.ToArray();
                Packet packet = new Packet(sessionID,userName,MessageType.SHARE_SCREEN, data);
                Sender(packet);
            }

        }

        public void GetScreen()
        {
            while (true)
            {
                byte[] data = Receiver().Body;
                if (data != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(data, 0, data.Length);
                    ms.Position = 0;
                    BitmapImage shot = new BitmapImage();
                    shot.BeginInit();
                    shot.StreamSource = ms;
                    shot.EndInit();
                    shot.Freeze();

                    try
                    {
                        Player.Dispatcher.Invoke((Action)(() =>
                        {
                            Player.Source = shot;
                        }));

                    }
                    catch
                    {
                        throw new Exception("Load pic Error");
                    }
                }
            }
        }

        private BitmapImage BitToImage(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();
                return bitmapimage;
            }
        }

        private void Sender(Packet packet)
        {
            Client.Writer.Write(packet);
        }

        private Packet Receiver()
        {
            return Client.Reader.Read();
        }





    }
}
