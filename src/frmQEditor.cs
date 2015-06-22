using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace SuperCMD
{
	public partial class frmQEditor : Form
	{

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


		public frmQEditor()
		{
			InitializeComponent();
		}

		private void frmQEditor_Load(object sender, EventArgs e)
		{
			foreach (TextBox t in new TextBox[] {
					txtName, txtArguments, txtCustomWorkingDir,	txtProgramPath})
			{
				t.BorderStyle = Program.beClassic ?
					BorderStyle.FixedSingle : BorderStyle.Fixed3D;
			}
		}

		public void ReadFrom(Q q)
		{
			txtName.Text = q.Name;
			txtArguments.Text = q.Arguments;
			txtProgramPath.Text = q.ExeToRun;
			if (q.WorkingDir != "")
			{
				rdoCustomWorkingDir.Checked = true;
				txtCustomWorkingDir.Text = q.WorkingDir;
			}
			chkTI.Checked = q.UseTItoken;
		}

		public void WriteTo(ref Q q)
		{
			q.Name = txtName.Text;
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ?
				txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
		}

		public void ClearAll()
		{
			foreach (TextBox txt in new TextBox[] {
				txtName, txtArguments, txtProgramPath,
				txtCustomWorkingDir})
			{
				txt.Clear();
				txt.SelectionStart = int.MaxValue;
			}
			rdoAutoWorkingDir.Checked = true; 
			chkTI.Checked = true;
			txtName.Select();
			txtName.SelectAll();
		}

		private void btnSelectExe_Click(object sender, EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.FileName = "";
			ofd.Multiselect = false;
			ofd.Filter = "Executable files|*.exe;*.bat;*.cmd";
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

		private void btnOK_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = System.Windows.Forms.DialogResult.Cancel;
			Close();
		}

		private void btnMenu_Click(object sender, EventArgs e)
		{
			mnuQEdit.Show(btnQEditMenu, new Point(0, 0), ToolStripDropDownDirection.AboveRight);
		}

		private void cmiCopy_Click(object sender, EventArgs e)
		{
			Q q = Program.CopiedQ;
			q.Name = txtName.Text;
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ? txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
		}

		private void cmiCopyAsText_Click(object sender, EventArgs e)
		{
			Q q = new Q();
			q.Name = txtName.Text;
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ? txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
			Clipboard.SetText(q.ToString());
		}

		private void cmiPaste_Click(object sender, EventArgs e)
		{
			Q q = Program.CopiedQ;
			txtName.Text = q.Name;
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

		private void cmiCreateLnk_Click(object sender, EventArgs e)
		{
			Q q = new Q();
			q.Name = txtName.Text;
			q.Arguments = txtArguments.Text;
			q.ExeToRun = txtProgramPath.Text;
			q.WorkingDir = rdoCustomWorkingDir.Checked ?
				txtCustomWorkingDir.Text : "";
			q.UseTItoken = chkTI.Checked;
			Program.OfferCreateLnk(q);
		}


	}
}
