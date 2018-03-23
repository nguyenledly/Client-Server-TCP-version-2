using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipe = new IPEndPoint(IPAddress.Any, 1234);
            TcpListener server = new TcpListener(ipe);
            server.Start();
            TcpClient client = server.AcceptTcpClient();
            NetworkStream ns = client.GetStream();
            StreamWriter sw = new StreamWriter(ns);
            sw.WriteLine("Hello Client!");
            sw.Flush();
            StreamReader sr = new StreamReader(ns);
            string s = sr.ReadLine();
            Console.WriteLine(s);
            client.Close();
            server.Stop();
        }
    }
}
