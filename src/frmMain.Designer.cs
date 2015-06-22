namespace SuperCMD
{
	partial class frmMain
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
			this.grpQLaunch = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lnkResetQ = new System.Windows.Forms.LinkLabel();
			this.lblQRightClick = new System.Windows.Forms.Label();
			this.btnQ9 = new W31Button();
			this.btnQ8 = new W31Button();
			this.btnQ7 = new W31Button();
			this.btnQ6 = new W31Button();
			this.btnQ5 = new W31Button();
			this.btnQ4 = new W31Button();
			this.btnQ3 = new W31Button();
			this.btnQ2 = new W31Button();
			this.btnQ1 = new W31Button();
			this.grpAdvanced = new System.Windows.Forms.GroupBox();
			this.btnConfig = new W31Button();
			this.btnQEditMenu = new W31Button();
			this.chkTI = new System.Windows.Forms.CheckBox();
			this.btnRunAdvanced = new W31Button();
			this.grpWorkingDir = new System.Windows.Forms.GroupBox();
			this.btnSelectWorkingDir = new W31Button();
			this.txtCustomWorkingDir = new System.Windows.Forms.TextBox();
			this.rdoCustomWorkingDir = new System.Windows.Forms.RadioButton();
			this.rdoAutoWorkingDir = new System.Windows.Forms.RadioButton();
			this.txtArguments = new System.Windows.Forms.TextBox();
			this.txtProgramPath = new System.Windows.Forms.TextBox();
			this.lblArguments = new System.Windows.Forms.Label();
			this.lblProgramPath = new System.Windows.Forms.Label();
			this.btnAppendArgs = new W31Button();
			this.btnSelectExe = new W31Button();
			this.chkTI_quick = new System.Windows.Forms.CheckBox();
			this.mnuQEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmiCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.cmiCopyAsText = new System.Windows.Forms.ToolStripMenuItem();
			this.cmiPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.cmi_ = new System.Windows.Forms.ToolStripSeparator();
			this.cmiClearAll = new System.Windows.Forms.ToolStripMenuItem();
			this.cmi__ = new System.Windows.Forms.ToolStripSeparator();
			this.cmiCreateLnk = new System.Windows.Forms.ToolStripMenuItem();
			this.grpOneKey = new System.Windows.Forms.GroupBox();
			this.btnSelectAndRun = new W31Button();
			this.bw = new System.ComponentModel.BackgroundWorker();
			this.grpQLaunch.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.grpAdvanced.SuspendLayout();
			this.grpWorkingDir.SuspendLayout();
			this.mnuQEdit.SuspendLayout();
			this.grpOneKey.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpQLaunch
			// 
			this.grpQLaunch.Controls.Add(this.tableLayoutPanel1);
			this.grpQLaunch.Controls.Add(this.btnQ9);
			this.grpQLaunch.Controls.Add(this.btnQ8);
			this.grpQLaunch.Controls.Add(this.btnQ7);
			this.grpQLaunch.Controls.Add(this.btnQ6);
			this.grpQLaunch.Controls.Add(this.btnQ5);
			this.grpQLaunch.Controls.Add(this.btnQ4);
			this.grpQLaunch.Controls.Add(this.btnQ3);
			this.grpQLaunch.Controls.Add(this.btnQ2);
			this.grpQLaunch.Controls.Add(this.btnQ1);
			this.grpQLaunch.Location = new System.Drawing.Point(12, 12);
			this.grpQLaunch.Name = "grpQLaunch";
			this.grpQLaunch.Size = new System.Drawing.Size(241, 410);
			this.grpQLaunch.TabIndex = 2;
			this.grpQLaunch.TabStop = false;
			this.grpQLaunch.Text = "Quick Launch";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.lnkResetQ, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblQRightClick, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 383);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(235, 24);
			this.tableLayoutPanel1.TabIndex = 9;
			// 
			// lnkResetQ
			// 
			this.lnkResetQ.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.lnkResetQ.AutoSize = true;
			this.lnkResetQ.Location = new System.Drawing.Point(197, 4);
			this.lnkResetQ.Name = "lnkResetQ";
			this.lnkResetQ.Size = new System.Drawing.Size(35, 15);
			this.lnkResetQ.TabIndex = 9;
			this.lnkResetQ.TabStop = true;
			this.lnkResetQ.Text = "Reset";
			this.lnkResetQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkResetQ_LinkClicked);
			// 
			// lblQRightClick
			// 
			this.lblQRightClick.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.lblQRightClick.AutoSize = true;
			this.lblQRightClick.Location = new System.Drawing.Point(3, 4);
			this.lblQRightClick.Margin = new System.Windows.Forms.Padding(3);
			this.lblQRightClick.Name = "lblQRightClick";
			this.lblQRightClick.Size = new System.Drawing.Size(102, 15);
			this.lblQRightClick.TabIndex = 1;
			this.lblQRightClick.Text = "Right click to edit.";
			// 
			// btnQ9
			// 
			this.btnQ9.Location = new System.Drawing.Point(6, 344);
			this.btnQ9.Name = "btnQ9";
			this.btnQ9.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
			this.btnQ9.Size = new System.Drawing.Size(226, 34);
			this.btnQ9.TabIndex = 8;
			this.btnQ9.Text = "(9) ";
			this.btnQ9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ9.UseVisualStyleBackColor = true;
			this.btnQ9.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ9.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ9.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ8
			// 
			this.btnQ8.Location = new System.Drawing.Point(6, 304);
			this.btnQ8.Name = "btnQ8";
			this.btnQ8.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
			this.btnQ8.Size = new System.Drawing.Size(226, 34);
			this.btnQ8.TabIndex = 7;
			this.btnQ8.Text = "(8) ";
			this.btnQ8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ8.UseVisualStyleBackColor = true;
			this.btnQ8.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ8.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ8.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ7
			// 
			this.btnQ7.Location = new System.Drawing.Point(6, 264);
			this.btnQ7.Name = "btnQ7";
			this.btnQ7.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
			this.btnQ7.Size = new System.Drawing.Size(226, 34);
			this.btnQ7.TabIndex = 6;
			this.btnQ7.Text = "(7) ";
			this.btnQ7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ7.UseVisualStyleBackColor = true;
			this.btnQ7.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ7.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ7.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ6
			// 
			this.btnQ6.Location = new System.Drawing.Point(6, 224);
			this.btnQ6.Name = "btnQ6";
			this.btnQ6.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
			this.btnQ6.Size = new System.Drawing.Size(226, 34);
			this.btnQ6.TabIndex = 5;
			this.btnQ6.Text = "(6)";
			this.btnQ6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ6.UseVisualStyleBackColor = true;
			this.btnQ6.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ6.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ5
			// 
			this.btnQ5.Location = new System.Drawing.Point(6, 184);
			this.btnQ5.Name = "btnQ5";
			this.btnQ5.Padding = new System.Windows.Forms.Padding(16, 0, 16, 0);
			this.btnQ5.Size = new System.Drawing.Size(226, 34);
			this.btnQ5.TabIndex = 4;
			this.btnQ5.Text = "(5) ";
			this.btnQ5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ5.UseVisualStyleBackColor = true;
			this.btnQ5.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ4
			// 
			this.btnQ4.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnQ4.Location = new System.Drawing.Point(6, 144);
			this.btnQ4.Name = "btnQ4";
			this.btnQ4.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
			this.btnQ4.Size = new System.Drawing.Size(226, 34);
			this.btnQ4.TabIndex = 3;
			this.btnQ4.Text = "(4)";
			this.btnQ4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ4.UseVisualStyleBackColor = true;
			this.btnQ4.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ3
			// 
			this.btnQ3.Location = new System.Drawing.Point(6, 104);
			this.btnQ3.Name = "btnQ3";
			this.btnQ3.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
			this.btnQ3.Size = new System.Drawing.Size(226, 34);
			this.btnQ3.TabIndex = 2;
			this.btnQ3.Text = "(3)";
			this.btnQ3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ3.UseVisualStyleBackColor = true;
			this.btnQ3.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ2
			// 
			this.btnQ2.Location = new System.Drawing.Point(6, 64);
			this.btnQ2.Name = "btnQ2";
			this.btnQ2.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
			this.btnQ2.Size = new System.Drawing.Size(226, 34);
			this.btnQ2.TabIndex = 1;
			this.btnQ2.Text = "(2)";
			this.btnQ2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ2.UseVisualStyleBackColor = true;
			this.btnQ2.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// btnQ1
			// 
			this.btnQ1.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.btnQ1.Location = new System.Drawing.Point(6, 24);
			this.btnQ1.Name = "btnQ1";
			this.btnQ1.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
			this.btnQ1.Size = new System.Drawing.Size(226, 34);
			this.btnQ1.TabIndex = 0;
			this.btnQ1.Text = "(1)";
			this.btnQ1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQ1.UseVisualStyleBackColor = true;
			this.btnQ1.Click += new System.EventHandler(this.btnQ_Click);
			this.btnQ1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.btnQ_KeyUp);
			this.btnQ1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnQ_MouseUp);
			// 
			// grpAdvanced
			// 
			this.grpAdvanced.Controls.Add(this.btnConfig);
			this.grpAdvanced.Controls.Add(this.btnQEditMenu);
			this.grpAdvanced.Controls.Add(this.chkTI);
			this.grpAdvanced.Controls.Add(this.btnRunAdvanced);
			this.grpAdvanced.Controls.Add(this.grpWorkingDir);
			this.grpAdvanced.Controls.Add(this.txtArguments);
			this.grpAdvanced.Controls.Add(this.txtProgramPath);
			this.grpAdvanced.Controls.Add(this.lblArguments);
			this.grpAdvanced.Controls.Add(this.lblProgramPath);
			this.grpAdvanced.Controls.Add(this.btnAppendArgs);
			this.grpAdvanced.Controls.Add(this.btnSelectExe);
			this.grpAdvanced.Location = new System.Drawing.Point(264, 130);
			this.grpAdvanced.Name = "grpAdvanced";
			this.grpAdvanced.Size = new System.Drawing.Size(318, 292);
			this.grpAdvanced.TabIndex = 1;
			this.grpAdvanced.TabStop = false;
			this.grpAdvanced.Text = "Advanced";
			// 
			// btnConfig
			// 
			this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConfig.Location = new System.Drawing.Point(276, 253);
			this.btnConfig.Name = "btnConfig";
			this.btnConfig.Size = new System.Drawing.Size(32, 25);
			this.btnConfig.TabIndex = 8;
			this.btnConfig.Text = "...";
			this.btnConfig.UseVisualStyleBackColor = true;
			this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
			// 
			// btnQEditMenu
			// 
			this.btnQEditMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnQEditMenu.Font = new System.Drawing.Font("Webdings", 11.25F);
			this.btnQEditMenu.Location = new System.Drawing.Point(12, 253);
			this.btnQEditMenu.Name = "btnQEditMenu";
			this.btnQEditMenu.Size = new System.Drawing.Size(32, 25);
			this.btnQEditMenu.TabIndex = 7;
			this.btnQEditMenu.Text = "5";
			this.btnQEditMenu.UseVisualStyleBackColor = true;
			this.btnQEditMenu.Click += new System.EventHandler(this.btnMenu_Click);
			// 
			// chkTI
			// 
			this.chkTI.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.chkTI.AutoSize = true;
			this.chkTI.Checked = true;
			this.chkTI.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTI.Location = new System.Drawing.Point(77, 205);
			this.chkTI.Name = "chkTI";
			this.chkTI.Size = new System.Drawing.Size(165, 19);
			this.chkTI.TabIndex = 6;
			this.chkTI.Text = "Use TrustedInstaller token!";
			this.chkTI.UseVisualStyleBackColor = true;
			// 
			// btnRunAdvanced
			// 
			this.btnRunAdvanced.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnRunAdvanced.Location = new System.Drawing.Point(109, 248);
			this.btnRunAdvanced.Name = "btnRunAdvanced";
			this.btnRunAdvanced.Size = new System.Drawing.Size(100, 30);
			this.btnRunAdvanced.TabIndex = 6;
			this.btnRunAdvanced.Text = "Run!";
			this.btnRunAdvanced.UseVisualStyleBackColor = true;
			this.btnRunAdvanced.Click += new System.EventHandler(this.btnRunAsSystem_Click);
			// 
			// grpWorkingDir
			// 
			this.grpWorkingDir.Controls.Add(this.btnSelectWorkingDir);
			this.grpWorkingDir.Controls.Add(this.txtCustomWorkingDir);
			this.grpWorkingDir.Controls.Add(this.rdoCustomWorkingDir);
			this.grpWorkingDir.Controls.Add(this.rdoAutoWorkingDir);
			this.grpWorkingDir.Location = new System.Drawing.Point(6, 134);
			this.grpWorkingDir.Name = "grpWorkingDir";
			this.grpWorkingDir.Size = new System.Drawing.Size(306, 54);
			this.grpWorkingDir.TabIndex = 4;
			this.grpWorkingDir.TabStop = false;
			this.grpWorkingDir.Text = "Working directory";
			// 
			// btnSelectWorkingDir
			// 
			this.btnSelectWorkingDir.Location = new System.Drawing.Point(268, 22);
			this.btnSelectWorkingDir.Name = "btnSelectWorkingDir";
			this.btnSelectWorkingDir.Size = new System.Drawing.Size(32, 23);
			this.btnSelectWorkingDir.TabIndex = 3;
			this.btnSelectWorkingDir.Text = "...";
			this.btnSelectWorkingDir.UseVisualStyleBackColor = true;
			this.btnSelectWorkingDir.Click += new System.EventHandler(this.btnSelectWorkingDir_Click);
			// 
			// txtCustomWorkingDir
			// 
			this.txtCustomWorkingDir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtCustomWorkingDir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
			this.txtCustomWorkingDir.Location = new System.Drawing.Point(81, 22);
			this.txtCustomWorkingDir.Name = "txtCustomWorkingDir";
			this.txtCustomWorkingDir.Size = new System.Drawing.Size(181, 23);
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
			// txtArguments
			// 
			this.txtArguments.Location = new System.Drawing.Point(6, 102);
			this.txtArguments.Name = "txtArguments";
			this.txtArguments.Size = new System.Drawing.Size(268, 23);
			this.txtArguments.TabIndex = 2;
			// 
			// txtProgramPath
			// 
			this.txtProgramPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.txtProgramPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
			this.txtProgramPath.Location = new System.Drawing.Point(6, 52);
			this.txtProgramPath.Name = "txtProgramPath";
			this.txtProgramPath.Size = new System.Drawing.Size(268, 23);
			this.txtProgramPath.TabIndex = 0;
			// 
			// lblArguments
			// 
			this.lblArguments.AutoSize = true;
			this.lblArguments.Location = new System.Drawing.Point(6, 81);
			this.lblArguments.Margin = new System.Windows.Forms.Padding(3);
			this.lblArguments.Name = "lblArguments";
			this.lblArguments.Size = new System.Drawing.Size(69, 15);
			this.lblArguments.TabIndex = 1;
			this.lblArguments.Text = "Arguments:";
			// 
			// lblProgramPath
			// 
			this.lblProgramPath.AutoSize = true;
			this.lblProgramPath.Location = new System.Drawing.Point(6, 31);
			this.lblProgramPath.Margin = new System.Windows.Forms.Padding(3);
			this.lblProgramPath.Name = "lblProgramPath";
			this.lblProgramPath.Size = new System.Drawing.Size(83, 15);
			this.lblProgramPath.TabIndex = 1;
			this.lblProgramPath.Text = "Program path:";
			// 
			// btnAppendArgs
			// 
			this.btnAppendArgs.Location = new System.Drawing.Point(280, 101);
			this.btnAppendArgs.Name = "btnAppendArgs";
			this.btnAppendArgs.Size = new System.Drawing.Size(32, 23);
			this.btnAppendArgs.TabIndex = 3;
			this.btnAppendArgs.Text = "+";
			this.btnAppendArgs.UseVisualStyleBackColor = true;
			this.btnAppendArgs.Click += new System.EventHandler(this.btnAppendArgs_Click);
			// 
			// btnSelectExe
			// 
			this.btnSelectExe.Location = new System.Drawing.Point(280, 51);
			this.btnSelectExe.Name = "btnSelectExe";
			this.btnSelectExe.Size = new System.Drawing.Size(32, 23);
			this.btnSelectExe.TabIndex = 1;
			this.btnSelectExe.Text = "...";
			this.btnSelectExe.UseVisualStyleBackColor = true;
			this.btnSelectExe.Click += new System.EventHandler(this.btnSelectExe_Click);
			// 
			// chkTI_quick
			// 
			this.chkTI_quick.AutoSize = true;
			this.chkTI_quick.Checked = true;
			this.chkTI_quick.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkTI_quick.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.chkTI_quick.Location = new System.Drawing.Point(70, 22);
			this.chkTI_quick.Name = "chkTI_quick";
			this.chkTI_quick.Size = new System.Drawing.Size(178, 19);
			this.chkTI_quick.TabIndex = 1;
			this.chkTI_quick.Text = "Use TrustedInstaller token!";
			this.chkTI_quick.UseVisualStyleBackColor = true;
			// 
			// mnuQEdit
			// 
			this.mnuQEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiCopy,
            this.cmiCopyAsText,
            this.cmiPaste,
            this.cmi_,
            this.cmiClearAll,
            this.cmi__,
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
			// cmi_
			// 
			this.cmi_.Name = "cmi_";
			this.cmi_.Size = new System.Drawing.Size(153, 6);
			// 
			// cmiClearAll
			// 
			this.cmiClearAll.Name = "cmiClearAll";
			this.cmiClearAll.Size = new System.Drawing.Size(156, 22);
			this.cmiClearAll.Text = "Clear All";
			this.cmiClearAll.Click += new System.EventHandler(this.cmiClearAll_Click);
			// 
			// cmi__
			// 
			this.cmi__.Name = "cmi__";
			this.cmi__.Size = new System.Drawing.Size(153, 6);
			// 
			// cmiCreateLnk
			// 
			this.cmiCreateLnk.Name = "cmiCreateLnk";
			this.cmiCreateLnk.Size = new System.Drawing.Size(156, 22);
			this.cmiCreateLnk.Text = "Create Shortcut";
			this.cmiCreateLnk.Click += new System.EventHandler(this.cmiCreateLnk_Click);
			// 
			// grpOneKey
			// 
			this.grpOneKey.Controls.Add(this.chkTI_quick);
			this.grpOneKey.Controls.Add(this.btnSelectAndRun);
			this.grpOneKey.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.grpOneKey.Location = new System.Drawing.Point(264, 12);
			this.grpOneKey.Name = "grpOneKey";
			this.grpOneKey.Size = new System.Drawing.Size(318, 112);
			this.grpOneKey.TabIndex = 0;
			this.grpOneKey.TabStop = false;
			this.grpOneKey.Text = "OneKey";
			// 
			// btnSelectAndRun
			// 
			this.btnSelectAndRun.Location = new System.Drawing.Point(44, 49);
			this.btnSelectAndRun.Name = "btnSelectAndRun";
			this.btnSelectAndRun.Size = new System.Drawing.Size(230, 34);
			this.btnSelectAndRun.TabIndex = 0;
			this.btnSelectAndRun.Text = "Select a program and run as SYSTEM";
			this.btnSelectAndRun.UseVisualStyleBackColor = true;
			this.btnSelectAndRun.Click += new System.EventHandler(this.btnSelectExeAndRun_Click);
			// 
			// bw
			// 
			this.bw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_DoWork);
			this.bw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_RunWorkerCompleted);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(594, 442);
			this.Controls.Add(this.grpOneKey);
			this.Controls.Add(this.grpAdvanced);
			this.Controls.Add(this.grpQLaunch);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "SuperCMD title here";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.grpQLaunch.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.grpAdvanced.ResumeLayout(false);
			this.grpAdvanced.PerformLayout();
			this.grpWorkingDir.ResumeLayout(false);
			this.grpWorkingDir.PerformLayout();
			this.mnuQEdit.ResumeLayout(false);
			this.grpOneKey.ResumeLayout(false);
			this.grpOneKey.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox grpQLaunch;
		private System.Windows.Forms.Label lblQRightClick;
		private W31Button btnQ5;
		private W31Button btnQ4;
		private W31Button btnQ3;
		private W31Button btnQ2;
		private W31Button btnQ1;
		private W31Button btnQ9;
		private W31Button btnQ8;
		private W31Button btnQ7;
		private W31Button btnQ6;
		private W31Button btnSelectAndRun;
		private System.Windows.Forms.GroupBox grpAdvanced;
		private System.Windows.Forms.LinkLabel lnkResetQ;
		private W31Button btnRunAdvanced;
		private System.Windows.Forms.TextBox txtArguments;
		private System.Windows.Forms.TextBox txtProgramPath;
		private System.Windows.Forms.Label lblArguments;
		private System.Windows.Forms.Label lblProgramPath;
		private W31Button btnSelectExe;
		private W31Button btnAppendArgs;
		private System.ComponentModel.BackgroundWorker bw;
		private System.Windows.Forms.GroupBox grpWorkingDir;
		private System.Windows.Forms.TextBox txtCustomWorkingDir;
		private System.Windows.Forms.RadioButton rdoCustomWorkingDir;
		private System.Windows.Forms.RadioButton rdoAutoWorkingDir;
		private W31Button btnSelectWorkingDir;
		private System.Windows.Forms.ToolStripSeparator cmi_;
		private W31Button btnQEditMenu;
		private W31Button btnConfig;
		private System.Windows.Forms.ToolStripSeparator cmi__;
		private System.Windows.Forms.GroupBox grpOneKey;
		internal System.Windows.Forms.ToolStripMenuItem cmiCopy;
		internal System.Windows.Forms.ToolStripMenuItem cmiCopyAsText;
		internal System.Windows.Forms.ToolStripMenuItem cmiPaste;
		internal System.Windows.Forms.ToolStripMenuItem cmiClearAll;
		internal System.Windows.Forms.ToolStripMenuItem cmiCreateLnk;
		internal System.Windows.Forms.ContextMenuStrip mnuQEdit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		internal System.Windows.Forms.CheckBox chkTI_quick;
		internal System.Windows.Forms.CheckBox chkTI;
	}
}

