// SuperCMD v2.1 by MaiSoft (Raymai97)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Xml;
using Microsoft.Win32;

namespace SuperCMD
{
	static class Program
	{
		public static string Title = "SuperCMD v2.1";
		public static string Ver = "2.1";
		public static string DirPath = Path.GetDirectoryName(Application.ExecutablePath);
		public static string SettingsPath = DirPath + "\\settings.xml";
		public static string MUIDirPath = Program.DirPath + "\\MUI";
		public static string LastComplain = "";
		// Quick Launch buttons
		public static Q[] Qs = new Q[9];
		// Clipboard feature
		public static Q CopiedQ = new Q();
		// Windows 3.1 theme (easter egg)
		public static bool beClassic = true;
		// In case user prefer DPI virtualization
		public static bool beDPIaware = true;
		// Can be enabled via /Debug argument
		public static bool DebugMode = false;

		// Prevent someone messes with my EXE when it's running
		static FileStream myStream = 
			new FileStream(Application.ExecutablePath, FileMode.Open, FileAccess.Read);
		// If not IntPtr.Zero, will not show Complain but will SendMessage() to it
		static IntPtr hLogTarget = IntPtr.Zero;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			// Load default settings if settings.xml can't be loaded
			try
			{
				LoadSettings(File.ReadAllText(Program.SettingsPath, Encoding.UTF8));
			}
			catch (Exception)
			{
				LoadSettings(Properties.Resources.defaultSettings);
			}
			if (Environment.OSVersion.Version.Major < 6)
			{
				MessageBox.Show(MUI.GetText("Common.BadOS"),
					MUI.GetText("Common.Error_title"),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(1);
			}
			SuperCore.Complain += new SuperCore.ComplainHandler(SuperCore_Complain);
			ParseCmdLine(args);
			if (beDPIaware) Win32.SetProcessDPIAware();
			Application.ApplicationExit += new EventHandler(OnApplicationExit);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}

		static void OnApplicationExit(object sender, EventArgs e)
		{
			SaveSettings();
		}

		static void SuperCore_Complain(SuperCore.ComplainReason reason, string obj)
		{
			string msg = "";
			switch (reason)
			{
				case SuperCore.ComplainReason.FileNotFound:
					msg = MUI.GetText("Common.FileNotFound"); break;
				case SuperCore.ComplainReason.FileNotExe:
					msg = MUI.GetText("Common.FileNotExe"); break;
				case SuperCore.ComplainReason.CantGetPID:
					msg = MUI.GetText("Common.CantGetPID"); break;
				case SuperCore.ComplainReason.APICallFailed:
					msg = MUI.GetText("Common.APICallFailed");
					break;
				default: break;
			}
			msg = msg.Replace("%1", obj);
			LastComplain = msg;
		}

