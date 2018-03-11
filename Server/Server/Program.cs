using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace ChatRoom
{
    //class Program
    //{
    //    private const int port = 8888;

    //    //MAIN
    //    static void Main(string[] args)
    //    {
    //        Server s = new Server();
    //        s.initialize(port);
    //    }
    //}

    //class Server
    //{
    //    private static int numThreads = 0;
    //    private byte[] readBuffer = new byte[1024];
    //    private Socket server;
    //    private Socket client;

    //    public Server()
    //    {
    //        server = new Socket(SocketType.Stream, ProtocolType.Tcp);
    //    }

    //    public void initialize(int port)
    //    {
    //        IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
    //        server.Bind(endpoint);
    //        Console.Title = "Server";
    //        Console.WriteLine("initialize");
    //        while (true)
    //        {
    //            server.Listen(1);
    //            client = server.Accept();
    //            Thread randomClient = new Thread(readFromSocket);
    //            randomClient.Name = "Thread #" + numThreads;
    //            randomClient.Start();
    //            ++numThreads;
    //        }
    //    }

    //    public void readFromSocket()
    //    {
    //        while (true)
    //        {
    //            try
    //            {
    //                int amount = client.Receive(readBuffer);
    //                if (amount > 0)
    //                {

    //                    //string toPrint = byteToString(readBuffer);
    //                    string toPrint = Encoding.UTF8.GetString(readBuffer);
    //                    //toPrint = toPrint.Replace("\0", string.Empty);
    //                    Console.WriteLine(toPrint);
    //                    Array.Clear(readBuffer, 0, readBuffer.Length);
    //                }
    //                else
    //                {
    //                    continue;
    //                }
    //            }
    //            catch (SocketException e)
    //            {
    //                Console.WriteLine("Reading was unsuccessful");
    //                Console.WriteLine(e.Message);
    //                Console.Read();
    //            }
    //        }
    //    }
    //}

    //--------------------------------------------------------------------------------------------------------------

    //class Program
    //{
    //    private const int port = 8888;

    //    //MAIN
    //    static void Main(string[] args)
    //    {
    //        //string hostName = Dns.GetHostName();
    //        //Console.WriteLine("本機名稱=" + hostName);

    //        //IPAddress[] ipa = Dns.GetHostAddresses(hostName);
    //        //Console.WriteLine("本機IP=" + ipa[0].ToString());
    //        //IPAddress ipAddress = ipa[0];

    //        IPAddress ipAddress = IPAddress.Any;

    //        //建立本機端的IPEndPoint物件
    //        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

    //        new Server(ipEndPoint);
    //    }
    //}

    ///// <summary>
    ///// Server class
    ///// </summary>
    //public class Server
    //{
    //    private Dictionary<string, HandleClient> clients = new Dictionary<string, HandleClient>();

    //    public Server(IPEndPoint ipEndPoint)
    //    {
    //        //取得本機名稱
    //        //string hostName = Dns.GetHostName();
    //        //Console.WriteLine("本機名稱=" + hostName);

    //        ////取得本機IP
    //        //IPAddress[] ipa = Dns.GetHostAddresses(hostName);
    //        //Console.WriteLine("本機IP=" + ipa[0].ToString());

    //        ////建立本機端的IPEndPoint物件
    //        //IPEndPoint ipe = new IPEndPoint(ipa[0], 1234);

    //        //建立TcpListener物件
    //        TcpListener tcpListener = new TcpListener(ipEndPoint);

    //        //開始監聽port
    //        tcpListener.Start();
    //        Console.WriteLine("等待客戶端連線中... \n");


    //        int numberOfClients = 0;
    //        while (true)
    //        {
    //            try
    //            {
    //                //建立與客戶端的連線
    //                TcpClient tcpClient = tcpListener.AcceptTcpClient();

    //                if (tcpClient.Connected)
    //                {
    //                    HandleClient handleClient = new HandleClient(tcpClient);
    //                    clients.Add(tcpClient.Client.RemoteEndPoint.ToString(), handleClient);
    //                    Thread myThread = new Thread(handleClient.Communicate);
    //                    ++numberOfClients;
    //                    myThread.IsBackground = true;
    //                    myThread.Start();
    //                    myThread.Name = tcpClient.Client.RemoteEndPoint.ToString();

    //                    Console.WriteLine("連線成功!");
    //                }
    //                else
    //                {
    //                    Console.WriteLine("連線失敗!");
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                Console.WriteLine(ex.Message);
    //                Console.Read();
    //            }
    //        }
    //    }

    //    public void Broadcast(byte[] message)
    //    {
    //        foreach (HandleClient handleClient in clients.Values)
    //        {
    //            //handleClient.Communicate
    //        }
    //    }
    //}

    //public class HandleClient
    //{
    //    /// <summary>
    //    /// private attribute of HandleClient class
    //    /// </summary>
    //    private TcpClient TcpClient;

    //    CommunicationBase Communication;

    //    /// <summary>
    //    /// Constructor
    //    /// </summary>
    //    /// <param name="tcpClient">傳入TcpClient參數</param>
    //    public HandleClient(TcpClient tcpClient)
    //    {
    //        this.TcpClient = tcpClient;
    //        Communication = new CommunicationBase();
    //    }

    //    /// <summary>
    //    /// Communicate
    //    /// </summary>
    //    public void Communicate()
    //    {
    //        try
    //        {
    //            string receiveMessage = Communication.ReceiveMessage(this.TcpClient);
    //            Console.WriteLine(receiveMessage + "\n");
    //            string sendMessage = "主機回傳測試";

    //            Communication.SendMessage(Encoding.Default.GetBytes(sendMessage), this.TcpClient);
    //        }
    //        catch
    //        {
    //            Console.WriteLine("客戶端強制關閉連線!");
    //            this.TcpClient.Close();
    //            Console.Read();
    //        }
    //    }
    //}

    ///// <summary>
    ///// CommunicationBase給客戶端和主機端共用，可傳送接收訊息
    ///// </summary>
    //public class CommunicationBase
    //{
    //    /// <summary>
    //    /// 傳送訊息
    //    /// </summary>
    //    /// <param name="message">要傳送的訊息</param>
    //    /// <param name="tcpClient">TcpClient</param>
    //    public void SendMessage(byte[] message, TcpClient tcpClient)
    //    {
    //        NetworkStream ns = tcpClient.GetStream();
    //        if (ns.CanWrite)
    //        {
    //            ns.Write(message, 0, message.Length);
    //        }
    //    }

    //    /// <summary>
    //    /// 接收訊息
    //    /// </summary>
    //    /// <param name="tcpClient">TcpClient</param>
    //    /// <returns>接收到的訊息</returns>
    //    public string ReceiveMessage(TcpClient tcpClient)
    //    {
    //        string receiveMessage = string.Empty;
    //        byte[] receiveBytes = new byte[tcpClient.ReceiveBufferSize];
    //        int numberOfBytesRead = 0;
    //        NetworkStream ns = tcpClient.GetStream();

    //        if (ns.CanRead)
    //        {
    //            do
    //            {
    //                numberOfBytesRead = ns.Read(receiveBytes, 0, tcpClient.ReceiveBufferSize);
    //                receiveMessage = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
    //            }
    //            while (ns.DataAvailable);
    //        }
    //        return receiveMessage;
    //    }
    //}

    //--------------------------------------------------------------------------------------------------------------

    //資料來源 http://csharp.net-informations.com/communications/csharp-multi-threaded-server-socket.htm

    //class Program
    //{
    //    private const int port = 8888;

    //    static void Main(string[] args)
    //    {
    //        IPAddress ipAddress = IPAddress.Any;

    //        //建立本機端的IPEndPoint物件
    //        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

    //        new Server(ipEndPoint);
    //    }
    //}

    //public class Server
    //{
    //    private List<handleClinet> Clients = new List<handleClinet>();

    //    public Server(IPEndPoint ipEndPoint)
    //    {
    //        TcpListener serverSocket = new TcpListener(ipEndPoint);

    //        TcpClient clientSocket = default(TcpClient);

    //        int counter = 0;

    //        serverSocket.Start();

    //        Console.WriteLine(" >> " + "Server Started");

    //        counter = 0;

    //        while (true)
    //        {
    //            ++counter;

    //            clientSocket = serverSocket.AcceptTcpClient();

    //            int clientID = counter;

    //            Console.WriteLine(" >> " + "Client No:" + clientID + " started!");

    //            handleClinet client = new handleClinet();
    //            Clients.Add(client);
    //            client.StartClient(clientSocket, BoardCastMessageToCliet);
    //        }

    //        clientSocket.Close();

    //        serverSocket.Stop();

    //        Console.WriteLine(" >> " + "exit");

    //        Console.ReadLine();
    //    }

    //    private void BoardCastMessageToCliet(byte[] message)
    //    {
    //        int count = Clients.Count;
    //        for (int i = 0; i < count; ++i)
    //        {
    //            Clients[i].Send(message);
    //        }
    //    }
    //}

    ////Class to handle each client request separatly

    //public class handleClinet
    //{
    //    private TcpClient TcpClient;

    //    private Action<byte[]> ReceiveMessage;

    //    public void StartClient(TcpClient tcpClient, Action<byte[]> receiveMessage)
    //    {
    //        this.TcpClient = tcpClient;

    //        this.ReceiveMessage = receiveMessage;

    //        Thread thread = new Thread(DoChat);
    //        thread.Start();
    //    }

    //    private void DoChat()
    //    {
    //        //int requestCount = 0;

    //        byte[] bytesFrom = new byte[10025];

    //        //string dataFromClient = null;

    //        //byte[] sendBytes = null;

    //        //string serverResponse = null;

    //        //string rCount = null;

    //        //requestCount = 0;

    //        while (true)
    //        {
    //            try
    //            {
    //                //++requestCount;

    //                NetworkStream networkStream = TcpClient.GetStream();

    //                networkStream.Read(bytesFrom, 0, TcpClient.ReceiveBufferSize);

    //                //dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);

    //                //rCount = Convert.ToString(requestCount);

    //                //sendBytes = Encoding.ASCII.GetBytes(serverResponse);

    //                //networkStream.Write(sendBytes, 0, sendBytes.Length);

    //                networkStream.Flush();

    //                if (ReceiveMessage != null)
    //                {
    //                    ReceiveMessage(bytesFrom);
    //                }
    //            }

    //            catch (Exception ex)
    //            {
    //                TcpClient.Close();

    //                //Console.WriteLine(ex.ToString());
    //                //Console.WriteLine(" >> " + "Server to clinet(" + ClientID + ") closed...");

    //                break;
    //            }
    //        }
    //    }

    //    public void Send(byte[] message)
    //    {
    //        TcpClient.Client.Send(message, message.Length);
    //    }
    //}

    //----------------------------------------------------------------------------

    class Program
    {
        //接收連線的Port(通訊埠)
        private const int port = 8888;

        static void Main(string[] args)
        {
            IPAddress ipAddress = IPAddress.Any;

            //建立本機端的IPEndPoint物件
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

            new ChatServer(ipEndPoint);
        }
    }

    //聊天室Server
    class ChatServer
    {
        //接收連線的Socket
        private Socket Socket;

        //聊天室使用者清單
        private List<User> Users = new List<User>();

        public ChatServer(IPEndPoint ipEndPoint)
        {
            //設定Socket
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //綁住端口
            Socket.Bind(ipEndPoint);
            //開始接新連線
            Socket.Listen(1000);

            Socket.BeginAccept(NewConnection, null);
        }

        private void NewConnection(IAsyncResult result)
        {
            //新連線取得，並結束接收新連線
            Socket newSock = Socket.EndAccept(result);
            //開始接收新連線
            Socket.BeginAccept(NewConnection, null);
            //由新連線建立新使用者
            User X = new User(newSock);
            //加入到使用者清單
            Users.Add(X);
            //開始接受使用者傳送的資料
            X.Socket.BeginReceive(X.Data, 0, 1024, SocketFlags.None, EndRead, X);
        }

        private void EndRead(IAsyncResult result)
        {
            //收到資料，分析使用者
            User X = (User)result.AsyncState;
            //取得接受的資料量，並停止接收資料
            int messageLength = X.Socket.EndReceive(result);
            if (messageLength > 0)
            {//有資料
                string message = Encoding.UTF8.GetString(X.Data, 0, messageLength);//將位元資料轉成字串
                //Frm.ShowText("伺服器::"+MSG);
                //廣播訊息
                foreach (User Q in Users)
                {
                    Send(Q.Socket, message);
                }
            }
            else
            {//對方結束連線

                //移除離線使用者
                Users.Remove(X);

                //廣播訊息
                foreach (User Q in Users)
                {
                    Send(Q.Socket, "某人結束連線!");
                }
            }
            //繼續接收資料
            X.Socket.BeginReceive(X.Data, 0, X.Data.Length, SocketFlags.None, EndRead, X);
        }

        //傳送資料
        private void Send(Socket Sock, String msg)
        {
            Byte[] Buffer = Encoding.UTF8.GetBytes(msg);//轉成位元資料
            Sock.BeginSend(Buffer, 0, Buffer.Length, SocketFlags.None, EndSend, Sock);//開始傳送
        }

        private void EndSend(IAsyncResult Result)
        {
            //傳送完畢，停止傳送
            ((Socket)Result.AsyncState).EndSend(Result);
        }
    }

    //使用者類別
    class User
    {
        //使用者Socket
        public Socket Socket { get; private set; }
        //資料緩衝區
        public Byte[] Data = new Byte[1024];
        //建構子
        public User(Socket s)
        {
            Socket = s;
        }
    }
}