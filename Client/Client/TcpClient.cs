using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class TcpClient
    {
        string _ingener;
        string _otdel;
        string _miniline;
        string _allline;
        string _ip;
        public string ansver;
        string putch = @"D:\Project\Client\Base\log.txt";

        public TcpClient(string less1, string less2, string less3, string less4, string ip)
        {
            _ingener = less1 + "|";
            _otdel = less2 + "|";
            _miniline = less3 + "|";
            _allline = less4 + "|";
            _ip = ip;

        }
        public void StartClient()
        {
            string str = _ingener + _otdel + _miniline + _allline;
            

            // Data buffer for incoming data.
            byte[] bytes = new byte[1024];

            // Connect to a remote device.
            try
            {

                IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName()); //Для теста айпи 
                IPAddress ipAddress1 = ipHostInfo.AddressList[0];

                IPAddress ipAddress = IPAddress.Parse(_ip);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 12345);

                // Create a TCP/IP  socket.
                Socket sender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    sender.Connect(remoteEP);

                    Console.WriteLine("Socket connected to {0}",
                      sender.RemoteEndPoint.ToString());

                    ansver = "Ok";
                    // ansver = "Данные отправлены. Можете закрыть программу"
                    // Encode the data string into a byte array.
                    byte[] msg = Encoding.UTF8.GetBytes(str);//"This is a test<EOF>");

                    // Send the data through the socket.
                    int bytesSent = sender.Send(msg);

                    // Receive the response from the remote device.
                    int bytesRec = sender.Receive(bytes);
                    Console.WriteLine("Echoed test = {0}",
                        Encoding.UTF8.GetString(bytes, 0, bytesRec));

                    // Release the socket.
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();

                    

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                    ansver = "ArgumentNullException : {0}" + ane.ToString();
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                    ansver = "SocketException : {0}" + se.ToString();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                    ansver = "Unexpected exception : {0}" + e.ToString();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                ansver = e.ToString();
            }

        }
        public void WriteInLogFile(string less1, string less2, string less3, string less4)
        {
            string log_putch = putch;

            StreamWriter log = new StreamWriter(log_putch, true);
           
            log.WriteLine();
            log.WriteLine(less1 + "|");
            log.WriteLine(less2 + "|");
            log.WriteLine(less3 + "|");
            log.WriteLine(less4 + "|");
            log.Write("*");
            log.Close();
        }
    }
}
