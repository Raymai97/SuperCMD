using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace SuperCMD
{
	class ShellLink
	{
		#region Win32 native 

		const int INFOTIPSIZE = 1024;
		const int MAX_PATH = 260;
		// GUID
		const string IID_IPersist = "0000010C-0000-0000-C000-000000000046";
		const string IID_IPersistFile = "0000010B-0000-0000-C000-000000000046";
		const string IID_IShellLinkA = "000214EE-0000-0000-C000-000000000046";
		const string IID_IShellLinkW = "000214F9-0000-0000-C000-000000000046";
		const string CLSID_ShellLink = "00021401-0000-0000-C000-000000000046";
		// IShellLink.Resolve flags
		const uint SLR_NO_UI = 0x1;
		const uint SLR_ANY_MATCH = 0x2;
		const uint SLR_UPDATE = 0x4;
		const uint SLR_NOUPDATE = 0x8;
		const uint SLR_NOSEARCH = 0x10;
		const uint SLR_NOTRACK = 0x20;
		const uint SLR_NOLINKINFO = 0x40;
		const uint SLR_INVOKE_MSI = 0x80;
		// IShellLink.GetPath flags
		const uint SLGP_SHORTPATH = 0x1;
		const uint SLGP_UNCPRIORITY = 0x2;
		const uint SLGP_RAWPATH = 0x4;

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(IID_IPersist)]
		public interface IPersist
		{
			[PreserveSig]
			void GetClassID(out Guid pClassID);
		}

		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(IID_IPersistFile)]
		public interface IPersistFile : IPersist
		{
			new void GetClassID(out Guid pClassID);
			[PreserveSig]
			int IsDirty();

			[PreserveSig]
			void Load([In, MarshalAs(UnmanagedType.LPWStr)]
						string pszFileName, uint dwMode);

			[PreserveSig]
			int Save([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName,
						[In, MarshalAs(UnmanagedType.Bool)] bool fRemember);

			[PreserveSig]
			void SaveCompleted([In, MarshalAs(UnmanagedType.LPWStr)] string pszFileName);

			[PreserveSig]
			void GetCurFile([In, MarshalAs(UnmanagedType.LPWStr)] string ppszFileName);
		}

		[ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(IID_IShellLinkA)]
		interface IShellLinkA
		{
			/// <summary>Retrieves the path and file name of a Shell link object</summary>
			void GetPath([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszFile, int cchMaxPath, out WIN32_FIND_DATA pfd, uint SLGPflags);
			/// <summary>Retrieves the list of item identifiers for a Shell link object</summary>
			void GetIDList(out IntPtr ppidl);
			/// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object</summary>
			void SetIDList(IntPtr pidl);
			/// <summary>Retrieves the description string for a Shell link object</summary>
			void GetDescription([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszName, int cchMaxName);
			/// <summary>Sets the description for a Shell link object. The description can be any application-defined string</summary>
			void SetDescription([MarshalAs(UnmanagedType.LPStr)] string pszName);
			/// <summary>Retrieves the name of the working directory for a Shell link object</summary>
			void GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszDir, int cchMaxPath);
			/// <summary>Sets the name of the working directory for a Shell link object</summary>
			void SetWorkingDirectory([MarshalAs(UnmanagedType.LPStr)] string pszDir);
			/// <summary>Retrieves the command-line arguments associated with a Shell link object</summary>
			void GetArguments([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszArgs, int cchMaxPath);
			/// <summary>Sets the command-line arguments for a Shell link object</summary>
			void SetArguments([MarshalAs(UnmanagedType.LPStr)] string pszArgs);
			/// <summary>Retrieves the hot key for a Shell link object</summary>
			void GetHotkey(out short pwHotkey);
			/// <summary>Sets a hot key for a Shell link object</summary>
			void SetHotkey(short wHotkey);
			/// <summary>Retrieves the show command for a Shell link object</summary>
			void GetShowCmd(out int piShowCmd);
			/// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
			void SetShowCmd(int iShowCmd);
			/// <summary>Retrieves the location (path and index) of the icon for a Shell link object</summary>
			void GetIconLocation([Out(), MarshalAs(UnmanagedType.LPStr)] StringBuilder pszIconPath
				, int cchIconPath, out int piIcon);
			/// <summary>Sets the location (path and index) of the icon for a Shell link object</summary>
			void SetIconLocation([MarshalAs(UnmanagedType.LPStr)] string pszIconPath, int iIcon);
			/// <summary>Sets the relative path to the Shell link object</summary>
			void SetRelativePath([MarshalAs(UnmanagedType.LPStr)] string pszPathRel, int dwReserved);
			/// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed</summary>
			void Resolve(IntPtr hwnd, uint SLRflags);
			/// <summary>Sets the path and file name of a Shell link object</summary>
			void SetPath([MarshalAs(UnmanagedType.LPStr)] string pszFile);
		}

		[ComImport(), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid(IID_IShellLinkW)]
		interface IShellLinkW
		{
			/// <summary>Retrieves the path and file name of a Shell link object</summary>
			void GetPath([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszFile, int cchMaxPath, out WIN32_FIND_DATA pfd, uint SLGPflags);
			/// <summary>Retrieves the list of item identifiers for a Shell link object</summary>
			void GetIDList(out IntPtr ppidl);
			/// <summary>Sets the pointer to an item identifier list (PIDL) for a Shell link object.</summary>
			void SetIDList(IntPtr pidl);
			/// <summary>Retrieves the description string for a Shell link object</summary>
			void GetDescription([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszName, int cchMaxName);
			/// <summary>Sets the description for a Shell link object. The description can be any application-defined string</summary>
			void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string pszName);
			/// <summary>Retrieves the name of the working directory for a Shell link object</summary>
			void GetWorkingDirectory([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszDir, int cchMaxPath);
			/// <summary>Sets the name of the working directory for a Shell link object</summary>
			void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string pszDir);
			/// <summary>Retrieves the command-line arguments associated with a Shell link object</summary>
			void GetArguments([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszArgs, int cchMaxPath);
			/// <summary>Sets the command-line arguments for a Shell link object</summary>
			void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string pszArgs);
			/// <summary>Retrieves the hot key for a Shell link object</summary>
			void GetHotkey(out short pwHotkey);
			/// <summary>Sets a hot key for a Shell link object</summary>
			void SetHotkey(short wHotkey);
			/// <summary>Retrieves the show command for a Shell link object</summary>
			void GetShowCmd(out int piShowCmd);
			/// <summary>Sets the show command for a Shell link object. The show command sets the initial show state of the window.</summary>
			void SetShowCmd(int iShowCmd);
			/// <summary>Retrieves the location (path and index) of the icon for a Shell link object</summary>
			void GetIconLocation([Out(), MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszIconPath, int cchIconPath, out int piIcon);
			/// <summary>Sets the location (path and index) of the icon for a Shell link object</summary>
			void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string pszIconPath, int iIcon);
			/// <summary>Sets the relative path to the Shell link object</summary>
			void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string pszPathRel, int dwReserved);
			/// <summary>Attempts to find the target of a Shell link, even if it has been moved or renamed</summary>
			void Resolve(IntPtr hwnd, uint SLRflags);
			/// <summary>Sets the path and file name of a Shell link object</summary>
			void SetPath([MarshalAs(UnmanagedType.LPWStr)] string pszFile);
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		struct WIN32_FIND_DATA
		{
			public uint dwFileAttributes;
			public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
			public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
			public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
			public uint nFileSizeHigh;
			public uint nFileSizeLow;
			public uint dwReserved0;
			public uint dwReserved1;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string cFileName;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
			public string cAlternateFileName;
		}

		#endregion

		bool Unicode = Environment.OSVersion.Version.Major >= 5 ? true : false;
		IShellLinkA _slA;
		IShellLinkW _slW;
		string lnkPath;

		public ShellLink(string lnkPath)
		{
			this.lnkPath = lnkPath;
			if (Unicode)
			{
				_slW = (IShellLinkW)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(CLSID_ShellLink)));
				((IPersistFile)(_slW)).Load(lnkPath, 0);
			}
			else
			{
				_slA = (IShellLinkA)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid(CLSID_ShellLink)));
				((IPersistFile)(_slA)).Load(lnkPath, 0);
			}
		}

		public ShellLink(string lnkPath, bool Unicode)
			: this(lnkPath)
		{
			this.Unicode = Unicode;			
		}

		public string Arguments
		{
			get
			{
				StringBuilder sb = new StringBuilder(INFOTIPSIZE);
				if (Unicode)
				{
					_slW.GetArguments(sb, sb.Capacity);
				}
				else
				{
					_slA.GetArguments(sb, sb.Capacity);
				}
				return sb.ToString();
			}
			set
			{
				if (Unicode)
				{
					_slW.SetArguments(value);
				}
				else
				{
					_slA.SetArguments(value);
				}
			}
		}

		public string Description
		{
			get
			{
				StringBuilder sb = new StringBuilder(INFOTIPSIZE);
				if (Unicode)
				{
					_slW.GetDescription(sb, sb.Capacity);
				}
				else
				{
					_slA.GetDescription(sb, sb.Capacity);
				}
				return sb.ToString();
			}
			set
			{
				if (Unicode)
				{
					_slW.SetArguments(value);
				}
				else
				{
					_slA.SetArguments(value);
				}
			}
		}

		public string WorkingDir
		{
			get
			{
				StringBuilder sb = new StringBuilder(INFOTIPSIZE);
				if (Unicode)
				{
					_slW.GetWorkingDirectory(sb, sb.Capacity);
				}
				else
				{
					_slA.GetWorkingDirectory(sb, sb.Capacity);
				}
				return sb.ToString();
			}
			set
			{
				if (Unicode)
				{
					_slW.SetWorkingDirectory(value);
				}
				else
				{
					_slA.SetWorkingDirectory(value);
				}
			}
		}

		// If Path returns an empty string, the shortcut is associated with
		// a PIDL instead, which can be retrieved with IShellLink.GetIDList().
		public string Path
		{
			get
			{
				StringBuilder sb = new StringBuilder(INFOTIPSIZE);
				WIN32_FIND_DATA fd;
				if (Unicode)
				{
					_slW.GetPath(sb, sb.Capacity, out fd, SLGP_RAWPATH);
				}
				else
				{
					_slA.GetPath(sb, sb.Capacity, out fd, SLGP_RAWPATH);
				}
				return sb.ToString();
			}
			set
			{
				_slW.SetPath(value);
			}
		}

		public string IconPath
		{
			get
			{
				StringBuilder sb = new StringBuilder(INFOTIPSIZE);
				int i;
				if (Unicode)
				{
					_slW.GetIconLocation(sb, sb.Capacity, out i);
				}
				else
				{
					_slA.GetIconLocation(sb, sb.Capacity, out i);
				}
				return sb.ToString();
			}
			set
			{
				if (Unicode)
				{
					_slW.SetIconLocation(value, IconIndex);
				}
				else
				{
					_slA.SetIconLocation(value, IconIndex);
				}
			}
		}

		public int IconIndex
		{
			get
			{
				StringBuilder sb = new StringBuilder(INFOTIPSIZE);
				int i;
				if (Unicode)
				{
					_slW.GetIconLocation(sb, sb.Capacity, out i);
				}
				else
				{
					_slA.GetIconLocation(sb, sb.Capacity, out i);
				}
				return i;
			}
			set
			{
				if (Unicode)
				{
					_slW.SetIconLocation(IconPath, value);
				}
				else
				{
					_slA.SetIconLocation(IconPath, value);
				}
			}
		}

		public ProcessWindowStyle WindowStyle
		{
			get
			{
				int i;
				if (Unicode)
				{
					_slW.GetShowCmd(out i);
				}
				else
				{
					_slA.GetShowCmd(out i);
				}
				switch (i)
				{
					case 3:	return ProcessWindowStyle.Maximized;
					case 2:	return ProcessWindowStyle.Minimized;
					default: return ProcessWindowStyle.Normal;
				}
			}
			set
			{
				int i;
				switch (value)
				{
					case ProcessWindowStyle.Maximized: i = 3; break;
					case ProcessWindowStyle.Minimized: i = 2; break;
					case ProcessWindowStyle.Normal:	i = 1; break;
					default: throw new ArgumentException("No such thing in Shortcut!");
				}
				if (Unicode)
				{
					_slW.SetShowCmd(i);
				}
				else
				{
					_slA.SetShowCmd(i);
				}
			}
		}

		public int Save()
		{
			if (Unicode)
			{
				return ((IPersistFile)(_slW)).Save(lnkPath, true);
			}
			else
			{
				return ((IPersistFile)(_slA)).Save(lnkPath, true);
			}
		}

	}
}
