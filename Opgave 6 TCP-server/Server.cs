using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FanLibrary;
using Newtonsoft.Json;

namespace Opgave_6_TCP_server
{
    public class Server
    {
        private static int totaltConnectionNo = 0;

        public void Start()
        {
            int clientNo = 0;
            TcpClient connectionSocket;
            Thread.CurrentThread.Name = "Main";
            IPAddress localAddress = IPAddress.Any;
            TcpListener serverSocket = new TcpListener(IPAddress.Any, 4646);
            serverSocket.Start();
            TaskFactory taskFactory = new TaskFactory();
            while (true)
            {
                connectionSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine("server activated");
                clientNo++;
                totaltConnectionNo++;
                taskFactory.StartNew(() => DoClient(connectionSocket, clientNo));
            }

        }

        private void DoClient(TcpClient connection, int clientNo)
        {
            TcpListener server = null;
            try
            {
                //Int32 port = 4646;
                //IPAddress localAddress = IPAddress.Parse("127.0.0.1");
                //server = new TcpListener(localAddress, port);

                //server.Start();
                Byte[] bytes = new byte[256];
                string data = null;

                while (true)
                {
                    Console.WriteLine("Waiting for a connection... ");
                    //TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected");
                    data = null;
                    NetworkStream stream = connection.GetStream();
                    int i;

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Recived: {0}", data);
                        data = data.ToUpper();
                        //byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                        //stream.Write(msg, 0, msg.Length);
                        //Console.WriteLine("Sent: {0}", data);

                        string mystring = data.Replace("\r\n", string.Empty);

                        string[] mystringarry = mystring.Split(" ");

                        string stringinput = mystringarry[0];

                        switch (stringinput)
                        {
                            case "HENTALLE":

                                foreach (var fandata in FanList.fanDataList)
                                {
                                    string json = JsonConvert.SerializeObject(fandata);
                                    json = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                                    byte[] message = System.Text.Encoding.ASCII.GetBytes(fandata.ToString() + "\n");
                                    stream.Write(message, 0, message.Length);
                                    Console.WriteLine("Sent: {0}", fandata);
                                }

                                break;

                            case "HENT":

                                int id = int.Parse(mystringarry[1]);

                                foreach (var fandata in FanList.fanDataList)
                                {
                                    if (fandata.id == id)
                                    {
                                        string json = JsonConvert.SerializeObject(fandata);
                                        json = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                                        byte[] message = System.Text.Encoding.ASCII.GetBytes(fandata.ToString());
                                        stream.Write(message, 0, message.Length);
                                        Console.WriteLine("Sent: {0}", fandata);
                                    }

                                }

                                break;

                            // Spørg Henrik i morgen
                            case "GEM":
                                double temp = double.Parse(mystringarry[2]);
                                double fugt = double.Parse(mystringarry[3]);
                                FanOutPut addFanOutput = new FanOutPut(navn: mystringarry[1], temp: temp, fugt: fugt);
                                FanList.fanDataList.Add(addFanOutput);
                                break;

                                // Spørg Henrik i morgen

                        }

                    }

                    connection.Close();
                }
            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }

            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
        }
    }
}