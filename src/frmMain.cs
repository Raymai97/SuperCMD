using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace SuperCMD
{
	public partial class frmMain : Form
	{

		IntPtr hWnd;
		Q[] Qs = Program.Qs;
		frmConfig ConfigUI = new frmConfig();
		frmQEditor QEditorUI = new frmQEditor();
		frmWait WaitUI = new frmWait();

		private void ClearAll()
		{
			foreach (TextBox txt in new TextBox[] {
				txtArguments, txtProgramPath, txtCustomWorkingDir})
			{
				txt.Clear();
				txt.SelectionStart = int.MaxValue;
			}
			rdoAutoWorkingDir.Checked = true;
			chkTI.Checked = true;
			txtProgramPath.Select();
			txtProgramPath.SelectAll();
		}

		private void Run(Q q)
		{
			if (bw.IsBusy) return;
			bw.RunWorkerAsync(q);
			if (q.UseTItoken) WaitUI.ShowDialogIfNeeded(this);
		}

		private void RunQbtn(Button btn)
		{
			int i = QbtnIndex(btn);
			Q q = Qs[i - 1];
			if (q.Name == "")
			{
				MessageBox.Show(MUI.GetText("Common.AskToNameQbtn"),
					MUI.GetText("Common.Error_title"),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				Run(q);
			}
		}

		private void EditQbtn(Button btn)
		{
			btn.Focus();
			Color oriBgColor = btn.BackColor;
			Color oriForeColor = btn.ForeColor;
			btn.BackColor = SystemColors.Highlight;
			btn.ForeColor = SystemColors.HighlightText;

			int i = QbtnIndex(btn);
			frmQEditor UI = QEditorUI;
			UI.Left = this.Right - UI.Width;
			UI.Top = this.Bottom - UI.Height;
			UI.ClearAll();
			UI.ReadFrom(Qs[i - 1]);
			if (UI.ShowDialog() == DialogResult.OK)
			{
				UI.WriteTo(ref Qs[i - 1]);
				Program.SaveSettings();
			}
			RefreshQbtn();

			btn.BackColor = oriBgColor;
			btn.ForeColor = oriForeColor;
			if (!Program.beClassic) btn.UseVisualStyleBackColor = true;
		}

		private void RefreshQbtn()
		{
			btnQ1.Text = "(1) " + Qs[0].Name;
			btnQ2.Text = "(2) " + Qs[1].Name;
			btnQ3.Text = "(3) " + Qs[2].Name;
			btnQ4.Text = "(4) " + Qs[3].Name;
			btnQ5.Text = "(5) " + Qs[4].Name;
			btnQ6.Text = "(6) " + Qs[5].Name;
			btnQ7.Text = "(7) " + Qs[6].Name;
			btnQ8.Text = "(8) " + Qs[7].Name;
			btnQ9.Text = "(9) " + Qs[8].Name;
		}

		private int QbtnIndex(Button btn)
		{
			if (btn == btnQ1) return 1;
			if (btn == btnQ2) return 2;
			if (btn == btnQ3) return 3;
			if (btn == btnQ4) return 4;
			if (btn == btnQ5) return 5;
			if (btn == btnQ6) return 6;
			if (btn == btnQ7) return 7;
			if (btn == btnQ8) return 8;
			if (btn == btnQ9) return 9;
			return 0;
		}
		
		#region Smarter UI Tweak

		private void rdo_AutoCorrect(object sender, EventArgs e)
		{
			// Make the program usable even if keyboard only
			rdoCustomWorkingDir.TabStop = true;
			rdoAutoWorkingDir.TabStop = true;
			rdoCustomWorkingDir.TabIndex = 1;
			rdoAutoWorkingDir.TabIndex = 0;
		}

		private void txtCustomWorkingDir_Click(object sender, EventArgs e)
		{
			rdoCustomWorkingDir.Checked = true;
		}

		#endregion

		private void bw_DoWork(object sender, DoWorkEventArgs e)
		{
			Q q = (Q)e.Argument;
			if (q.UseTItoken)
			{
				if (Program.StartTiService())
				{
					SuperCore.RunWithTokenOf("winlogon.exe", true,
						Application.ExecutablePath,
					   (Program.DebugMode ? "/Debug" : "") + 
					   " /SendLogTo:" + hWnd.ToInt64() +
					   " /WithTokenOf:TrustedInstaller.exe" +
					   " /ChangeToActiveSessionID" +
					   " /Dir:\"" + q.WorkingDir + "\"" +
					   " /Run:\"" + q.ExeToRun + "\" " + q.Arguments);
				}
			}
			else
			{
				SuperCore.RunWithTokenOf("winlogon.exe", true,
					q.ExeToRun, q.Arguments, q.WorkingDir);
			}
		}

		private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			WaitUI.Hide();
			Program.ComplainAndLog();
			SuperCore.ClearLog();
		}

		public frmMain()
		{
			InitializeComponent();
			this.Text = Program.Title;
			hWnd = this.Handle;
			Win32.SetFormIcon(this.Handle, Application.ExecutablePath);
			MUI.MainUI = this;
			MUI.QEditorUI = QEditorUI;
			MUI.ConfigUI = ConfigUI;
			MUI.RefreshFrmLang();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			this.CenterToScreen();
			RefreshQbtn();
			foreach (TextBox t in new TextBox[] {
			        txtArguments, txtCustomWorkingDir, txtProgramPath })
			{
				t.BorderStyle = Program.beClassic ?
					BorderStyle.FixedSingle : BorderStyle.Fixed3D;
			}
		}

		protected override void WndProc(ref Message m)
		{
			string msg = Win32._GetMessage(m);
			if (msg != null)
			{
				MessageBox.Show(msg, MUI.GetText("Common.Error_title"),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			base.WndProc(ref m);
		}

		private void btnQ_Click(object sender, EventArgs e)
		{
			RunQbtn((Button)sender);
		}

		private void btnQ_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right) EditQbtn((Button)sender); 
		}

		private void btnQ_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Apps) EditQbtn((Button)sender); 
		}

		private void lnkResetQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (MessageBox.Show(MUI.GetText("Common.AskToResetQbtn"), 
				MUI.GetText("Common.SureBo_title"),
				MessageBoxButtons.YesNo, MessageBoxIcon.Question,
				MessageBoxDefaultButton.Button2	) == DialogResult.Yes)
			{
				Program.LoadSettings(Properties.Resources.defaultSettings);
				RefreshQbtn();
			}
		}

		private void btnSelectExeAndRun_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = "";
			ofd.Multiselect = false;
			ofd.Filter = MUI.GetText("Common.FileType_EXE") + "|*.exe;*.bat;*.cmd";
			if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Q q = new Q();
				q.UseTItoken = chkTI_quick.Checked;
				q.ExeToRun = ofd.FileName;
				Run(q);
			}
		}

		private void btnSelectExe_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = "";
			ofd.Multiselect = false;
			ofd.Filter =  MUI.GetText("Common.FileType_EXE") + "|*.exe;*.bat;*.cmd";
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				txtProgramPath.Text = ofd.FileName;
			}
		}

		private void btnAppendArgs_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = "";
			ofd.Multiselect = true;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				foreach (string filePath in ofd.FileNames)
				{
					txtArguments.AppendText("\"" + filePath + "\" ");
				}
			}
		}

		private void btnSelectWorkingDir_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			fbd.SelectedPath = txtCustomWorkingDir.Text;
			fbd.ShowNewFolderButton = true;
			if (fbd.ShowDialog() == DialogResult.OK)
			{
				txtCustomWorkingDir.Text = fbd.SelectedPath;
				rdoCustomWorkingDir.Checked = true;
			}
		}

		private void btnRunAsSystem_Click(object sender, EventArgs e)
		{
			Q q = new Q();
			q.UseTItoken = chkTI.Checked;
			q.ExeToRun = txtProgramPath.Text;
			q.Arguments = txtArguments.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ? txtCustomWorkingDir.Text : "";
			Run(q);
		}

		private void btnMenu_Click(object sender, EventArgs e)
		{
			mnuQEdit.Show(btnQEditMenu, new Point(0, 0), ToolStripDropDownDirection.AboveRight);
		}

		private void cmiCopy_Click(object sender, EventArgs e)
		{
			Q q = Program.CopiedQ;
			q.Name = "";
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ? txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
		}

		private void cmiCopyAsText_Click(object sender, EventArgs e)
		{
			Q q = new Q();
			q.Name = "";
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ? txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
			Clipboard.SetText(q.ToString());
		}

		private void cmiPaste_Click(object sender, EventArgs e)
		{
			Q q = Program.CopiedQ;
			txtArguments.Text = q.Arguments;
			txtProgramPath.Text = q.ExeToRun;
			if (q.WorkingDir == "")
			{
				rdoAutoWorkingDir.Checked = true;
			}
			else
			{
				rdoCustomWorkingDir.Checked = true;
				txtCustomWorkingDir.Text = q.WorkingDir;
			}
			chkTI.Checked = q.UseTItoken;
		}

		private void cmiClearAll_Click(object sender, EventArgs e)
		{
			ClearAll();
		}

		private void btnConfig_Click(object sender, EventArgs e)
		{
			ConfigUI.ShowDialog();
		}

		private void cmiCreateLnk_Click(object sender, EventArgs e)
		{
			Q q = new Q();
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ?
				txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
			Program.OfferCreateLnk(q);
		}

		
	}
}
