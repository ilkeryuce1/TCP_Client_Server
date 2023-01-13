using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Server
{
    static void Main(string[] args)
    {
        int port = 3000;
        IPAddress ip = IPAddress.Parse("127.0.0.1");

        TcpListener server = new TcpListener(ip, port);
        server.Start();

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();

            while (true)
            {
                NetworkStream ns = client.GetStream();
                byte[] receivedBytes = new byte[1024];
                int byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);

                string data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
                Console.WriteLine("Client Message: " + data);


                string response = data;
                if (response=="hello")
                {
                    response= "Server Message" + " " + response + " " + DateTime.Now.ToString();
                   

                }
                byte[] sendBytes = Encoding.ASCII.GetBytes(response);
                ns.Write(sendBytes, 0, sendBytes.Length);


            }

            //client.Close();
            //Console.ReadLine();
        }
    }
}
