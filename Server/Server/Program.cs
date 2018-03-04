using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        private const int port = 8888;

        //MAIN
        static void Main(string[] args)
        {
            Server s = new Server();
            s.initialize(port);
        }
    }

    class Server
    {
        private static int numThreads = 0;
        private byte[] readBuffer = new byte[1024];
        private Socket server;
        private Socket client;

        public Server()
        {
            server = new Socket(SocketType.Stream, ProtocolType.Tcp);
        }

        public void initialize(int port)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, port);
            server.Bind(endpoint);
            Console.Title = "Server";
            Console.WriteLine("initialize");
            while (true)
            {
                server.Listen(1);
                client = server.Accept();
                Thread randomClient = new Thread(readFromSocket);
                randomClient.Name = "Thread #" + numThreads;
                randomClient.Start();
                ++numThreads;
            }
        }

        public void readFromSocket()
        {
            while (true)
            {
                try
                {
                    int amount = client.Receive(readBuffer);
                    if (amount > 0)
                    {

                        //string toPrint = byteToString(readBuffer);
                        string toPrint = Encoding.UTF8.GetString(readBuffer);
                        //toPrint = toPrint.Replace("\0", string.Empty);
                        Console.WriteLine(toPrint);
                        Array.Clear(readBuffer, 0, readBuffer.Length);
                    }
                    else
                    {
                        continue;
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("Reading was unsuccessful");
                    Console.WriteLine(e.Message);
                    Console.Read();
                }
            }
        }
    }
}