		public static bool LoadSettings(string xmlText)
		{
			try
			{
				XmlDocument xmlDoc = new XmlDocument();
				xmlDoc.LoadXml(xmlText);
				XmlNode root = xmlDoc.SelectSingleNode("SuperCMD");
				foreach (XmlAttribute attr in root.Attributes)
				{
					string attrName = attr.Name.ToLower();
					if (attrName == "dpiaware") Program.beDPIaware = bool.Parse(attr.Value);
					if (attrName == "w31ui") Program.beClassic = bool.Parse(attr.Value);
					if (attrName == "lang")
					{
						if (!MUI.TrySetLangByName(attr.Value)) RevertFallbackLangFrom(attr.Value);
					}
				}
				XmlNodeList Q_nodes = root.SelectNodes("QLaunch/Q");
				foreach (XmlNode Q_node in Q_nodes)
				{
					int i = int.Parse(Q_node.Attributes["index"].Value);
					if (i < 1 | i > 9) continue;
					Q q = new Q();
					foreach (XmlAttribute attr in Q_node.Attributes)
					{
						string attrName = attr.Name.ToLower();
						if (attrName == "name") q.Name = attr.Value;
						if (attrName == "exe") q.ExeToRun = attr.Value;
						if (attrName == "args") q.Arguments = attr.Value;
						if (attrName == "dir") q.WorkingDir = attr.Value;
						if (attrName == "ti") q.UseTItoken = bool.Parse(attr.Value);
					}
					Qs[i - 1] = q;
				}
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public static bool SaveSettings()
		{
			try
			{
				using (StreamWriter writer =
					new StreamWriter(Program.SettingsPath, false, Encoding.UTF8))
				{
					XmlDocument xmlDoc = new XmlDocument();
					XmlElement root = xmlDoc.CreateElement("SuperCMD");
					root.SetAttribute("DPIaware", Program.beDPIaware.ToString());
					root.SetAttribute("W31UI", Program.beClassic.ToString());
					root.SetAttribute("Lang", MUI.GetCurrentLangName());
					root.SetAttribute("Ver", Program.Ver);
					XmlElement Q_nodes = xmlDoc.CreateElement("QLaunch");
					for (int i = 0; i <= 8; i++)
					{
						Q q = Qs[i];
						XmlElement Q_node = xmlDoc.CreateElement("Q");
						Q_node.SetAttribute("index", (i + 1).ToString());
						if (q.Name != "") Q_node.SetAttribute("name", q.Name);
						if (q.ExeToRun != "") Q_node.SetAttribute("exe", q.ExeToRun);
						if (q.Arguments != "") Q_node.SetAttribute("args", q.Arguments);
						if (q.WorkingDir != "") Q_node.SetAttribute("dir", q.WorkingDir);
						if (!q.UseTItoken) Q_node.SetAttribute("ti", "False");
						Q_nodes.AppendChild(Q_node);
					}
					root.AppendChild(Q_nodes);
					xmlDoc.AppendChild(root);
					xmlDoc.Save(writer);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(
					MUI.GetText("Common.SaveSettingsFailed") + "\n\n" + ex.Message,
					MUI.GetText("Common.Error_title"),
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		static void ParseCmdLine(string[] args)
		{
			string ExeToRun = "", Arguments = "", WorkingDir = "";
			string toRun = "", tokenProcessName = "";
			int tokenPID = -1;
			bool metTI = false, metSilent = false, metShowWait = false;
			bool metChangeToActiveSessionID = false;
			// args[] can't process DirPath and ExeToRun containing '\'
			// and that will influence the other argument too :(
			// so I need to do it myself :/
			string CmdLine = Environment.CommandLine;
			int iToRun = CmdLine.ToLower().IndexOf("/run:");
			if (iToRun != -1)
			{
				toRun = CmdLine.Substring(iToRun + 5).Trim();
				// Process toRun
				int iDQuote1, iDQuote2;
				iDQuote1 = toRun.IndexOf("\"");
				// If a pair of double quote is exist
				if (iDQuote1 != -1)
				{
					toRun = toRun.Substring(iDQuote1 + 1);
					iDQuote2 = toRun.IndexOf("\"");
					if (iDQuote2 != -1)
					{
						// before 2nd double quote is ExeToRun, after is Arguments
						ExeToRun = toRun.Substring(0, iDQuote2);
						Arguments = toRun.Substring(iDQuote2 + 1);
					}
				}
				else
				{
					// before 1st Space is ExeToRun, after is Arguments
					int firstSpace = toRun.IndexOf(" ");
					if (firstSpace == -1) { ExeToRun = toRun; }
					else
					{
						ExeToRun = toRun.Substring(0, firstSpace);
						Arguments = toRun.Substring(firstSpace + 1);
					}
				}
			}
			// Process all optional arguments before toRun, '/' as separator
			if (iToRun != -1) CmdLine = CmdLine.Substring(0, iToRun) + "/";
			string cmdline = CmdLine.ToLower();
			if (cmdline.Contains("/debug"))
			{
				DebugMode = true; Title += " Debug";
			}
			// Only /debug affects GUI mode, others are only for command line usage
			// So if no '/run' then no need to go on
			if (iToRun == -1) return;
			if (cmdline.Contains("/ti")) metTI = true;
			if (cmdline.Contains("/silent")) metSilent = true;
			if (cmdline.Contains("/showwait")) metShowWait = true;
			if (cmdline.Contains("/changetoactivesessionid")) metChangeToActiveSessionID = true;

			string tmp;
			int iWithTokenOf, iWithTokenOfPID, iSendLogTo, iDir, iNextSlash;
			iWithTokenOf = cmdline.IndexOf("/withtokenof:");
			if (iWithTokenOf != -1)
			{
				tmp = CmdLine.Substring(iWithTokenOf + 13);
				iNextSlash = tmp.IndexOf("/");
				if (iNextSlash != -1)
				{
					tmp = tmp.Substring(0, iNextSlash);
					tokenProcessName = tmp.Replace("\"", "").Trim();
				}
			}
			iWithTokenOfPID = cmdline.IndexOf("/withtokenofpid:");
			if (iWithTokenOfPID != -1)
			{
				tmp = CmdLine.Substring(iWithTokenOfPID + 16);
				iNextSlash = tmp.IndexOf("/");
				if (iNextSlash != -1)
				{
					tmp = tmp.Substring(0, iNextSlash);
					tmp = tmp.Replace("\"", "").Trim();
					int.TryParse(tmp, out tokenPID);
				}
			}
			iSendLogTo = cmdline.IndexOf("/sendlogto:");
			if (iSendLogTo != -1)
			{
				tmp = CmdLine.Substring(iSendLogTo + 11);
				iNextSlash = tmp.IndexOf("/");
				if (iNextSlash != 1)
				{
					tmp = tmp.Substring(0, iNextSlash);
					tmp = tmp.Replace("\"", "").Trim();
					long h;
					if (long.TryParse(tmp, out h)) hLogTarget = new IntPtr(h);
				}
			}
			iDir = cmdline.IndexOf("/dir:");
			if (iDir != -1)
			{
				tmp = CmdLine.Substring(iDir + 5);
				iNextSlash = tmp.IndexOf("/");
				if (iNextSlash != -1)
				{
					tmp = tmp.Substring(0, iNextSlash);
					WorkingDir = tmp.Replace("\"", "").Trim();
				}
			}
			// Run...
			SuperCore.ForceTokenUseActiveSessionID = metChangeToActiveSessionID;
			if (metTI)
			{
				frmWait WaitUI = new frmWait();
				if (metShowWait) WaitUI.ShowIfNeeded();
				if (StartTiService())
				{
					SuperCore.RunWithTokenOf("winlogon.exe", true,
						Application.ExecutablePath,
						"/WithTokenOf:TrustedInstaller.exe" +
						" /ForceUseActiveSessionID" +
						(metSilent ? " /Silent" : "") +
						(DebugMode ? " /Debug" : "") +
						" /Dir:\"" + WorkingDir + "\" " +
						" /Run:\"" + ExeToRun + "\" " + Arguments);
				}
				WaitUI.Hide();
			}
			else
			{
				if (tokenProcessName != "")
				{
				    SuperCore.RunWithTokenOf(tokenProcessName, false,
						ExeToRun, Arguments, WorkingDir);
				}
				else if (tokenPID > 0)
				{
				    SuperCore.RunWithTokenOf(tokenPID, ExeToRun, Arguments, WorkingDir);
				}
				else
				{
					SuperCore.RunWithTokenOf("winlogon.exe", true,
						ExeToRun, Arguments, WorkingDir);
				}
			}
			ComplainAndLog();
			Environment.Exit((LastComplain != "") ? 1 : 0);
		}

		public static void RevertFallbackLangFrom(string BadLangName)
		{
			MessageBox.Show(
				"Can't find language XML for '" + BadLangName + "'.\n" +
				"Reverting back to fallback language (English).",
				"Missing Lang XML", MessageBoxButtons.OK, MessageBoxIcon.Information);
			MUI.TrySetLangByIndex(0);
		}

		public static bool StartTiService()
		{
			try
			{
				Win32.TryStartService("TrustedInstaller");
				return true;
			}
			catch (Exception)
			{
				LastComplain = MUI.GetText("Common.CantStartTI") +
					"\n\n" + Win32.WinAPILastErrMsg();
				return false;
			}
		}

		public static void OfferCreateLnk(Q q)
		{
			SaveFileDialog sfd = new SaveFileDialog();
			sfd.FileName = q.Name;
			sfd.Filter = MUI.GetText("Common.FileType_LNK") + "|*.lnk";
			sfd.OverwritePrompt = true;
			if (sfd.ShowDialog() == DialogResult.OK)
			{
				string args = "/ShowWait ";
				args += (q.UseTItoken ? "/TI " : "");
				args += (q.WorkingDir != "") ?
					"/Dir:\"" + q.WorkingDir + "\" " : "";
				args += "/Run:\"" + q.ExeToRun + "\" " + q.Arguments;
				ShellLink lnk = new ShellLink(sfd.FileName);
				lnk.Path = Application.ExecutablePath;
				lnk.Arguments = args;
				lnk.IconPath = q.ExeToRun;
				int err = lnk.Save();
				if (err == 0)
				{
					MessageBox.Show(MUI.GetText("Common.CreateLnkOK"),
						MUI.GetText("Common.OK_title"),	
						MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(MUI.GetText("Common.CreateLnkFailed") +
						"\n\n" + Win32.WinAPILastErrMsg(err),
						MUI.GetText("Common.Error_title"),	
						MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		public static void OfferToggleDebug()
		{
			if (Program.DebugMode)
			{
				if (MessageBox.Show("Exit debug mode?", "SuperCMD Debug",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Process.Start(Application.ExecutablePath);
					Application.Exit();
				}
			}
			else
			{
				if (MessageBox.Show("Enter debug mode?", "SuperCMD Debug",
					MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Process.Start(Application.ExecutablePath, "/debug");
					Application.Exit();
				}
			}
		}

		public static void ComplainAndLog()
		{
			if (DebugMode)
			{
				MessageBox.Show(SuperCore.Log, "SuperCMD Log",
					MessageBoxButtons.OK, (LastComplain != "") ?
					MessageBoxIcon.Error : MessageBoxIcon.Information);
			}
			else if (LastComplain != "")
			{
				if (hLogTarget != IntPtr.Zero)
				{
					Win32._SendMessage(LastComplain, hLogTarget);
				}
				else
				{
					MessageBox.Show(LastComplain, MUI.GetText("Common.Error_title"),
					   MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				LastComplain = "";
			}
		}

		public static class ContextMenuIntegration
		{
			public static bool RunAsSYSTEM
			{
				get
				{
					foreach (string ext in new string[] {"exefile", "batfile", "cmdfile"})
					{
						string KeyPath = "Software\\Classes\\" + ext + "\\shell\\runasSYSTEM";
						if (Registry.CurrentUser.OpenSubKey(KeyPath) == null) return false;
					}
					return true;
				}
				set
				{
					foreach (string ext in new string[] { "exefile", "batfile", "cmdfile" })
					{
						string KeyPath = "Software\\Classes\\" + ext + "\\shell\\runasSYSTEM";
						RegistryKey Key;
						if (value)
						{
							Key = Registry.CurrentUser.CreateSubKey(KeyPath);
							Key.SetValue("", MUI.GetText("ContextMenuIntegration.RunAsSYSTEM"));
							Key.SetValue("MultiSelectModel", "Single");
							Key.SetValue("Icon", Application.ExecutablePath);
							Key = Key.CreateSubKey("command");
							Key.SetValue("", "\"" + Application.ExecutablePath + "\""
								+ " /ShowWait /Run:\"%1\" %*");
						}
						else
						{
							Key = Registry.CurrentUser.OpenSubKey(KeyPath, true);
							if (Key != null) Registry.CurrentUser.DeleteSubKeyTree(KeyPath);
						}
					}
				}
			}

			public static bool RunAsSYSTEM_TI
			{
				get
				{
					foreach (string ext in new string[] { "exefile", "batfile", "cmdfile" })
					{
						string KeyPath = "Software\\Classes\\" + ext + "\\shell\\runasSYSTEM_TI";
						if (Registry.CurrentUser.OpenSubKey(KeyPath) == null) return false;
					}
					return true;
				}
				set
				{
					foreach (string ext in new string[] { "exefile", "batfile", "cmdfile" })
					{
						string KeyPath = "Software\\Classes\\" + ext + "\\shell\\runasSYSTEM_TI";
						RegistryKey Key;
						if (value)
						{
							Key = Registry.CurrentUser.CreateSubKey(KeyPath);
							Key.SetValue("", MUI.GetText("ContextMenuIntegration.RunAsSYSTEM_TI"));
							Key.SetValue("MultiSelectModel", "Single");
							Key.SetValue("Icon", Application.ExecutablePath);
							Key = Key.CreateSubKey("command");
							Key.SetValue("", "\"" + Application.ExecutablePath + "\""
								+ " /TI /ShowWait /Run:\"%1\" %*");
						}
						else
						{
							Key = Registry.CurrentUser.OpenSubKey(KeyPath, true);
							if (Key != null) Registry.CurrentUser.DeleteSubKeyTree(KeyPath);
						}
					}
				}
			}

		}

	}
}
