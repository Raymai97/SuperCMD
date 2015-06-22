using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SuperCMD
{
	public partial class frmWait : Form
	{
		bool needed()
		{
			return (System.Diagnostics.Process
				.GetProcessesByName("TrustedInstaller").Length == 0);
		}

		public void ShowIfNeeded()
		{
			if (needed())
			{
				this.Show();
			}
		}

		public void ShowDialogIfNeeded(Form owner)
		{
			if (needed())
			{
				this.ShowDialog(owner);
			}
		}

		public frmWait()
		{
			InitializeComponent();
		}

		private void frmWait_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing) e.Cancel = true;
		}

		private void frmWait_Load(object sender, EventArgs e)
		{
			if (this.Owner == null)
			{
				this.CenterToScreen();
			}
			else
			{
				this.CenterToParent();
			}
			lbl.Text = MUI.GetText("Common.StartingTI");
		}

	}
}
