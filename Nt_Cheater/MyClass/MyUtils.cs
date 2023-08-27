using System;
using System.Windows.Forms;

namespace Nt_Cheater {
	/// <summary>
	/// 无参无返回值回调函数
	/// </summary>
	public delegate void CallBack();
	/// <summary>
	/// 一个int参数无返回值的回调函数
	/// </summary>
	/// <param name="pid"></param>
	public delegate void CallBack_i(int pid);
	/// <summary>
	/// 一个IntPtr类型无返回值的回调函数
	/// </summary>
	/// <param name="pid"></param>
	public delegate void CallBack_ip(IntPtr baseAddr);

	/// <summary>
	/// 工具类
	/// </summary>
	class MyUtils {

		/// <summary>
		/// 查找进程
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <param name="success">成功回调</param>
		/// <param name="fail">失败回调</param>
		public static void FindProcess(string processName, CallBack success = null, CallBack fail = null) {
			if (MyProcess.IsExistsProcess(processName)) {
				success?.Invoke();

				return;
			}

			fail?.Invoke();
		}

		/// <summary>
		/// 通过进程名称获取进程pid
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <param name="success">成功回调（需要一个int参数）</param>
		/// <param name="fail">失败回调</param>
		public static void GetPidByProcessName(string processName, CallBack_i success = null, CallBack fail = null) {
			int pid = MyProcess.GetPidByProcessName(processName);

			if (pid > 0) {
				success?.Invoke(pid);

				return;
			}

			fail?.Invoke();
		}

		/// <summary>
		/// 通过进程名称获取进程基地址
		/// </summary>
		/// <param name="processName">进程名</param>
		/// <param name="success">成功回调（需要一个IntPtr参数）</param>
		/// <param name="fail">失败回调</param>
		public static void GetProcessBaseAddr(string processName, CallBack_ip success = null, CallBack fail = null) {
			IntPtr baseAddr = MyProcess.GetProcessBaseAddr(processName);

			if (baseAddr != IntPtr.Zero) {
				success?.Invoke(baseAddr);

				return;
			}

			fail?.Invoke();
		}

		/// <summary>
		/// 设置某一窗口所有组件可用性
		/// </summary>
		/// <param name="controls">组件集</param>
		/// <param name="b">可用性</param>
		public static void SetAllControlEnable(Control.ControlCollection controls, bool b) {
			foreach (Control control in controls) {
				if (control is StatusStrip) {
					continue;
				}

				// 排除特殊组件
				if (control.Text.IndexOf("*") != -1) {
					continue;
				}

				control.Enabled = b;
			}
		}

		/// <summary>
		/// 判断程序是否以管理员身份启动
		/// </summary>
		/// <returns>程序是否以管理员身份启动</returns>
		public static bool IsAdministrator() {
			return MyProcess.IsAdministrator();
		}
	}
}
