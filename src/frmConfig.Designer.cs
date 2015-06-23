namespace SuperCMD
{
	partial class frmConfig
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
			this.lblTitle = new System.Windows.Forms.Label();
			this.btnCancel = new W31Button();
			this.btnOK = new W31Button();
			this.lblWarning = new System.Windows.Forms.Label();
			this.lnkHomepage = new System.Windows.Forms.LinkLabel();
			this.chkRunAsSYSTEM = new System.Windows.Forms.CheckBox();
			this.chkRunAsSYSTEM_TI = new System.Windows.Forms.CheckBox();
			this.grpCMIntegration = new System.Windows.Forms.GroupBox();
			this.grpMisc = new System.Windows.Forms.GroupBox();
			this.chkBeClassic = new System.Windows.Forms.CheckBox();
			this.chkBeDPIaware = new System.Windows.Forms.CheckBox();
			this.grpLang = new System.Windows.Forms.GroupBox();
			this.cmbLang = new System.Windows.Forms.ComboBox();
			this.grpCMIntegration.SuspendLayout();
			this.grpMisc.SuspendLayout();
			this.grpLang.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
			this.lblTitle.Location = new System.Drawing.Point(12, 12);
			this.lblTitle.Margin = new System.Windows.Forms.Padding(3);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(151, 21);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "SuperCMD title here";
			this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
			this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_MouseDown);
			this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_MouseMove);
			this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_MouseUp);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(386, 251);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 25);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(300, 251);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 25);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// lblWarning
			// 
			this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblWarning.AutoSize = true;
			this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
			this.lblWarning.ForeColor = System.Drawing.Color.Red;
			this.lblWarning.Location = new System.Drawing.Point(9, 241);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(265, 30);
			this.lblWarning.TabIndex = 4;
			this.lblWarning.Text = "This program is intended for personal use only.\r\nDon\'t use it for malicious purpo" +
				"se!";
			this.lblWarning.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// lnkHomepage
			// 
			this.lnkHomepage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lnkHomepage.AutoSize = true;
			this.lnkHomepage.Location = new System.Drawing.Point(298, 17);
			this.lnkHomepage.Name = "lnkHomepage";
			this.lnkHomepage.Size = new System.Drawing.Size(168, 15);
			this.lnkHomepage.TabIndex = 0;
			this.lnkHomepage.TabStop = true;
			this.lnkHomepage.Text = "raymai97.github.io/SuperCMD";
			this.lnkHomepage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkHomepage_LinkClicked);
			// 
			// chkRunAsSYSTEM
			// 
			this.chkRunAsSYSTEM.AutoSize = true;
			this.chkRunAsSYSTEM.Location = new System.Drawing.Point(17, 31);
			this.chkRunAsSYSTEM.Name = "chkRunAsSYSTEM";
			this.chkRunAsSYSTEM.Size = new System.Drawing.Size(107, 19);
			this.chkRunAsSYSTEM.TabIndex = 0;
			this.chkRunAsSYSTEM.Text = "Run as SYSTEM";
			this.chkRunAsSYSTEM.UseVisualStyleBackColor = true;
			// 
			// chkRunAsSYSTEM_TI
			// 
			this.chkRunAsSYSTEM_TI.AutoSize = true;
			this.chkRunAsSYSTEM_TI.Location = new System.Drawing.Point(17, 56);
			this.chkRunAsSYSTEM_TI.Name = "chkRunAsSYSTEM_TI";
			this.chkRunAsSYSTEM_TI.Size = new System.Drawing.Size(128, 19);
			this.chkRunAsSYSTEM_TI.TabIndex = 1;
			this.chkRunAsSYSTEM_TI.Text = "Run as SYSTEM (TI)";
			this.chkRunAsSYSTEM_TI.UseVisualStyleBackColor = true;
			// 
			// grpCMIntegration
			// 
			this.grpCMIntegration.Controls.Add(this.chkRunAsSYSTEM);
			this.grpCMIntegration.Controls.Add(this.chkRunAsSYSTEM_TI);
			this.grpCMIntegration.Location = new System.Drawing.Point(16, 59);
			this.grpCMIntegration.Name = "grpCMIntegration";
			this.grpCMIntegration.Size = new System.Drawing.Size(220, 100);
			this.grpCMIntegration.TabIndex = 1;
			this.grpCMIntegration.TabStop = false;
			this.grpCMIntegration.Text = "Context Menu Integration";
			// 
			// grpMisc
			// 
			this.grpMisc.Controls.Add(this.chkBeClassic);
			this.grpMisc.Controls.Add(this.chkBeDPIaware);
			this.grpMisc.Location = new System.Drawing.Point(242, 59);
			this.grpMisc.Name = "grpMisc";
			this.grpMisc.Size = new System.Drawing.Size(220, 100);
			this.grpMisc.TabIndex = 2;
			this.grpMisc.TabStop = false;
			this.grpMisc.Text = "Misc";
			// 
			// chkBeClassic
			// 
			this.chkBeClassic.AutoSize = true;
			this.chkBeClassic.Location = new System.Drawing.Point(16, 56);
			this.chkBeClassic.Name = "chkBeClassic";
			this.chkBeClassic.Size = new System.Drawing.Size(98, 19);
			this.chkBeClassic.TabIndex = 1;
			this.chkBeClassic.Text = "Use Win3.1 UI";
			this.chkBeClassic.UseVisualStyleBackColor = true;
			// 
			// chkBeDPIaware
			// 
			this.chkBeDPIaware.AutoSize = true;
			this.chkBeDPIaware.Location = new System.Drawing.Point(16, 31);
			this.chkBeDPIaware.Name = "chkBeDPIaware";
			this.chkBeDPIaware.Size = new System.Drawing.Size(94, 19);
			this.chkBeDPIaware.TabIndex = 0;
			this.chkBeDPIaware.Text = "Be DPI aware";
			this.chkBeDPIaware.UseVisualStyleBackColor = true;
			// 
			// grpLang
			// 
			this.grpLang.Controls.Add(this.cmbLang);
			this.grpLang.Location = new System.Drawing.Point(129, 165);
			this.grpLang.Name = "grpLang";
			this.grpLang.Size = new System.Drawing.Size(220, 54);
			this.grpLang.TabIndex = 3;
			this.grpLang.TabStop = false;
			this.grpLang.Text = "Language";
			// 
			// cmbLang
			// 
			this.cmbLang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.cmbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLang.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmbLang.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbLang.FormattingEnabled = true;
			this.cmbLang.Location = new System.Drawing.Point(6, 22);
			this.cmbLang.Name = "cmbLang";
			this.cmbLang.Size = new System.Drawing.Size(208, 25);
			this.cmbLang.TabIndex = 0;
			this.cmbLang.SelectedIndexChanged += new System.EventHandler(this.cmbLang_SelectedIndexChanged);
			// 
			// frmConfig
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(478, 288);
			this.ControlBox = false;
			this.Controls.Add(this.grpLang);
			this.Controls.Add(this.grpMisc);
			this.Controls.Add(this.grpCMIntegration);
			this.Controls.Add(this.lnkHomepage);
			this.Controls.Add(this.lblWarning);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblTitle);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmConfig";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
			this.Load += new System.EventHandler(this.frmConfig_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frm_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frm_MouseUp);
			this.grpCMIntegration.ResumeLayout(false);
			this.grpCMIntegration.PerformLayout();
			this.grpMisc.ResumeLayout(false);
			this.grpMisc.PerformLayout();
			this.grpLang.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblTitle;
		private W31Button btnCancel;
		private W31Button btnOK;
		private System.Windows.Forms.Label lblWarning;
		private System.Windows.Forms.LinkLabel lnkHomepage;
		private System.Windows.Forms.CheckBox chkRunAsSYSTEM;
		private System.Windows.Forms.CheckBox chkRunAsSYSTEM_TI;
		private System.Windows.Forms.GroupBox grpCMIntegration;
		private System.Windows.Forms.GroupBox grpMisc;
		private System.Windows.Forms.CheckBox chkBeDPIaware;
		private System.Windows.Forms.CheckBox chkBeClassic;
		private System.Windows.Forms.GroupBox grpLang;
		private System.Windows.Forms.ComboBox cmbLang;

	}
}