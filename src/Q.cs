using System;
using System.Collections.Generic;

namespace SuperCMD
{
	public class Q
	{
		public string Name = "", ExeToRun = "", Arguments = "", WorkingDir = "";
		public bool UseTItoken = true;

		public override string ToString()
		{
			string n = Environment.NewLine;
			string s = "";
			if (Name != "")	s += MUI.GetText("frmQEditor.lblName") + Name + n;
			s += MUI.GetText("frmQEditor.lblProgramPath") + ExeToRun + n;
			s += MUI.GetText("frmQEditor.lblArguments") + Arguments + n;
			s += MUI.GetText("frmQEditor.grpWorkingDir") +
				((WorkingDir == "") ? "<AUTO>" : WorkingDir) + n;
			s += "TrustedInstaller: " + UseTItoken.ToString() + n;
			return s;
		}
	}
}
