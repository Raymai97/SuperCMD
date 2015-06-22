using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Xml;

namespace SuperCMD
{
	public static class MUI
	{
		
		static List<Lang> LangList = new List<Lang>();
		static Lang CurrentLang;

		public static frmMain MainUI;
		public static frmConfig ConfigUI;
		public static frmQEditor QEditorUI;

		static MUI()
		{
			RefreshLangList();
			CurrentLang = LangList[0];
		}

		public static List<string> GetLangDispNameList()
		{
			List<string> List = new List<string>();
			foreach (Lang lang in LangList)
			{
				List.Add(lang.DispName);
			}
			return List;
		}

		public static string GetCurrentLangName()
		{
			return CurrentLang.Name;
		}

		public static int GetCurrentLangIndex()
		{
			// Cannot use IndexOf becuz it will not work after RefreshLangList()
			for (int i = 0; i <= LangList.Count - 1; i++)
			{
				if (LangList[i].Name.ToLower() == 
					CurrentLang.Name.ToLower()) return i;
			}
			return -1;
		}

		public static string GetText(string key)
		{
			string value;
			if (!CurrentLang.Strs.TryGetValue(key, out value))
			{
				MessageBox.Show(
					"Can't find text for '" + key + "' in current language.\n" +
					"Will use fallback language (English) instead.",
					"Missing text", MessageBoxButtons.OK, MessageBoxIcon.Information);
				CurrentLang = LangList[0];
				if (!CurrentLang.Strs.TryGetValue(key, out value))
				{
					MessageBox.Show(
						"Can't find text for '" + key + "' even in fallback language!\n" +
						"Application will exit!", "CRITICAL ERROR",
						MessageBoxButtons.OK, MessageBoxIcon.Error);
					Environment.Exit(1);
				}
			}
			return value;
		}

		public static bool TrySetLangByName(string LangName)
		{
			foreach (Lang lang in LangList)
			{
				if (lang.Name.ToLower() == LangName.ToLower())
				{
					CurrentLang = lang;
					return true;
				}
			}
			return false;
		}

		public static bool TrySetLangByIndex(int i)
		{
			try
			{
				CurrentLang = LangList[i];
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static void RefreshLangList()
		{
			LangList.Clear();
			// No matter what, English must always be available
			LangList.Add(XmlToLang(Properties.Resources.defaultLanguage));
			// Load external Language XML if possible
			if (!Directory.Exists(Program.MUIDirPath)) return;
			foreach (string file in Directory.GetFiles(Program.MUIDirPath))
			{
				try
				{
					Lang lang = XmlToLang(
						File.ReadAllText(file, Encoding.UTF8)
						);
					LangList.Add(lang);
				}
				catch (Exception)
				{ }
			}
		}

		public static void RefreshFrmLang()
		{
			foreach (KeyValuePair<string,string> item in CurrentLang.Strs)
			{
				SetFrmCtrlText(MainUI, item.Key, item.Value);
				SetFrmCtrlText(QEditorUI, item.Key, item.Value);
				SetFrmCtrlText(ConfigUI, item.Key, item.Value);
				SetMenuText(MainUI.mnuQEdit, item.Key, item.Value);
				SetMenuText(QEditorUI.mnuQEdit, item.Key, item.Value);
				if (item.Key == "Common.UseTIToken")
				{
					foreach (CheckBox chk in new CheckBox[]{
						MainUI.chkTI, MainUI.chkTI_quick, QEditorUI.chkTI})
					{
						chk.Text = item.Value;
						chk.Left = (chk.Parent.Width - chk.Width) / 2;
					}
				}
			}
		}

		static void SetFrmCtrlText(Form frm, string key, string value)
		{
			if (key.StartsWith(frm.Name + "."))
			{
				string ctrlName = key.Substring(key.IndexOf(".") + 1);
				Control[] _ = frm.Controls.Find(ctrlName, true);
				if (_.Length > 0)
				{
					_[0].Text = value;
				}
				else if (ctrlName == "TITLE")
				{
					frm.Text = value;
				}
			}
		}

		static void SetMenuText(ContextMenuStrip mnu, string key, string value)
		{
			if (key.StartsWith(mnu.Name + "."))
			{
				string itemName = key.Substring(key.IndexOf(".") + 1);
				ToolStripItem[] _ = mnu.Items.Find(itemName, true);
				if (_.Length > 0) _[0].Text = value;
			}
		}

		static Lang XmlToLang(string XmlText)
		{
			XmlText = XmlText.Replace("\\n", "&#xD;&#xA;");
			XmlDocument XmlDoc = new XmlDocument();
			XmlDoc.LoadXml(XmlText);
			XmlNode root = XmlDoc.SelectSingleNode("SuperCMD_Lang");
			Lang lang = new Lang(root.Attributes["Name"].Value,
				root.Attributes["DispName"].Value);
			foreach (XmlNode node in root.ChildNodes)
			{
				foreach (XmlAttribute attr in
					root.SelectSingleNode(node.Name).Attributes)
				{
					lang.Strs.Add(node.Name + "." + attr.Name, attr.Value);
				}
			}
			return lang;
		}

		public class Lang
		{
			public Dictionary<string, string> Strs;
			public string Name, DispName;

			public Lang(string Name, string DispName)
			{
				this.Name = Name;
				this.DispName = DispName;
				Strs = new Dictionary<string,string>();
			}
		
		}

	}
}
