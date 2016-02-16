/*
 * Created by SharpDevelop.
 * User: Rudy
 * Date: 15-2-2016
 * Time: 23:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private TcpClient client;
		private NetworkStream ns;
		private Byte[] buf = new byte[300];
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				var port = 8888;
				client = new TcpClient(txtHostname.Text, port);
				client.ReceiveTimeout = 1;
				ns = client.GetStream();
				ns.BeginRead(buf, 0, 1, HandleRead, null);
				if (client.Connected) ShowMessage("Client is succesfull connected!");
			}
			catch (Exception ex)
			{
				txtMessages.AppendText("\r\n " + ex.Message);
			}
		}

		private void ShowMessage(string msg)
		{
			this.txtMessages.TextChanged -= new System.EventHandler(this.txtMessages_TextChanged);
			this.txtMessages.Text = msg;
			this.txtMessages.TextChanged += new System.EventHandler(this.txtMessages_TextChanged);
		}

		private void HandleRead(IAsyncResult ar)
		{
			Console.WriteLine("asynchResult {0}", ar);
		}

		private void btnDisconnect_Click(object sender, EventArgs e)
		{
			client.Close();
		}

		private void txtMessages_TextChanged(object sender, EventArgs e)
		{
			if (client.Connected)
			{
				var t = (sender as Control).Text;
				char c = t[t.Length - 1];
				var b = new byte[5]; b[0] = (byte)c;
				ns.Write(b, 0, 1);
			}
		}
	}
	static class Helper
	{
		static byte[] GetBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		static string GetString(byte[] bytes)
		{
			char[] chars = new char[bytes.Length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
			return new string(chars);
		}
	}
}
