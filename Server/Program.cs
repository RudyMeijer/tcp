/*
 * Created by SharpDevelop.
 * User: Rudy
 * Date: 15-2-2016
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
	class Program
	{
		public static void Main(string[] args)
		{
			var port = 8888;
			var server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
			server.Server.ReceiveTimeout = 100;
			server.Start();

			var n = 0;
			Console.Write("Server start listening on port 8888 . . .\r\n");
			while (true)
			{
				var client = server.AcceptTcpClient();
				var t = new Thread(new ThreadStart(new HandleClient(client, ++n).Execute));
				t.Start();
			}
			//Console.WriteLine("Server stopped");
			//Console.ReadKey(true);
		}
		public class HandleClient
		{
			readonly TcpClient client;
			int n;
			private NetworkStream ns;
			private Byte[] buf = new byte[300];
			public HandleClient(TcpClient client, int n)
			{
				this.n = n;
				this.client = client;
				//client.ReceiveTimeout = 1;
				ns = client.GetStream();
				//ns.BeginRead(buf, 0, 1, HandleRead, null);
			}

			//private void HandleRead(IAsyncResult ar)
			//{
			//	Console.Write((char)buf[0]);

			//	if (ar.IsCompleted)	ns.BeginRead(buf, 0, 1, HandleRead, null);
			//}

			public void Execute()
			{
				Console.WriteLine("Client {0} started.", n);
				try
				{
					while (client.Connected)
					{
						// Write Server data to client.
						//
						if (Console.KeyAvailable) 
						{
							var c = Console.ReadKey().Key;
							var b = new byte[5]; b[0] = (byte)c;
							ns.Write(b, 0, 1);
						}
						// Show client data on Server console.
						//
						if (ns.DataAvailable) 
						{
							Console.Write((char)ns.ReadByte());
						}
					}
					Console.WriteLine("Client {0} stopped.", n);

				}
				catch (Exception ex) { Console.WriteLine(ex.Message); }
			}
		}
	}
}