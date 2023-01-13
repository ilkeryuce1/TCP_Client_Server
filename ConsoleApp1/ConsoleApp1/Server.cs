using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SuperSimpleTcp;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Security;

namespace ConsoleApp1
{

    class Program
    {
        TcpListener deneme2;
        static void Main(string[] args)
        {
            string test = "";

            //    //    //        //Client ve server olacak bunlar bırbırlerı ıle tcp protokolunden konusacak 
            //    //    //        //clıent servera hello mesajını gonderecek 
            //    //    //        //server aldıgı bu mesajı konsala yazdıracak 
            //    //    //        //sonrasında bu mesajın sonuna server işlem zamanını ekleyecek ve cliente geri gönderecek 
            //    //    //        //Client bu mesajı alıp konsola yazacak 
            //    //    //        //<ismail.turkmenoglu@sanlab.net>



            // Sunucu dinlemeye başlar telnet komutu ile baglanildiğini öğrendim
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 3000);
            server.Start();
            Client1(test);//Örneklerdeki Şekilleri uyarlayamadığım için metot şeklinde tanımlayıp çağırmayı denedim
                          // İstemci bağlandığında
            TcpClient client = server.AcceptTcpClient();

            // Veri alınır
            byte[] data = new byte[256];

            NetworkStream stream = client.GetStream();
            int i;
            while ((i = stream.Read(data, 0, data.Length)) != 0)
            {
                // Veri ekrana yazdırılır
                Console.WriteLine(Encoding.ASCII.GetString(data, 0, i));
                test = (Encoding.ASCII.GetString(data, 0, i) + " " + System.DateTime.Now).ToString();
            }


            Client1(test);

            // Bağlantı kapat
            client.Close();
            server.Stop();
            Console.ReadLine();

        }
        static void Client1(string test)
        {

            // Sunucuya bağlan
            TcpClient client = new TcpClient("127.0.0.1", 3000);
            NetworkStream stream = client.GetStream();
            // Veri gönder
            if (test == "")
            {
                string message = "Hello!";
                byte[] data = Encoding.ASCII.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
            else
            {
                Console.WriteLine(test);
            }




            // Bağlantı kapat
            client.Close();


        }








        ////Sunucu dinlemeye başlar
        //TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 3000);
        //    server.Start();
        //  /*  Client1();*///Örneklerdeki Şekilde  Başlatamadığım için metot şeklinde tanımlayıp çağırma kararı aldım.
        //              // İstemci bağlandığında
        //    TcpClient client = server.AcceptTcpClient();
        //    string deneme= Console.ReadLine();

        //    // Veri alınır
        //    byte[] data = new byte[256];

        //    NetworkStream stream = client.GetStream();
        //    int i; string test = "";
        //    while ((i = stream.Read(data, 0, data.Length)) != 0)
        //    {
        //        // Veri ekrana yazdırılır
        //        Console.WriteLine(Encoding.ASCII.GetString(data, 0, i));
        //        test = (Encoding.ASCII.GetString(data, 0, i) + " " + System.DateTime.Now).ToString();
        //    }



        //    // Bağlantı kapatılır
        //    client.Close();
        //    server.Stop();
        //}
    }
}
