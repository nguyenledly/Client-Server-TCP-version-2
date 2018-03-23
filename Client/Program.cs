using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);
            TcpClient client = new TcpClient();
            client.Connect(iep);
            NetworkStream ns = client.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            string s = sr.ReadLine();
            Console.WriteLine(s);
            sw.WriteLine("Hello Server!");
            sw.Flush();
            client.Close();
        }
    }
}
