/* SuperCore.cs of SuperCMD v2.1 by MaiSoft (Raymai97)

   Run a program with token of a running process.
  
   To get TrustedInstaller token, you must run as SYSTEM first, and then
   RunWithTokenOf("TrustedInstaller.exe", ...)
      
   This class is designed to be as portable as possible.

   This class has a Log system.
   Capture the Log message via SuperCore.Log() in a try-catch statement.
   Don't forget to call SuperCore.ClearLog() after you're done.
  
   This class also has a Complain system.
   The "Complain" event has "reason" which is a ComplainReason (enum),
   and "obj" that tells the related object to this error.
   For example, ComplainReason.FileNotFound, obj is C:\troll.txt, means
   C:\troll.txt is a troll; it doesn't exist.
  
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace SuperCMD
{
	class SuperCore
	{

		#region WIN32 API 

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool CloseHandle(IntPtr hObject);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr GetCurrentProcess();

		[DllImport("kernel32.dll")]
		static extern uint WTSGetActiveConsoleSessionId();

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool AdjustTokenPrivileges(
			IntPtr TokenHandle,
			bool DisableAllPrivileges,
			[MarshalAs(UnmanagedType.Struct)] ref TOKEN_PRIVILEGES NewState,
			uint dummy, IntPtr dummy2, IntPtr dummy3);

		[StructLayout(LayoutKind.Sequential)]
		private struct TOKEN_PRIVILEGES
		{
			internal uint PrivilegeCount;
			internal LUID Luid;
			internal uint Attrs;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct LUID
		{
			internal int LowPart;
			internal uint HighPart;
		}

		const uint SE_PRIVILEGE_ENABLED = 0x00000002;

		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool LookupPrivilegeValue(string lpSystemName, string lpName,
			out LUID lpLuid);

		[DllImport("kernel32.dll")]
		static extern IntPtr OpenProcess(
			 ProcessAccessFlags dwDesiredAccess,
			 bool bInheritHandle,
			 int processId
		);

		[Flags]
		enum ProcessAccessFlags : uint
		{
			All = 0x001F0FFF,
			Terminate = 0x00000001,
			CreateThread = 0x00000002,
			VirtualMemoryOperation = 0x00000008,
			VirtualMemoryRead = 0x00000010,
			VirtualMemoryWrite = 0x00000020,
			DuplicateHandle = 0x00000040,
			CreateProcess = 0x000000080,
			SetQuota = 0x00000100,
			SetInformation = 0x00000200,
			QueryInformation = 0x00000400,
			QueryLimitedInformation = 0x00001000,
			Synchronize = 0x00100000
		}

		[DllImport("advapi32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool OpenProcessToken(IntPtr ProcessHandle,
			uint DesiredAccess, out IntPtr TokenHandle);

		const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;
		const uint STANDARD_RIGHTS_READ = 0x00020000;
		const uint TOKEN_ASSIGN_PRIMARY = 0x0001;
		const uint TOKEN_DUPLICATE = 0x0002;
		const uint TOKEN_IMPERSONATE = 0x0004;
		const uint TOKEN_QUERY = 0x0008;
		const uint TOKEN_QUERY_SOURCE = 0x0010;
		const uint TOKEN_ADJUST_PRIVILEGES = 0x0020;
		const uint TOKEN_ADJUST_GROUPS = 0x0040;
		const uint TOKEN_ADJUST_DEFAULT = 0x0080;
		const uint TOKEN_ADJUST_SESSIONID = 0x0100;
		const uint TOKEN_READ = (STANDARD_RIGHTS_READ | TOKEN_QUERY);
		const uint TOKEN_ALL_ACCESS = (STANDARD_RIGHTS_REQUIRED | TOKEN_ASSIGN_PRIMARY |
			TOKEN_DUPLICATE | TOKEN_IMPERSONATE | TOKEN_QUERY | TOKEN_QUERY_SOURCE |
			TOKEN_ADJUST_PRIVILEGES | TOKEN_ADJUST_GROUPS | TOKEN_ADJUST_DEFAULT |
			TOKEN_ADJUST_SESSIONID);

		[DllImport("advapi32.dll", SetLastError = true)]
		static extern Boolean SetTokenInformation(IntPtr TokenHandle, uint TokenInformationClass,
			ref uint TokenInformation, uint TokenInformationLength);

		const uint TOKEN_INFORMATION_CLASS_TokenSessionId = 12;

		[DllImport("userenv.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, IntPtr hToken, bool bInherit);

		[DllImport("userenv.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);

		[DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern bool CreateProcessAsUserW(
			IntPtr hToken,
			string lpApplicationName,
			string lpCommandLine,
			ref SECURITY_ATTRIBUTES lpProcessAttributes,
			ref SECURITY_ATTRIBUTES lpThreadAttributes,
			bool bInheritHandles,
			uint dwCreationFlags,
			IntPtr lpEnvironment,
			string lpCurrentDirectory,
			ref STARTUPINFO lpStartupInfo,
			out PROCESSINFO lpProcessInformation);

		[StructLayout(LayoutKind.Sequential)]
		private struct SECURITY_ATTRIBUTES
		{
			public int nLength;
			public IntPtr lpSecurityDescriptor;
			public int bInheritHandle;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		private struct STARTUPINFO
		{
			public int cb;
			public string lpReserved;
			public string lpDesktop;
			public string lpTitle;
			public int dwX;
			public int dwY;
			public int dwXSize;
			public int dwYSize;
			public int dwXCountChars;
			public int dwYCountChars;
			public int dwFillAttribute;
			public int dwFlags;
			public Int16 wShowWindow;
			public Int16 cbReserved2;
			public IntPtr lpReserved2;
			public IntPtr hStdInput;
			public IntPtr hStdOutput;
			public IntPtr hStdError;
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct PROCESSINFO
		{
			public IntPtr hProcess;
			public IntPtr hThread;
			public int dwProcessId;
			public int dwThreadId;
		}

		[DllImport("advapi32", SetLastError = true, CharSet = CharSet.Unicode)]
		static extern bool CreateProcessWithTokenW(
			IntPtr hToken, 
			LogonFlags dwLogonFlags, 
			string lpApplicationName, 
			string lpCommandLine, 
			uint dwCreationFlags, 
			IntPtr lpEnvironment, 
			string lpCurrentDirectory, 
			[In] ref STARTUPINFO lpStartupInfo, 
			out PROCESSINFO lpProcessInformation);

		enum LogonFlags
		{
			WithProfile = 1,
			NetCredentialsOnly
		}

		const uint NORMAL_PRIORITY_CLASS = 0x00000020;
		const uint CREATE_NEW_CONSOLE = 0x00000010;
		const uint CREATE_UNICODE_ENVIRONMENT = 0x00000400;

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		extern static bool DuplicateTokenEx(
			IntPtr hExistingToken,
			uint dwDesiredAccess,
			ref SECURITY_ATTRIBUTES lpTokenAttributes,
			SecurityImpersonationLevel ImpersonationLevel,
			TokenType TokenType,
			out IntPtr phNewToken);

		enum SecurityImpersonationLevel
		{
			SecurityAnonymous = 0,
			SecurityIdentification = 1,
			SecurityImpersonation = 2,
			SecurityDelegation = 3
		}

		enum TokenType
		{
			TokenPrimary = 1,
			TokenImpersonation
		}

		#endregion

		#region Log System 

		private static string _Log;
		public static string Log
		{
			get
			{
				return _Log;
			}
			private set
			{
				_Log = value + Environment.NewLine;
			}
		}

		public static void ClearLog()
		{
			_Log = "";
		}

		private static void EndLog()
		{
			Log += " ---- end of log : " + DateTime.Now.ToString("d MMM yyyy hh:mm:ss tt") + " ---- ";
		}

		private static void LogErr(string msg, bool cleanup = true)
		{
			if (cleanup) CleanUp();
			Log += msg;
			EndLog();
		}

		#endregion

		#region Complain System 

		public enum ComplainReason
		{
			FileNotFound,
			FileNotExe,
			CantGetPID,
			APICallFailed
		}

		public delegate void ComplainHandler(ComplainReason reason, string obj);

		public static event ComplainHandler Complain;

		static bool plsThrow = false;

		static void GoComplain(ComplainReason reason, string obj)
		{
			switch (reason)
			{
				case ComplainReason.FileNotFound:
					LogErr("ExeToRun is not an existing file!"); break;
				case ComplainReason.FileNotExe:
					LogErr("ExeToRun is not an executable file!"); break;
				case ComplainReason.CantGetPID:
					LogErr("Can't get the PID of: " + obj); break;
				case ComplainReason.APICallFailed:
					obj += ": " + WinAPILastErrMsg();
					LogErr(obj); break;
				default: LogErr("");  break;
			}
			Complain.Invoke(reason, obj);
			if (plsThrow)
			{
				plsThrow = false;
				throw new Exception();
			}
		}

		#endregion

		public static bool ForceTokenUseActiveSessionID = false;

		static STARTUPINFO SI;
		static PROCESSINFO PI;
		static SECURITY_ATTRIBUTES dummySA = new SECURITY_ATTRIBUTES();
		static IntPtr hProc, hToken, hDupToken, pEnvBlock;

		// Run with the token of the first process with the name of ProcessName
		public static void RunWithTokenOf(
			string ProcessName,
			bool OfActiveSessionOnly,
			string ExeToRun, 
			string Arguments,
			string WorkingDir = "")
		{
			List<int> PIDs = new List<int>();
			foreach (Process p in Process.GetProcessesByName(
				Path.GetFileNameWithoutExtension(ProcessName)))
			{
				if (OfActiveSessionOnly)
				{
					if (p.SessionId == WTSGetActiveConsoleSessionId())
						PIDs.Add(p.Id);
				}
				else
				{
					PIDs.Add(p.Id);
				}
			}
			if (PIDs.Count == 0)
			{
				GoComplain(ComplainReason.CantGetPID, ProcessName);
				return;
			}
			RunWithTokenOf(PIDs[0], ExeToRun, Arguments, WorkingDir);
		}

		public static void RunWithTokenOf(
			int ProcessID,
			string ExeToRun,
			string Arguments,
			string WorkingDir = "")
		{
			plsThrow = true;
			try
			{
				#region Process ExeToRun, Arguments and WorkingDir
				// If ExeToRun is not absolute path, then let it be
				ExeToRun = Environment.ExpandEnvironmentVariables(ExeToRun);
				if (!ExeToRun.Contains("\\"))
				{
					foreach (string path in Environment.ExpandEnvironmentVariables("%path%").Split(';'))
					{
						string guess = path + "\\" + ExeToRun;
						if (File.Exists(guess)) { ExeToRun = guess; break; }
					}
				}
				if (!File.Exists(ExeToRun)) GoComplain(ComplainReason.FileNotFound, ExeToRun);
				// If WorkingDir not exist, let it be the dir of ExeToRun
				// ExeToRun no dir? Impossible, as I would GoComplain() already
				WorkingDir = Environment.ExpandEnvironmentVariables(WorkingDir);
				if (!Directory.Exists(WorkingDir)) WorkingDir = Path.GetDirectoryName(ExeToRun);
				// If arguments exist, CmdLine must include ExeToRun as well
				Arguments = Environment.ExpandEnvironmentVariables(Arguments);
				string CmdLine = null;
				if (Arguments != "")
				{
					if (ExeToRun.Contains(" "))
					{
						CmdLine = "\"" + ExeToRun + "\" " + Arguments;
					}
					else
					{
						CmdLine = ExeToRun + " " + Arguments;
					}
				}
				#endregion

				string obj;
				Log += "Running as user: " + Environment.UserName; 
				// Set privileges of current process
				string privs = "SeDebugPrivilege";
				obj = "OpenProcessToken";
				if (!OpenProcessToken(GetCurrentProcess(), TOKEN_ALL_ACCESS, out hToken))
				{
					GoComplain(ComplainReason.APICallFailed, obj);
				}
				foreach (string priv in privs.Split(','))
				{
					obj = "LookupPrivilegeValue (" + priv + ")";
					LUID Luid;
					if (!LookupPrivilegeValue("", priv, out Luid))
					{
						GoComplain(ComplainReason.APICallFailed, obj);
					}
					obj = "AdjustTokenPrivileges (" + priv + ")";
					TOKEN_PRIVILEGES TP = new TOKEN_PRIVILEGES();
					TP.PrivilegeCount = 1;
					TP.Luid = Luid;
					TP.Attrs = SE_PRIVILEGE_ENABLED;
					if (AdjustTokenPrivileges(hToken, false, ref TP, 0, IntPtr.Zero, IntPtr.Zero)
						& Marshal.GetLastWin32Error() == 0)
					{
						Log += obj + ": OK!";
					}
					else
					{
						GoComplain(ComplainReason.APICallFailed, obj);
					}
				}
				CloseHandle(hToken);
				// Open process by PID
				obj = "OpenProcess (PID: " + ProcessID.ToString() + ")";
				hProc = OpenProcess(ProcessAccessFlags.All, false, ProcessID);
				if (hProc == null)
				{
					GoComplain(ComplainReason.APICallFailed, obj);
				}
				Log += obj + ": OK!";
				// Open process token
				obj = "OpenProcessToken (TOKEN_DUPLICATE | TOKEN_QUERY)";
				if (!OpenProcessToken(hProc, TOKEN_DUPLICATE | TOKEN_QUERY, out hToken))
				{
					GoComplain(ComplainReason.APICallFailed, obj);
				}
				Log += obj + ": OK!";
				// Duplicate to hDupToken
				obj = "DuplicateTokenEx (TOKEN_ALL_ACCESS)";
				if (!DuplicateTokenEx(hToken, TOKEN_ALL_ACCESS, ref dummySA,
					SecurityImpersonationLevel.SecurityIdentification,
					TokenType.TokenPrimary, out hDupToken))
				{
					GoComplain(ComplainReason.APICallFailed, obj);
				}
				Log += obj + ": OK!";
				// Set session ID to make sure it shows in current user desktop
				// Only possible when SuperCMD running as SYSTEM!
				if (ForceTokenUseActiveSessionID)
				{
					obj = "SetTokenInformation (toActiveSessionID)";
					uint SID = WTSGetActiveConsoleSessionId();
					if (!SetTokenInformation(hDupToken, TOKEN_INFORMATION_CLASS_TokenSessionId, ref SID, (uint)sizeof(uint)))
					{
						GoComplain(ComplainReason.APICallFailed, obj);
					}
					Log += obj + ": OK!";
				}
				// Create environment block
				obj = "CreateEnvironmentBlock";
				if (!CreateEnvironmentBlock(out pEnvBlock, hToken, true))
				{
					GoComplain(ComplainReason.APICallFailed, obj);
				}
				Log += obj + ": OK!\n";
				// Create process with the token we "stole" ^^
				uint dwCreationFlags = (NORMAL_PRIORITY_CLASS | CREATE_NEW_CONSOLE | CREATE_UNICODE_ENVIRONMENT);
				SI = new STARTUPINFO();
				SI.cb = Marshal.SizeOf(SI);
				SI.lpDesktop = "winsta0\\default";
				PI = new PROCESSINFO();
				// CreateProcessWithTokenW doesn't work in Safe Mode
				// CreateProcessAsUserW works, but if the Session ID is different,
				// we need to set it via SetTokenInformation()
				obj = "CreateProcessWithTokenW";
				if (CreateProcessWithTokenW(hDupToken, LogonFlags.WithProfile, ExeToRun, CmdLine,
					dwCreationFlags, pEnvBlock, WorkingDir, ref SI, out PI))
				{
					Log += "CreateProcessWithTokenW: Done! New process created successfully!";
				}
				else
				{
					Log += "CreateProcessWithTokenW: " + WinAPILastErrMsg();
					Log += "\nTrying CreateProcessAsUserW instead.";
					obj = "CreateProcessAsUserW";
					if (CreateProcessAsUserW(hDupToken, ExeToRun, CmdLine, ref dummySA, ref dummySA,
						false, dwCreationFlags, pEnvBlock, WorkingDir, ref SI, out PI))
					{
						Log += obj + ": Done! New process created successfully!";
					}
					else
					{
						switch (Marshal.GetLastWin32Error())
						{
							case 3:
								GoComplain(ComplainReason.FileNotFound, ExeToRun); break;
							case 193:
								GoComplain(ComplainReason.FileNotExe, ExeToRun); break;
							default:
								GoComplain(ComplainReason.APICallFailed, obj); break;
						}
					}
				}
				Log += "Process name: " + Path.GetFileName(ExeToRun);
				Log += "Process ID: " + PI.dwProcessId;
				CleanUp();
				EndLog();
			}
			catch (Exception)
			{}
		}

		static void CleanUp()
		{
			CloseHandle(SI.hStdError); SI.hStdError = IntPtr.Zero;
			CloseHandle(SI.hStdInput); SI.hStdInput = IntPtr.Zero;
			CloseHandle(SI.hStdOutput); SI.hStdOutput = IntPtr.Zero;
			CloseHandle(PI.hThread); PI.hThread = IntPtr.Zero;
			CloseHandle(PI.hProcess); PI.hThread = IntPtr.Zero;
			DestroyEnvironmentBlock(pEnvBlock); pEnvBlock = IntPtr.Zero;
			CloseHandle(hDupToken); hDupToken = IntPtr.Zero;
			CloseHandle(hToken); hToken = IntPtr.Zero;
		}

		static string WinAPILastErrMsg()
		{
			int err = Marshal.GetLastWin32Error();
			return new Win32Exception(err).Message + " (Error code: " + err + ")";
		}


	}
}
