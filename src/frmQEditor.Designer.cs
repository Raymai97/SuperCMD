namespace SuperCMD
{
	partial class frmQEditor
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
			this.components = new System.ComponentModel.Container();
			this.lblName = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblProgramPath = new System.Windows.Forms.Label();
			this.txtProgramPath = new System.Windows.Forms.TextBox();
			this.lblArguments = new System.Windows.Forms.Label();
			this.txtArguments = new System.Windows.Forms.TextBox();
			this.btnOK = new W31Button();
			this.btnCancel = new W31Button();
			this.btnSelectExe = new W31Button();
			this.btnAppendArgs = new W31Button();
			this.chkTI = new System.Windows.Forms.CheckBox();
			this.grpWorkingDir = new System.Windows.Forms.GroupBox();
			this.btnSelectWorkingDir = new W31Button();
			this.txtCustomWorkingDir = new System.Windows.Forms.TextBox();
			this.rdoCustomWorkingDir = new System.Windows.Forms.RadioButton();
			this.rdoAutoWorkingDir = new System.Windows.Forms.RadioButton();
			this.btnQEditMenu = new W31Button();
			this.mnuQEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmiCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.cmiCopyAsText = new System.Windows.Forms.ToolStripMenuItem();
			this.cmiPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmiCreateLnk = new System.Windows.Forms.ToolStripMenuItem();
			this.grpWorkingDir.SuspendLayout();
			this.mnuQEdit.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 15);
			this.lblName.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(42, 15);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "Name:";
			// 
			// txtName
			// 
			this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtName.Location = new System.Drawing.Point(12, 33);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(370, 23);
			this.txtName.TabIndex = 0;
			// 
			// lblProgramPath
			// 
			this.lblProgramPath.AutoSize = true;
			this.lblProgramPath.Location = new System.Drawing.Point(12, 65);
			this.lblProgramPath.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.lblProgramPath.Name = "lblProgramPath";
			this.lblProgramPath.Size = new System.Drawing.Size(83, 15);
			this.lblProgramPath.TabIndex = 0;
			this.lblProgramPath.Text = "Program path:";
			// 
			// txtProgramPath
			// 
			this.txtProgramPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtProgramPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtProgramPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.txtProgramPath.Location = new System.Drawing.Point(12, 83);
			this.txtProgramPath.Name = "txtProgramPath";
			this.txtProgramPath.Size = new System.Drawing.Size(332, 23);
			this.txtProgramPath.TabIndex = 1;
			// 
			// lblArguments
			// 
			this.lblArguments.AutoSize = true;
			this.lblArguments.Location = new System.Drawing.Point(12, 115);
			this.lblArguments.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
			this.lblArguments.Name = "lblArguments";
			this.lblArguments.Size = new System.Drawing.Size(69, 15);
			this.lblArguments.TabIndex = 0;
			this.lblArguments.Text = "Arguments:";
			// 
			// txtArguments
			// 
			this.txtArguments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtArguments.Location = new System.Drawing.Point(12, 133);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(332, 23);
			this.txtArguments.TabIndex = 3;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(202, 262);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(87, 28);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(295, 262);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 28);
			this.btnCancel.TabIndex = 9;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelectExe
			// 
			this.btnSelectExe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectExe.Location = new System.Drawing.Point(350, 82);
			this.btnSelectExe.Name = "btnSelectExe";
			this.btnSelectExe.Size = new System.Drawing.Size(32, 23);
			this.btnSelectExe.TabIndex = 2;
			this.btnSelectExe.Text = "...";
			this.btnSelectExe.UseVisualStyleBackColor = true;
			this.btnSelectExe.Click += new System.EventHandler(this.btnSelectExe_Click);
			// 
			// btnAppendArgs
			// 
			this.btnAppendArgs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAppendArgs.Location = new System.Drawing.Point(350, 132);
			this.btnAppendArgs.Name = "btnAppendArgs";
			this.btnAppendArgs.Size = new System.Drawing.Size(32, 23);
			this.btnAppendArgs.TabIndex = 4;
			this.btnAppendArgs.Text = "+";
			this.btnAppendArgs.UseVisualStyleBackColor = true;
			this.btnAppendArgs.Click += new System.EventHandler(this.btnAppendArgs_Click);
			// 
			// chkTI
			// 
			this.chkTI.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.chkTI.AutoSize = true;
			this.chkTI.Checked = true;
			this.chkTI.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTI.Location = new System.Drawing.Point(115, 225);
			this.chkTI.Name = "chkTI";
			this.chkTI.Size = new System.Drawing.Size(165, 19);
			this.chkTI.TabIndex = 7;
			this.chkTI.Text = "Use TrustedInstaller token!";
			this.chkTI.UseVisualStyleBackColor = true;
			// 
			// grpWorkingDir
			// 
			this.grpWorkingDir.Controls.Add(this.btnSelectWorkingDir);
			this.grpWorkingDir.Controls.Add(this.txtCustomWorkingDir);
			this.grpWorkingDir.Controls.Add(this.rdoCustomWorkingDir);
			this.grpWorkingDir.Controls.Add(this.rdoAutoWorkingDir);
			this.grpWorkingDir.Location = new System.Drawing.Point(12, 165);
			this.grpWorkingDir.Name = "grpWorkingDir";
			this.grpWorkingDir.Size = new System.Drawing.Size(370, 54);
			this.grpWorkingDir.TabIndex = 5;
			this.grpWorkingDir.TabStop = false;
			this.grpWorkingDir.Text = "Working directory";
			// 
			// btnSelectWorkingDir
			// 
			this.btnSelectWorkingDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectWorkingDir.Location = new System.Drawing.Point(332, 22);
			this.btnSelectWorkingDir.Name = "btnSelectWorkingDir";
			this.btnSelectWorkingDir.Size = new System.Drawing.Size(32, 23);
			this.btnSelectWorkingDir.TabIndex = 3;
			this.btnSelectWorkingDir.Text = "...";
			this.btnSelectWorkingDir.UseVisualStyleBackColor = true;
			this.btnSelectWorkingDir.Click += new System.EventHandler(this.btnSelectWorkingDir_Click);
			// 
			// txtCustomWorkingDir
			// 
			this.txtCustomWorkingDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.txtCustomWorkingDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtCustomWorkingDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.txtCustomWorkingDir.Location = new System.Drawing.Point(81, 22);
			this.txtCustomWorkingDir.Name = "txtCustomWorkingDir";
			this.txtCustomWorkingDir.Size = new System.Drawing.Size(245, 23);
			this.txtCustomWorkingDir.TabIndex = 2;
			this.txtCustomWorkingDir.Click += new System.EventHandler(this.txtCustomWorkingDir_Click);
			// 
			// rdoCustomWorkingDir
			// 
			this.rdoCustomWorkingDir.AutoSize = true;
			this.rdoCustomWorkingDir.Location = new System.Drawing.Point(63, 24);
			this.rdoCustomWorkingDir.Name = "rdoCustomWorkingDir";
			this.rdoCustomWorkingDir.Size = new System.Drawing.Size(28, 19);
			this.rdoCustomWorkingDir.TabIndex = 1;
			this.rdoCustomWorkingDir.TabStop = true;
			this.rdoCustomWorkingDir.Text = " ";
			this.rdoCustomWorkingDir.UseVisualStyleBackColor = true;
			this.rdoCustomWorkingDir.CheckedChanged += new System.EventHandler(this.rdo_AutoCorrect);
			this.rdoCustomWorkingDir.Enter += new System.EventHandler(this.rdo_AutoCorrect);
			// 
			// rdoAutoWorkingDir
			// 
			this.rdoAutoWorkingDir.AutoSize = true;
			this.rdoAutoWorkingDir.Checked = true;
			this.rdoAutoWorkingDir.Location = new System.Drawing.Point(6, 24);
			this.rdoAutoWorkingDir.Name = "rdoAutoWorkingDir";
			this.rdoAutoWorkingDir.Size = new System.Drawing.Size(51, 19);
			this.rdoAutoWorkingDir.TabIndex = 0;
			this.rdoAutoWorkingDir.TabStop = true;
			this.rdoAutoWorkingDir.Text = "Auto";
			this.rdoAutoWorkingDir.UseVisualStyleBackColor = true;
			this.rdoAutoWorkingDir.CheckedChanged += new System.EventHandler(this.rdo_AutoCorrect);
			this.rdoAutoWorkingDir.Enter += new System.EventHandler(this.rdo_AutoCorrect);
			// 
			// btnQEditMenu
			// 
			this.btnQEditMenu.Font = new System.Drawing.Font("Webdings", 11.25F);
			this.btnQEditMenu.Location = new System.Drawing.Point(15, 264);
			this.btnQEditMenu.Name = "btnQEditMenu";
			this.btnQEditMenu.Size = new System.Drawing.Size(32, 25);
			this.btnQEditMenu.TabIndex = 10;
			this.btnQEditMenu.Text = "5";
			this.btnQEditMenu.UseVisualStyleBackColor = true;
			this.btnQEditMenu.Click += new System.EventHandler(this.btnMenu_Click);
			// 
			// mnuQEdit
			// 
			this.mnuQEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiCopy,
            this.cmiCopyAsText,
            this.cmiPaste,
            this.toolStripMenuItem2,
            this.cmiClearAll,
            this.toolStripMenuItem1,
            this.cmiCreateLnk});
			this.mnuQEdit.Name = "mnuQEdit";
			this.mnuQEdit.Size = new System.Drawing.Size(157, 126);
			// 
			// cmiCopy
			// 
			this.cmiCopy.Name = "cmiCopy";
			this.cmiCopy.Size = new System.Drawing.Size(156, 22);
			this.cmiCopy.Text = "Copy";
			this.cmiCopy.Click += new System.EventHandler(this.cmiCopy_Click);
			// 
			// cmiCopyAsText
			// 
			this.cmiCopyAsText.Name = "cmiCopyAsText";
			this.cmiCopyAsText.Size = new System.Drawing.Size(156, 22);
			this.cmiCopyAsText.Text = "Copy as text";
			this.cmiCopyAsText.Click += new System.EventHandler(this.cmiCopyAsText_Click);
			// 
			// cmiPaste
			// 
			this.cmiPaste.Name = "cmiPaste";
			this.cmiPaste.Size = new System.Drawing.Size(156, 22);
			this.cmiPaste.Text = "Paste";
			this.cmiPaste.Click += new System.EventHandler(this.cmiPaste_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(153, 6);
			// 
			// cmiClearAll
			// 
			this.cmiClearAll.Name = "cmiClearAll";
			this.cmiClearAll.Size = new System.Drawing.Size(156, 22);
			this.cmiClearAll.Text = "Clear All";
			this.cmiClearAll.Click += new System.EventHandler(this.cmiClearAll_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
			// 
			// cmiCreateLnk
			// 
			this.cmiCreateLnk.Name = "cmiCreateLnk";
			this.cmiCreateLnk.Size = new System.Drawing.Size(156, 22);
			this.cmiCreateLnk.Text = "Create Shortcut";
			this.cmiCreateLnk.Click += new System.EventHandler(this.cmiCreateLnk_Click);
			// 
			// frmQEditor
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(394, 302);
			this.Controls.Add(this.btnQEditMenu);
			this.Controls.Add(this.chkTI);
			this.Controls.Add(this.grpWorkingDir);
			this.Controls.Add(this.btnAppendArgs);
			this.Controls.Add(this.btnSelectExe);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtArguments);
			this.Controls.Add(this.lblArguments);
			this.Controls.Add(this.txtProgramPath);
			this.Controls.Add(this.lblProgramPath);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblName);
			this.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmQEditor";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Edit Quick Launch item";
			this.Load += new System.EventHandler(this.frmQEditor_Load);
			this.grpWorkingDir.ResumeLayout(false);
			this.grpWorkingDir.PerformLayout();
			this.mnuQEdit.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblProgramPath;
		private System.Windows.Forms.TextBox txtProgramPath;
		private System.Windows.Forms.Label lblArguments;
		private System.Windows.Forms.TextBox txtArguments;
		private W31Button btnOK;
		private W31Button btnCancel;
		private W31Button btnSelectExe;
		private W31Button btnAppendArgs;
		private System.Windows.Forms.GroupBox grpWorkingDir;
		private W31Button btnSelectWorkingDir;
		private System.Windows.Forms.TextBox txtCustomWorkingDir;
		private System.Windows.Forms.RadioButton rdoCustomWorkingDir;
		private System.Windows.Forms.RadioButton rdoAutoWorkingDir;
		private W31Button btnQEditMenu;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		internal System.Windows.Forms.ToolStripMenuItem cmiCopy;
		internal System.Windows.Forms.ToolStripMenuItem cmiCopyAsText;
		internal System.Windows.Forms.ToolStripMenuItem cmiPaste;
		internal System.Windows.Forms.ToolStripMenuItem cmiClearAll;
		internal System.Windows.Forms.ToolStripMenuItem cmiCreateLnk;
		internal System.Windows.Forms.ContextMenuStrip mnuQEdit;
		internal System.Windows.Forms.CheckBox chkTI;
	}
}