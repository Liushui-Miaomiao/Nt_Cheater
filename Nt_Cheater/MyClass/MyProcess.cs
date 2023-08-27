using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Nt_Cheater {
	/// <summary>
	/// 进程操作类
	/// </summary>
	class MyProcess {
		// DLL函数声明

		[DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
		private static extern bool _ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);

		[DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		private static extern bool _WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, int[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);

		[DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
		private static extern IntPtr _OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		/// <summary>
		/// 判断指定进程是否存在
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <returns>指定进程是否存在</returns>
		public static bool IsExistsProcess(string processName) {
			Process[] processes = Process.GetProcessesByName(processName);

			return processes.Length > 0;
		}

		/// <summary>
		/// 判断程序是否以管理员身份启动
		/// </summary>
		/// <returns>程序是否以管理员身份启动</returns>
		public static bool IsAdministrator() {
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);

			return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
		}

		/// <summary>
		/// 通过进程名称获取进程pid
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <returns>指定名称进程的pid</returns>
		public static int GetPidByProcessName(string processName) {
			int pid = 0;

			if (!IsExistsProcess(processName)) {
				goto END;
			}

			Process[] processes = Process.GetProcessesByName(processName);
			foreach (Process process in processes) {
				pid = process.Id;

				goto END;
			}

		END:
			return pid;
		}

		/// <summary>
		/// 通过进程名称获取进程起始地址
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <returns>指定名称进程的起始地址</returns>
		public static IntPtr GetProcessBaseAddr(string processName) {
			IntPtr baseAddr = IntPtr.Zero;

			if (!IsExistsProcess(processName)) {
				goto END;
			}

			Process[] processes = Process.GetProcessesByName(processName);
			foreach (Process process in processes) {
				baseAddr = process.MainModule.BaseAddress;

				goto END;
			}

		END:
			return baseAddr;
		}

		/// <summary>
		/// 打开进程
		/// </summary>
		/// <param name="dwDesiredAccess"></param>
		/// <param name="bInheritHandle"></param>
		/// <param name="dwProcessId"></param>
		/// <returns>进程句柄</returns>
		public static IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId) {
			try {
				return _OpenProcess(dwDesiredAccess, bInheritHandle, dwProcessId);
			}
			catch (Exception) { }

			return IntPtr.Zero;
		}

		/// <summary>
		/// 读进程内存
		/// </summary>
		/// <param name="hProcess"></param>
		/// <param name="lpBaseAddress"></param>
		/// <param name="lpBuffer"></param>
		/// <param name="nSize"></param>
		/// <param name="lpNumberOfBytesRead"></param>
		/// <returns></returns>
		public static bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, IntPtr lpNumberOfBytesRead) {
			try {
				return _ReadProcessMemory(hProcess, lpBaseAddress, lpBuffer, nSize, lpNumberOfBytesRead);
			}
			catch (Exception) { }

			return false;
		}

		/// <summary>
		/// 写进程内存
		/// </summary>
		/// <param name="hProcess"></param>
		/// <param name="lpBaseAddress"></param>
		/// <param name="lpBuffer"></param>
		/// <param name="nSize"></param>
		/// <param name="lpNumberOfBytesWritten"></param>
		/// <returns></returns>
		public static bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, int[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten) {
			try {
				return _WriteProcessMemory(hProcess, lpBaseAddress, lpBuffer, nSize, lpNumberOfBytesWritten);
			}
			catch (Exception) { }

			return false;
		}

	}
}
