using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Network
{
    public class Client
    {
        /// <summary>
        /// 連線至主機
        /// </summary>
        //public void ConnectToServer()
        //{
        ////預設主機IP
        //string hostIP = "192.168.0.216";

        ////先建立IPAddress物件,IP為欲連線主機之IP
        //IPAddress ipa = IPAddress.Parse(hostIP);

        ////建立IPEndPoint
        //IPEndPoint ipe = new IPEndPoint(ipa, 1234);

        private TcpClient TcpClient;

        private CommunicationBase Communication;

        public bool ConnectToServer(string ip, int port)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);

            return ConnectToServer(ipEndPoint);
        }

        public bool ConnectToServer(IPEndPoint ipEndPoint)
        {
            //開始連線
            try
            {
                //先建立一個TcpClient;
                TcpClient = new TcpClient();

                UnityEngine.Debug.Log("主機IP=" + ipEndPoint.Address.ToString());
                UnityEngine.Debug.Log("連線至主機中...\n");
                TcpClient.Connect(ipEndPoint);
                if (TcpClient.Connected)
                {
                    Communication = new CommunicationBase();

                        UnityEngine.Debug.Log("連線成功!");
                    //    CommunicationBase cb = new CommunicationBase();
                    //    string sendMessage = "這是客戶端傳給主機的訊息";
                    //    cb.SendMessage(sendMessage, TcpClient);
                    //    UnityEngine.Debug.Log(cb.ReceiveMessage(TcpClient));
                }
                //else
                //{
                //    UnityEngine.Debug.Log("連線失敗!");
                //}

                return TcpClient.Connected;
            }
            catch (Exception ex)
            {
                TcpClient.Close();
                UnityEngine.Debug.LogError(ex.Message);
            }

            return false;
        }

        public void SendMessageToServer(string message)
        {
            SendMessageToServer(Encoding.Default.GetBytes(message));
        }

        public void SendMessageToServer(byte[] message)
        {
            if (TcpClient.Connected 
                && message != null
                && message.Length > 0
                )
            {
                UnityEngine.Debug.Log(message.Length);
                Communication.SendMessage(message, TcpClient);
            }
        }
    }

    /// <summary>
    /// CommunicationBase給客戶端和主機端共用，可傳送接收訊息
    /// </summary>
    public class CommunicationBase
    {
        public void SendMessage(string message, TcpClient tcpClient)
        {
            SendMessage(Encoding.Default.GetBytes(message), tcpClient);
        }

        /// <summary>
        /// 傳送訊息
        /// </summary>
        /// <param name="message">要傳送的訊息</param>
        /// <param name="tcpClient">TcpClient</param>
        public void SendMessage(byte[] message, TcpClient tcpClient)
        {
            NetworkStream ns = tcpClient.GetStream();
            if (ns.CanWrite)
            {
                ns.Write(message, 0, message.Length);
            }
        }

        /// <summary>
        /// 接收訊息
        /// </summary>
        /// <param name="tcpClient">TcpClient</param>
        /// <returns>接收到的訊息</returns>
        public string ReceiveMessage(TcpClient tcpClient)
        {
            string receiveMessage = string.Empty;
            byte[] receiveBytes = new byte[tcpClient.ReceiveBufferSize];
            int numberOfBytesRead = 0;
            NetworkStream ns = tcpClient.GetStream();

            if (ns.CanRead)
            {
                do
                {
                    numberOfBytesRead = ns.Read(receiveBytes, 0, tcpClient.ReceiveBufferSize);
                    receiveMessage = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                }
                while (ns.DataAvailable);
            }
            return receiveMessage;
        }
    }


    public partial class Form1

    {

        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        NetworkStream serverStream;

        private void button1_Click(object sender, EventArgs e)
        {

            NetworkStream serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Message from Client$");

            serverStream.Write(outStream, 0, outStream.Length);

            serverStream.Flush();

            byte[] inStream = new byte[10025];

            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);

            string returndata = System.Text.Encoding.ASCII.GetString(inStream);

            //msg("Data from Server : " + returndata);

        }

    }
}