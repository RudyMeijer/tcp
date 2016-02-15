/*
 * Created by SharpDevelop.
 * User: Rudy
 * Date: 15-2-2016
 * Time: 18:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
	class Program
	{
		public static void Main(string[] args)
		{	
			Console.WriteLine("Server Start listening on port 8888.");
			var server = new TcpListener(8888);
			server.Start();
			
			var n = 0;
			Console.Write("Press any key to exit . . . ");
			while (!Console.KeyAvailable) 
			{
				var client = server.AcceptTcpClient();
				var t = new Thread(new ThreadStart(new HandleClient(client, ++n).Execute));
				t.Start();
			}
			Console.WriteLine("Server stopped");
			Console.ReadKey(true);
		}
		public class HandleClient
		{
			TcpClient client;
			int n;
			public HandleClient(TcpClient client, int n)
			{
				this.n = n;
				this.client = client;
			}

			public void Execute()
			{
				Console.WriteLine("Client {0} started.", n);
				Console.ReadKey();
				Console.WriteLine("Client {0} stopped.", n);
			}
		}
	}
}