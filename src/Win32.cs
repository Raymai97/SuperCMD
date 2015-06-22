using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace SuperCMD
{
	class Win32
	{

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetProcessDPIAware();

		[DllImport("shell32.dll", CharSet = CharSet.Auto)]
		public static extern uint ExtractIconEx(string szFileName, int nIconIndex,
		   IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons);

		#region SendMessage API

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, ref COPYDATASTRUCT lParam);
		[DllImport("user32.dll")]
		public static extern bool InSendMessage();
		[DllImport("user32.dll")]
		public static extern bool ReplyMessage(IntPtr lResult);

		public const int WM_COPYDATA = 0x004A;

		[StructLayout(LayoutKind.Sequential)]
		public struct COPYDATASTRUCT
		{
			/// <summary>
			/// Pointer of sender (so receiver can send back)
			/// </summary>
			public IntPtr dwData;
			/// <summary>
			/// Count of Bytes
			/// </summary>
			public int cbData;
			/// <summary>
			/// Pointer of a byte array
			/// </summary>
			public IntPtr lpData;
		}

		public static void _SendMessage(string msg, IntPtr target)
		{
			byte[] b = Encoding.UTF8.GetBytes(msg);
			IntPtr hLog = Marshal.AllocHGlobal(b.Length);
			Marshal.Copy(b, 0, hLog, b.Length);
			COPYDATASTRUCT data = new COPYDATASTRUCT();
			data.cbData = b.Length;
			data.lpData = hLog;
			SendMessage(target, WM_COPYDATA, 0, ref data);
		}

		public static string _GetMessage(Message m)
		{
			string msg = null;
			if (m.Msg == Win32.WM_COPYDATA)
			{
				if (InSendMessage()) ReplyMessage(IntPtr.Zero);
				COPYDATASTRUCT data = (COPYDATASTRUCT)m.GetLParam(typeof(COPYDATASTRUCT));
				byte[] b = new byte[data.cbData];
				Marshal.Copy(data.lpData, b, 0, data.cbData);
				msg = Encoding.UTF8.GetString(b);
			}
			return msg;
		}

		#endregion

		#region Set form's large and small icon explicitly
		
		const int WM_SETICON = 0x80;
		const int ICON_SMALL = 0;
		const int ICON_BIG = 1;

		public static void SetFormIcon(IntPtr hWnd, string IconPath, int IconIndex = 0)
		{
			uint IconCount = (uint)(IconIndex) + 1;
			IntPtr[] hSmallIcon = new IntPtr[IconCount];
			IntPtr[] hLargeIcon = new IntPtr[IconCount];
			ExtractIconEx(IconPath, IconIndex, hLargeIcon, hSmallIcon, IconCount);
			SendMessage(hWnd, WM_SETICON, ICON_BIG, hLargeIcon[IconIndex]);
			SendMessage(hWnd, WM_SETICON, ICON_SMALL, hSmallIcon[IconIndex]);
		}

		#endregion

		#region Start service even if it's disabled 

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

		[DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
		static extern int CloseServiceHandle(IntPtr hSCObject);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		static extern Boolean ChangeServiceConfig(
			IntPtr hService,
			UInt32 nServiceType,
			SvcStartupType nStartType,
			UInt32 nErrorControl,
			String lpBinaryPathName,
			String lpLoadOrderGroup,
			IntPtr lpdwTagId,
			[In] char[] lpDependencies,
			String lpServiceStartName,
			String lpPassword,
			String lpDisplayName);

		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		static extern Boolean QueryServiceConfig(
			IntPtr hService, 
			IntPtr intPtrQueryConfig, 
			UInt32 cbBufSize, 
			out UInt32 pcbBytesNeeded);

		[DllImport("advapi32", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool StartService(
						IntPtr hService,
					int dwNumServiceArgs,
					string[] lpServiceArgVectors
					);

		const uint SC_MANAGER_CONNECT = 0x00000001;
		const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;
		const uint SERVICE_QUERY_CONFIG = 0x00000001;
		const uint SERVICE_CHANGE_CONFIG = 0x00000002;
		const uint SERVICE_START = 0x00000016;
		const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;

		enum SvcStartupType : uint
		{
			BootStart = 0,      //Device driver started by the system loader.
			SystemStart = 1,    //Device driver started by the IoInitSystem function.
			Automatic = 2,
			Manual = 3,
			Disabled = 4
		}

		[StructLayout(LayoutKind.Sequential)]
		class QUERY_SERVICE_CONFIG
		{
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
			public UInt32 dwServiceType;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
			public SvcStartupType dwStartType;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
			public UInt32 dwErrorControl;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
			public String lpBinaryPathName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
			public String lpLoadOrderGroup;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
			public UInt32 dwTagID;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
			public String lpDependencies;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
			public String lpServiceStartName;
			[MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)]
			public String lpDisplayName;
		};

		public static bool TryStartService(string svcName)
		{
			bool wasDisabled = false;
			QUERY_SERVICE_CONFIG SvcConfig = new QUERY_SERVICE_CONFIG();
			IntPtr hSvcMgr = OpenSCManager(null, null, SC_MANAGER_CONNECT);
			IntPtr hSvc = OpenService(hSvcMgr, "TrustedInstaller",
				SERVICE_CHANGE_CONFIG | SERVICE_QUERY_CONFIG | SERVICE_START);
			// Check if the service was disabled
			uint dummy = 0;
			IntPtr ptr = Marshal.AllocHGlobal(4096);
			if (!QueryServiceConfig(hSvc, ptr, 4096, out dummy)) return false;
			Marshal.PtrToStructure(ptr, SvcConfig);
			Marshal.FreeHGlobal(ptr);
			wasDisabled = (SvcConfig.dwStartType == SvcStartupType.Disabled);
			// If it was disabled, set it as manual temporary
			if (wasDisabled)
			{
				if (!ChangeServiceConfig(hSvc, SERVICE_NO_CHANGE,
					SvcStartupType.Manual, SERVICE_NO_CHANGE, 
					null, null, IntPtr.Zero, null, null, null, null)) return false;
			}
			// Start the service
			StartService(hSvc, 0, null);
			// If it was disabled, set it back to disabled
			if (wasDisabled)
			{
				if (!ChangeServiceConfig(hSvc, SERVICE_NO_CHANGE,
					SvcStartupType.Disabled, SERVICE_NO_CHANGE,
					null, null, IntPtr.Zero, null, null, null, null)) return false;
			}
			// Clean up
			CloseServiceHandle(hSvc);
			CloseServiceHandle(hSvcMgr);
			return true;
		}

		#endregion

		public static string WinAPILastErrMsg()
		{
			return WinAPILastErrMsg(Marshal.GetLastWin32Error());
		}

		public static string WinAPILastErrMsg(int err)
		{
			return new Win32Exception(err).Message + " (Error code: " + err + ")";
		}

	}
}
