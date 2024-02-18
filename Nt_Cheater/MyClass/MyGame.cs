using System;
using System.Runtime.InteropServices;

namespace Nt_Cheater {

	/// <summary>
	/// 游戏类
	/// </summary>
	class MyGame {

		/// <summary>
		/// 平滑画质
		/// </summary>
		public const int QUALITY_SMOOTH = 1;
		/// <summary>
		/// 不平滑画质
		/// </summary>
		public const int QUALITY_NO_SMOOTH = 0;

		/// <summary>
		/// 读取/写入的数据大小
		/// </summary>
		private const int DATA_SIZE = 4;

		/// <summary>
		/// 游戏pid
		/// </summary>
		public int pid = 0;
		/// <summary>
		/// 游戏运行的基地址
		/// </summary>
		public IntPtr baseAddr = IntPtr.Zero;
		/// <summary>
		/// 画质
		/// </summary>
		public int Quality {
			get {
				int value = QUALITY_NO_SMOOTH;
				ReadMemory(MyAddress.QUALITY, ref value);

				return value;
			}
			set {
				WriteMemory(MyAddress.QUALITY, value);
			}
		}
		/// <summary>
		/// 难度
		/// </summary>
		public string Difficulty {
			get {
				int index = 0;
				ReadMemory(MyAddress.DIFFICULTY, ref index);

				string[] difficultys = { "CASUAL", "MANIAC", "EXPERT", "NIGHTMARE" };

				try {
					string difficulty = difficultys.GetValue(index) as string;

					return difficulty;
				}
				catch (Exception) { }

				return "NULL";
			}
		}

		/// <summary>
		/// 游戏句柄
		/// </summary>
		private IntPtr _hProcess = IntPtr.Zero;

		/// <summary>
		/// 构造函数
		/// </summary>
		public MyGame() { }

		/// <summary>
		/// 初始化
		/// </summary>
		public void Init() {
			OpenProcess();
		}

		/// <summary>
		/// 打开进程
		/// </summary>
		private void OpenProcess() {
			if (pid == 0) {
				return;
			}

			// 以最大权限打开进程
			_hProcess = MyProcess.OpenProcess(0x1F0FFF, false, pid);
		}

		/// <summary>
		/// 获取游戏基址真实地址
		/// </summary>
		/// <param name="lpBaseAddress">基址</param>
		/// <returns>游戏基址真实地址</returns>
		public int GetRealAddress(int lpBaseAddress) {
			return baseAddr == IntPtr.Zero ?
				0 : 
				baseAddr.ToInt32() + lpBaseAddress;
		}

		/// <summary>
		/// 写入内存
		/// </summary>
		/// <param name="lpBaseAddress">基址</param>
		/// <param name="lpBuffer">内容</param>
		/// <param name="nSize">数据大小</param>
		public void WriteMemory(int lpBaseAddress, int lpBuffer, int nSize = DATA_SIZE) {
			if (_hProcess == IntPtr.Zero) {
				return;
			}

			_ = MyProcess.WriteProcessMemory(
				_hProcess,
				(IntPtr)GetRealAddress(lpBaseAddress),
				new int[] { lpBuffer },
				nSize,
				IntPtr.Zero
			);
		}

		/// <summary>
		/// 读取内存
		/// </summary>
		/// <param name="lpBaseAddress">基址</param>
		/// <param name="lpBuffer">内容地址</param>
		/// <param name="nSize">数据大小</param>
		public void ReadMemory(int lpBaseAddress, ref int lpBuffer, int nSize = DATA_SIZE) {
			if (_hProcess == IntPtr.Zero) {
				return;
			}

			byte[] buffer = new byte[DATA_SIZE];
			IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);

			_ = MyProcess.ReadProcessMemory(
				_hProcess,
				(IntPtr)GetRealAddress(lpBaseAddress),
				byteAddress,
				nSize,
				IntPtr.Zero
			);

			// 从IntPtr中读出数据
			lpBuffer = Marshal.ReadInt32(byteAddress);
		}

		/// <summary>
		/// 写入一组数据到内存
		/// </summary>
		/// <param name="lpBaseAddress">基址</param>
		/// <param name="lpBuffer">写入数据组</param>
		/// <param name="nSize">字节偏移组</param>
		public void WriteMemoryArray(int lpBaseAddress, int[] lpBuffer, int[] nSize) {
			if (_hProcess == IntPtr.Zero) {
				return;
			}
			if (lpBuffer.Length != nSize.Length) {
				return;
			}

			int length = lpBuffer.Length;
			for (int i = 0; i < length; i++) {
				// 间隔的大小为上一写入的数据大小偏移量
				int gapSize = i > 0 ? nSize[i - 1] : 0;

				// 顺次写入内存
				WriteMemory(
					lpBaseAddress + i * gapSize,
					lpBuffer[i],
					nSize[i]
				);
			}
		}
	}
}

