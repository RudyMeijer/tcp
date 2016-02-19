/*
 * Created by SharpDevelop.
 * User: Rudy
 * Date: 15-2-2016
 * Time: 23:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Client
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			client.Dispose();
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnConnect = new System.Windows.Forms.Button();
			this.btnDisconnect = new System.Windows.Forms.Button();
			this.txtMessages = new System.Windows.Forms.TextBox();
			this.txtHostname = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(14, 3);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(75, 23);
			this.btnConnect.TabIndex = 2;
			this.btnConnect.Text = "Connect";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// btnDisconnect
			// 
			this.btnDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDisconnect.Location = new System.Drawing.Point(275, 3);
			this.btnDisconnect.Name = "btnDisconnect";
			this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
			this.btnDisconnect.TabIndex = 3;
			this.btnDisconnect.Text = "Disconnect";
			this.btnDisconnect.UseVisualStyleBackColor = true;
			this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
			// 
			// txtMessages
			// 
			this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtMessages.Location = new System.Drawing.Point(14, 31);
			this.txtMessages.Multiline = true;
			this.txtMessages.Name = "txtMessages";
			this.txtMessages.Size = new System.Drawing.Size(336, 163);
			this.txtMessages.TabIndex = 4;
			this.txtMessages.Text = "Please press Connect";
			this.txtMessages.TextChanged += new System.EventHandler(this.txtMessages_TextChanged);
			// 
			// txtHostname
			// 
			this.txtHostname.Location = new System.Drawing.Point(95, 5);
			this.txtHostname.Name = "txtHostname";
			this.txtHostname.Size = new System.Drawing.Size(63, 20);
			this.txtHostname.TabIndex = 5;
			this.txtHostname.Text = "localhost";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(362, 206);
			this.Controls.Add(this.txtHostname);
			this.Controls.Add(this.txtMessages);
			this.Controls.Add(this.btnDisconnect);
			this.Controls.Add(this.btnConnect);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "MainForm";
			this.Text = "Client";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.Button btnDisconnect;
		private System.Windows.Forms.TextBox txtMessages;
		private System.Windows.Forms.TextBox txtHostname;
	}
}
