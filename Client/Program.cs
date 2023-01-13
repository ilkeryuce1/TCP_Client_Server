using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main(string[] args)
    {
        //    //    //        //Client ve server olacak bunlar bırbırlerı ıle tcp protokolunden konusacak 
        //    //    //        //clıent servera hello mesajını gonderecek 
        //    //    //        //server aldıgı bu mesajı konsala yazdıracak 
        //    //    //        //sonrasında bu mesajın sonuna server işlem zamanını ekleyecek ve cliente geri gönderecek 
        //    //    //        //Client bu mesajı alıp konsola yazacak 
        //    //    //        //<ismail.turkmenoglu@sanlab.net>


        TcpClient client = new TcpClient("127.0.0.1", 3000);
        //TCP sunucusundan baglantı olusturmak ıcın kullandık.

        NetworkStream ns = client.GetStream();
        //Ağ bağlantısı züerinde veri göndermekalmak içinkullanılır.

        while (true) //Her tamamlanan 
        {
            Console.Write("Enter Client message: ");//Mesajı kullanıcıdan istedik
            string message = Console.ReadLine();//Mesajı Okuttuk
            byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            //The Encoding.ASCII.GetBytes(message) kod parçacığı, verilen mesajı ASCII karakter kodlamasına göre byte dizisine dönüştürür. ASCII, American Standard Code for Information Interchange, veri alışverişinde kullanılan standart bir karakter kodlamasıdır. Bu kodlama, 8 bitlik veri kullanarak 128 farklı karakteri temsil edebilir.


            ns.Write(sendBytes, 0, sendBytes.Length);
            //gönderilecek veri "sendBytes" dizisi başlangıç pozisyonu 0 ve gönderilecek bayt sayısı "sendBytes" dizisinin uzunluğudur. 

            byte[] receivedBytes = new byte[1024];
            //Ağ üzerinden alınan verileri saklamak için kullanılır

            int byte_count = ns.Read(receivedBytes, 0, receivedBytes.Length);
            //ağdan gelen veriyi okurkenki bayt sayısı buraya atanır.

            string data = Encoding.ASCII.GetString(receivedBytes, 0, byte_count);
            //receivedBytes dizisi bir dizeye dönüştürülür
           
            
                Console.WriteLine(data);//Ekrana yazdırılır
           

        }
        //client.Close();
        //Console.ReadLine();
    }
}