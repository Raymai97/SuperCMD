using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SuperCMD
{
	public partial class frmConfig : Form
	{

		#region Movable form

		bool mDown;
		Point mPos, frmPos;

		private void frm_MouseDown(object sender, MouseEventArgs e)
		{
			mDown = true;
			mPos = MousePosition;
			frmPos = this.Location;
		}

		private void frm_MouseMove(object sender, MouseEventArgs e)
		{
			if (mDown)
			{
				Point mPos2 = MousePosition;
				this.Left = frmPos.X + (mPos2.X - mPos.X);
				this.Top = frmPos.Y + (mPos2.Y - mPos.Y);
			}
		}

		private void frm_MouseUp(object sender, MouseEventArgs e)
		{
			mDown = false;
		}

		#endregion

		string initialLangName = "";

		public frmConfig()
		{
			InitializeComponent();
			lblTitle.Text = Program.Title;
		}

		private void frmConfig_Load(object sender, EventArgs e)
		{
			chkBeClassic.Checked = Program.beClassic;
			chkBeDPIaware.Checked = Program.beDPIaware;
			chkRunAsSYSTEM.Checked = Program.ContextMenuIntegration.RunAsSYSTEM;
			chkRunAsSYSTEM_TI.Checked = Program.ContextMenuIntegration.RunAsSYSTEM_TI;
			initialLangName = MUI.GetCurrentLangName();
			MUI.RefreshLangList();
			cmbLang.Items.Clear();
			foreach (string DispName in MUI.GetLangDispNameList())
			{
				cmbLang.Items.Add(DispName);
			}
			int LangIndex = MUI.GetCurrentLangIndex();
			if (LangIndex == -1)
			{
				LangIndex = 0;
				Program.RevertFallbackLangFrom(initialLangName);
			}	
			cmbLang.SelectedIndex = LangIndex;
		}

		private void frmConfig_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.DialogResult != DialogResult.OK)
			{
				MUI.TrySetLangByName(initialLangName);
				MUI.RefreshFrmLang();
			}
		}
		private void lblTitle_DoubleClick(object sender, EventArgs e)
		{
			Program.OfferToggleDebug();
		}

		private void lnkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://raymai97.github.io/SuperCMD");
		}

		private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
		{
			MUI.TrySetLangByIndex(cmbLang.SelectedIndex);
			MUI.RefreshFrmLang();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			bool RestartRequired =
				(Program.beClassic != chkBeClassic.Checked) |
				(Program.beDPIaware != chkBeDPIaware.Checked);
			Program.beClassic = chkBeClassic.Checked;
			Program.beDPIaware = chkBeDPIaware.Checked;
			Program.ContextMenuIntegration.RunAsSYSTEM = chkRunAsSYSTEM.Checked;
			Program.ContextMenuIntegration.RunAsSYSTEM_TI = chkRunAsSYSTEM_TI.Checked;

			Program.SaveSettings();
			if (RestartRequired)
			{
				if (MessageBox.Show(MUI.GetText("Common.AskToRestart"),
					MUI.GetText("Common.SureBo_title"),
					MessageBoxButtons.YesNo, MessageBoxIcon.Question)
					== DialogResult.Yes)
				{
					Application.Restart();
				}
			}
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}


	}
}
