namespace SuperCMD
{
	partial class frmWait
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lbl = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbl
			// 
			this.lbl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbl.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.lbl.Location = new System.Drawing.Point(0, 0);
			this.lbl.Name = "lbl";
			this.lbl.Size = new System.Drawing.Size(298, 148);
			this.lbl.TabIndex = 0;
			this.lbl.Text = "Starting TrustedInstaller service...\r\n\r\nPlease wait...";
			this.lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmWait
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.ClientSize = new System.Drawing.Size(298, 148);
			this.ControlBox = false;
			this.Controls.Add(this.lbl);
			this.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmWait";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWait_FormClosing);
			this.Load += new System.EventHandler(this.frmWait_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lbl;
	}
}