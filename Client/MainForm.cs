﻿/*
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
using System.Threading;
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
		private SynchronizationContext syncContext;
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			syncContext = SynchronizationContext.Current; //in constrcutor
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			try
			{
				var port = 8888;
				client = new TcpClient(txtHostname.Text, port);
				if (client.Connected) ShowMessage("\r\n\nClient is succesfull connected!");
				client.ReceiveTimeout = 0;
				ns = client.GetStream();
				ns.BeginRead(buf, 0, 1, HandleRead, null);
			}
			catch (Exception ex)
			{
				ShowMessage("\r\n " + ex.Message);
			}
		}

		private void ShowMessage(string msg)
		{
			this.txtMessages.TextChanged -= new System.EventHandler(this.txtMessages_TextChanged);
			syncContext.Send(new SendOrPostCallback((s) => { this.txtMessages.AppendText(msg); }), null); 
			//this.txtMessages.Text = msg;
			this.txtMessages.TextChanged += new System.EventHandler(this.txtMessages_TextChanged);
		}

		public void HandleRead(IAsyncResult ar)
		{
			var s = Helper.GetString(buf,2);
			ShowMessage(s);
			ns.BeginRead(buf, 0, 1, HandleRead, null);
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
	public class Helper
	{
		public static byte[] GetBytes(string str)
		{
			byte[] bytes = new byte[str.Length * sizeof(char)];
			System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
			return bytes;
		}

		public static string GetString(byte[] bytes,int length)
		{
			char[] chars = new char[length / sizeof(char)];
			System.Buffer.BlockCopy(bytes, 0, chars, 0, length);
			return new string(chars);
		}
	}
}
